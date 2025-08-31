using API_Task2.Dto;
using API_Task2.Models;
using AutoMapper;

namespace API_Task2.Mapping;

public class DependentProfile : Profile
{
    public DependentProfile()
    {
        CreateMap<DependentDto, Dependent>();
    }
}