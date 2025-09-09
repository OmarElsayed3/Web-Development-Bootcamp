namespace Task_3.Features.Course.Query.Handler;

public class CourseQueryHandler : IRequestHandler<GetAllCourseDto, Response>,
    IRequestHandler<GetCourseById, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllCourseDto request, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.Repository<Task_3.Models.Course>().GetAll();
        var courseDtos = _mapper.Map<List<CourseDto>>(courses);
        return new Response
        {
            Data = courseDtos,
            Message = "Courses retrieved successfully",
            StatusCode = HttpStatusCode.OK
        };
    }

    public async Task<Response> Handle(GetCourseById request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Repository<Task_3.Models.Course>().GetById(request.Id);
        if (course == null)
        {
            return new Response
            {
                Data = null,
                Message = "Course not found",
                StatusCode = HttpStatusCode.NotFound
            };
        }
        var courseDto = _mapper.Map<CourseDto>(course);
        return new Response
        {
            Data = courseDto,
            Message = "Course retrieved successfully",
            StatusCode = HttpStatusCode.OK
        };
    }
}