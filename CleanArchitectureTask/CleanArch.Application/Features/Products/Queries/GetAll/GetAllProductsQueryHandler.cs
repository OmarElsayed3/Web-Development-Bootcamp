using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Products.Dtos;
using CleanArch.Application.Features.Products.Specifications;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Products.Queries.GetAll;

public class GetAllProductsQueryHandler(IMapper mapper, IReadRepository<Domain.Models.Products.Product> productRepository) : IQueryHandler<GetAllProductsQuery, PaginatedResult<ProductDto>>
{
    public async Task<Response<PaginatedResult<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository
            .ListAsync(new ProductsSpec(request.Name, 
                request.PageSize, 
                request.PageNumber), cancellationToken);

        var productsCount = await productRepository
            .CountAsync(new ProductsSpec(request.Name,
                request.PageSize,
                request.PageNumber), cancellationToken);
        
        var mappedProducts = mapper.Map<IEnumerable<ProductDto>>(products);
        
        return Response<ProductDto>.GetData(mappedProducts ,request.PageNumber, request.PageSize, productsCount);
    }
}