using Task_3.Features.Student.Command.Models;

namespace Task_3.Features.Student.Command.Handler;

public class StudentCommandHandler :
    IRequestHandler<StudentDto, Response>,
    IRequestHandler<UpdateStudentDto, Response>,
    IRequestHandler<DeleteStudentDto, Response>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public StudentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response> Handle(StudentDto request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Task_3.Models.Student>(request);
        await _unitOfWork.Repository<Task_3.Models.Student>().Create(student);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.Created,
            Message = "Student created successfully.",
            Data = student
        };
    }

    public async Task<Response> Handle(UpdateStudentDto request, CancellationToken cancellationToken)
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
        student.Name = request.Name;
        student.Age = request.Age;
        await _unitOfWork.Repository<Task_3.Models.Student>().Update(student);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Student updated successfully.",
            Data = student
        };
    }

    public async Task<Response> Handle(DeleteStudentDto request, CancellationToken cancellationToken)
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
        _unitOfWork.Repository<Task_3.Models.Student>().Delete(student);
        await _unitOfWork.CompleteAsync();
        return new Response
        {
            Status = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Student deleted successfully."
        };
    }
}

