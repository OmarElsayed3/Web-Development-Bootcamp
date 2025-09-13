namespace Task_3.Features.Course.Query.Models;

public class GetAllCourseDto : IRequest<Response>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Name { get; set; } // Optional filter by name
}