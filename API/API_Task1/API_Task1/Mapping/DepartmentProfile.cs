using API_Task1.Models;
using AutoMapper;

namespace API_Task1.Mapping;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<DepartmentDto, Department>();
        CreateMap<Department, DepartmentDto>();
    }
}