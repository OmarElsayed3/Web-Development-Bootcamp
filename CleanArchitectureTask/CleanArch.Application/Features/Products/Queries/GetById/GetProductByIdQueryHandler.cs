using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Products.Dtos;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Products.Queries.GetById;

public class GetProductByIdQueryHandler(IMapper mapper, IReadRepository<Domain.Models.Products.Product> productRepository) : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<Response<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            return Response<ProductDto>.NotFound("Products not found");
        }

        var productDto = mapper.Map<ProductDto>(product);
        return Response<ProductDto>.Success(productDto);
    }
}