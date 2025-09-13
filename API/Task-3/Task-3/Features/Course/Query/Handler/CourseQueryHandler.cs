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
        // Build specification
        var spec = new Task_3.BaseSpecification.BaseSpecification<Task_3.Models.Course>();
        if (!string.IsNullOrWhiteSpace(request.Name))
            spec.AddCriteria(c => c.Name.Contains(request.Name));
        spec.ApplyPagination((request.PageIndex - 1) * request.PageSize, request.PageSize);

        var courses = await _unitOfWork.Repository<Task_3.Models.Course>().GetAll(spec);
        var totalCount = await _unitOfWork.Repository<Task_3.Models.Course>().CountAsync(spec);
        var courseDtos = _mapper.Map<List<CourseDto>>(courses);
        var paginatedResult = new Task_3.Global.PaginatedResult<CourseDto>
        {
            Items = courseDtos,
            TotalCount = totalCount,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
        return new Response
        {
            Data = paginatedResult,
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