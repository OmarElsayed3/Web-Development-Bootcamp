namespace Task_3.Features.Student.Query.Models;

public class GetStudentById : IRequest<Response>
{
    public int Id { get; set; }
}

