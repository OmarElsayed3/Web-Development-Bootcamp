namespace Task_3.Features.Course.Query.Models;

public class GetCourseById : IRequest<Response>
{
    public int Id { get; set; }
}