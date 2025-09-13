namespace Task_3.Controllers;

public class StudentController : BaseController
{
    [HttpGet(Router.StudentRouter.Main)]
    public async Task<IActionResult> All([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string? name = null)
    {
        var result = await mediator.Send(new GetAllStudentDto { PageIndex = pageIndex, PageSize = pageSize, Name = name });
        return Result(result);
    }

    [HttpGet(Router.StudentRouter.MainId)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetStudentById { Id = id });
        return Result(result);
    }

    [HttpPost(Router.StudentRouter.Main)]
    public async Task<IActionResult> Create(StudentDto studentDto)
    {
        var result = await mediator.Send(studentDto);
        return Result(result);
    }

    [HttpPut(Router.StudentRouter.MainId)]
    public async Task<IActionResult> Update(UpdateStudentDto updateStudentDto)
    {
        var result = await mediator.Send(updateStudentDto);
        return Result(result);
    }

    [HttpDelete(Router.StudentRouter.MainId)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteStudentDto { Id = id });
        return Result(result);
    }
    
}