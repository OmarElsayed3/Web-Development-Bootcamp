namespace Task_3.Features.StudentCourse.Command.Handler;

public class StudentCourseCommandHandler :
    IRequestHandler<StudentCourseDto, Response>,
    IRequestHandler<DeleteStudentCourseDto, Response>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public StudentCourseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(StudentCourseDto request, CancellationToken cancellationToken)
    {
        var studentCourse = _mapper.Map<Task_3.Models.StudentCourse>(request);
        await _unitOfWork.Repository<Task_3.Models.StudentCourse>().Create(studentCourse);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "StudentCourse created successfully.",
            Data = studentCourse
        };
    }
    

    public async Task<Response> Handle(DeleteStudentCourseDto request, CancellationToken cancellationToken)
    {
        var studentCourse = await _unitOfWork.Repository<Task_3.Models.StudentCourse>().GetByIds(request.StudentId, request.CourseId);
        if (studentCourse == null)
        {
            return new Response
            {
                Status = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = "StudentCourse not found."
            };
        }
        _unitOfWork.Repository<Task_3.Models.StudentCourse>().Delete(studentCourse);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "StudentCourse deleted successfully."
        };
    }
}
