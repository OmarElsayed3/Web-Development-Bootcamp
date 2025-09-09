namespace Task_3.Features.Course.Command.Models;

public class CourseDto : IRequest<Response>
{
    public string Name { get; set; }
    public int Hours { get; set; }
}