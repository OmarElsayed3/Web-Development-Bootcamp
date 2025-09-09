namespace Task_3.Features.StudentCourse.Command.Models;

public class StudentCourseDto : IRequest<Response>
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}

