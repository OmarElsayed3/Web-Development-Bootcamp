namespace Task_3.Controllers;

public class StudentCourseController : BaseController
{
    [HttpPost(Router.StudentCourseRouter.Main + "Assign")]
    public async Task<IActionResult> AssignStudentsToCourse(StudentCourseDto assignDto)
    {
        var result = await mediator.Send(assignDto);
        return Result(result);
    }
    [HttpDelete(Router.StudentCourseRouter.Main + "Unassign")]
    public async Task<IActionResult> UnassignStudentsFromCourse(DeleteStudentCourseDto unassignDto)
    {
        var result = await mediator.Send(unassignDto);
        return Result(result);
    }
    [HttpGet(Router.StudentCourseRouter.Main)]
    public async Task<IActionResult> All([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] int? studentId = null, [FromQuery] int? courseId = null)
    {
        var result = await mediator.Send(new GetAllStudentCourseDto { PageIndex = pageIndex, PageSize = pageSize, StudentId = studentId, CourseId = courseId });
        return Result(result);
    }
}