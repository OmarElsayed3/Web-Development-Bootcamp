namespace Task_3.Controllers;

public class CourseController : BaseController
{
    [HttpGet(Router.CourseRouter.Main)]
    public async Task<IActionResult> All([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string? name = null)
    {
        var result = await mediator.Send(new GetAllCourseDto { PageIndex = pageIndex, PageSize = pageSize, Name = name });
        return Result(result);
    }

    [HttpGet(Router.CourseRouter.MainId)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetCourseById { Id = id });
        return Result(result);
    }

    [HttpPost(Router.CourseRouter.Main)]
    public async Task<IActionResult> Create(CourseDto courseDto)
    {
        var result = await mediator.Send(courseDto);
        return Result(result);
    }

    [HttpPut(Router.CourseRouter.MainId)]
    public async Task<IActionResult> Update(UpdateCourseDto updateCourseDto)
    {
        var result = await mediator.Send(updateCourseDto);
        return Result(result);
    }

    [HttpDelete(Router.CourseRouter.MainId)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteCourseDto { Id = id });
        return Result(result);
    }
    
}