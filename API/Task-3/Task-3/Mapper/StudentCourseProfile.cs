namespace Task_3.Mapper;

public class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<StudentCourseDto, StudentCourse>().ReverseMap();
    }
}