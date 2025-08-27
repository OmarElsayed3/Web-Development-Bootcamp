using API_Task1.Models;
using AutoMapper;

namespace API_Task1.Mapping;

public class LoginProfile : Profile
{
    public LoginProfile()
    {
        CreateMap<LoginDto, Login>();
        CreateMap<Login, LoginDto>();
    }
}