using MediatR;
using Task_3.Global;

namespace Task_3.Features.StudentCourse.Command.Models;

public class DeleteStudentCourseDto : IRequest<Response>
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}
