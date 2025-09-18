using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Categories.Dtos;
using CleanArch.Application.Features.Categories.Specifications;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Categories.Queries.GetAll;

public class GetAllCategoriesQueryHandler(IMapper mapper, IReadRepository<Domain.Models.Categories.Category> productRepository) : IQueryHandler<GetAllCategoriesQuery, PaginatedResult<CategoryDto>>
{
    public async Task<Response<PaginatedResult<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await productRepository
            .ListAsync(new CategoriesSpec(request.Name, 
                request.PageSize, 
                request.PageNumber), cancellationToken);

        var categoriesCount = await productRepository
            .CountAsync(new CategoriesSpec(request.Name,
                request.PageSize,
                request.PageNumber), cancellationToken);
        
        var mappedCategories = mapper.Map<IEnumerable<CategoryDto>>(categories);
        
        return Response<CategoryDto>.GetData(mappedCategories ,request.PageNumber, request.PageSize, categoriesCount);
    }
}
