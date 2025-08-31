using API_Task2.Dto;
using API_Task2.Models;
using API_Task2.Services;
using AutoMapper;

namespace API_Task2.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeeDto, Employee>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom<ImagePathResolver>());
    }
}