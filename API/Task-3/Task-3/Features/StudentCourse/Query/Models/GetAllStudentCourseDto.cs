namespace Task_3.Features.StudentCourse.Query.Models;

public class GetAllStudentCourseDto : IRequest<Response>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? StudentId { get; set; } 
    public int? CourseId { get; set; } 
}
