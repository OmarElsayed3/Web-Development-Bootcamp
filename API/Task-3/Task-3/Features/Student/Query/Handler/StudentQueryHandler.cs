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
        var spec = new BaseSpecification.BaseSpecification<Task_3.Models.Student>();
        if (!string.IsNullOrWhiteSpace(request.Name))
            spec.AddCriteria(s => s.Name.Contains(request.Name));
        spec.ApplyPagination((request.PageIndex - 1) * request.PageSize, request.PageSize);

        var students = await _unitOfWork.Repository<Task_3.Models.Student>().GetAll(spec);
        var totalCount = await _unitOfWork.Repository<Task_3.Models.Student>().CountAsync(spec);
        var studentDtos = _mapper.Map<List<StudentDto>>(students);
        var paginatedResult = new PaginatedResult<StudentDto>
        {
            Items = studentDtos,
            TotalCount = totalCount,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Students retrieved successfully.",
            Data = paginatedResult
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