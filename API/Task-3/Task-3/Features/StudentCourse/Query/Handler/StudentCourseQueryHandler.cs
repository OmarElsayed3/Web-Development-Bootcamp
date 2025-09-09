namespace Task_3.Features.StudentCourse.Query.Handler;

public class StudentCourseQueryHandler :
    IRequestHandler<GetAllStudentCourseDto, Response>,
    IRequestHandler<GetStudentCourseById, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentCourseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllStudentCourseDto request, CancellationToken cancellationToken)
    {
        var studentCourses = await _unitOfWork.Repository<Task_3.Models.StudentCourse>().GetAll();
        var studentCourseDtos = _mapper.Map<List<StudentCourseDto>>(studentCourses);
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "StudentCourses retrieved successfully.",
            Data = studentCourseDtos
        };
    }

    public async Task<Response> Handle(GetStudentCourseById request, CancellationToken cancellationToken)
    {
        var studentCourse = await _unitOfWork.Repository<Task_3.Models.StudentCourse>().GetById(request.Id);
        if (studentCourse == null)
        {
            return new Response
            {
                Status = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = "StudentCourse not found."
            };
        }
        var studentCourseDto = _mapper.Map<StudentCourseDto>(studentCourse);
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "StudentCourse retrieved successfully.",
            Data = studentCourseDto
        };
    }
}

