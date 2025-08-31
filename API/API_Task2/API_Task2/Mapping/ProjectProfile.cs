using API_Task2.Dto;
using API_Task2.Models;
using AutoMapper;

namespace API_Task2.Mapping;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectDto, Project>();
    }
}