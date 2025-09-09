namespace Task_3.Mapper;

public class StudentProfiler: Profile
{
    public StudentProfiler()
    {
        CreateMap<StudentDto, Student>().ReverseMap();
        CreateMap<UpdateStudentDto, Student>().ReverseMap();
    }
}