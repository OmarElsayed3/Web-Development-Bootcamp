namespace Task_3.Mapper;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, Course>().ReverseMap();
        CreateMap<UpdateCourseDto, Course>().ReverseMap();
    }
}