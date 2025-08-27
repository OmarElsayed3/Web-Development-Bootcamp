using API_Task1.Models;
using AutoMapper;

namespace API_Task1.Mapping;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleDto, Role>();
        CreateMap<Role, RoleDto>();
    }
}