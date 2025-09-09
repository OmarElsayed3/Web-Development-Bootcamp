namespace Task_3.Features.StudentCourse.Query.Models;

public class GetStudentCourseById : IRequest<Response>
{
    public int Id { get; set; }
}

