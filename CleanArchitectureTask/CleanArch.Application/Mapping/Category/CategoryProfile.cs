using CleanArch.Application.Features.Categories.Commands.Add;
using CleanArch.Application.Features.Categories.Dtos;

namespace CleanArch.Application.Mapping.Category;

public class CategoryProfile : AutoMapper.Profile
{
    public CategoryProfile()
    {
        CreateMap<Domain.Models.Categories.Category, AddCategoryCommand>().ReverseMap();
        CreateMap<Domain.Models.Categories.Category, CategoryDto>().ReverseMap();
        CreateMap<Features.Categories.Commands.Update.UpdateCategoryCommand, Domain.Models.Categories.Category>();
    }
}