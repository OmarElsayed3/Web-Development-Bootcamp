namespace Task_3.Features.Course.Command.Handler;

public class CourseCommandHandler : 
    IRequestHandler<CourseDto, Response>,
    IRequestHandler<UpdateCourseDto, Response>,
    IRequestHandler<DeleteCourseDto, Response>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CourseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(CourseDto request, CancellationToken cancellationToken)
    {
        var course = mapper.Map<Task_3.Models.Course>(request);
        await _unitOfWork.Repository<Task_3.Models.Course>().Create(course);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.Created,
            Message = "Course created successfully.",
            Data = course
        };
    }

    public async Task<Response> Handle(UpdateCourseDto request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Repository<Task_3.Models.Course>().GetById(request.Id);
        if (course == null)
        {
            return new Response
            {
                Status = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = "Course not found.",
                Data = null
            };
        }
        course.Name = request.Name;
        course.Hours = request.Hours;
        await _unitOfWork.Repository<Task_3.Models.Course>().Update(course);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Course updated successfully.",
            Data = course
        };
    }

    public async Task<Response> Handle(DeleteCourseDto request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Repository<Task_3.Models.Course>().GetById(request.Id);
        if (course == null)
        {
            return new Response
            {
                Status = false,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "Course not found.",
                Data = null
            };
        }
        _unitOfWork.Repository<Task_3.Models.Course>().Delete(course);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Course deleted successfully.",
            Data = null
        };
    }
}