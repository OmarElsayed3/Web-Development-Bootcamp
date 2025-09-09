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
}