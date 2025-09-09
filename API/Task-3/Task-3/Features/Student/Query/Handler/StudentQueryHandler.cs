namespace Task_3.Features.Student.Query.Handler;

public class StudentQueryHandler :
    IRequestHandler<GetAllStudentDto, Response>,
    IRequestHandler<GetStudentById, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllStudentDto request, CancellationToken cancellationToken)
    {
        var students = await _unitOfWork.Repository<Task_3.Models.Student>().GetAll();
        var studentDtos = _mapper.Map<List<StudentDto>>(students);
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Students retrieved successfully.",
            Data = studentDtos
        };
    }

    public async Task<Response> Handle(GetStudentById request, CancellationToken cancellationToken)
    {
        var student = await _unitOfWork.Repository<Task_3.Models.Student>().GetById(request.Id);
        if (student == null)
        {
            return new Response
            {
                Status = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = "Student not found."
            };
        }
        var studentDto = _mapper.Map<StudentDto>(student);
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Student retrieved successfully.",
            Data = studentDto
        };
    }
}