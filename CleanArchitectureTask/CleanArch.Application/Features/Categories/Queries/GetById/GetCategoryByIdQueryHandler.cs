using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Categories.Dtos;
using CleanArch.Domain.Models.Categories;
using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Features.Categories.Queries.GetById;

public class GetCategoryByIdQueryHandler(IMapper mapper, IReadRepository<Category> categoryRepository) : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<Response<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null)
        {
            return Response<CategoryDto>.NotFound("Categories not found");
        }

        var categoryDto = mapper.Map<CategoryDto>(category);
        return Response<CategoryDto>.Success(categoryDto);
    }
}

