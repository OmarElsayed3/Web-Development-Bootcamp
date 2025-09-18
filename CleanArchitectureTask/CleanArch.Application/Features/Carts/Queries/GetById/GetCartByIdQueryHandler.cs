using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Carts.Dtos;
using CleanArch.Application.Features.Carts.Specifications;
using CleanArch.Domain.Models.Carts;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Carts.Queries.GetById;

public class GetCartByIdQueryHandler(IMapper mapper, IReadRepository<Cart> cartRepository) : IQueryHandler<GetCartByIdQuery, CartDto>
{
    public async Task<Response<CartDto>> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new CartByIdWithItemsSpec(request.Id);
        var cart = await cartRepository.FirstOrDefaultAsync(spec, cancellationToken);
        if (cart == null)
        {
            return Response<CartDto>.NotFound("Carts not found");
        }

        var cartDto = mapper.Map<CartDto>(cart);
        return Response<CartDto>.Success(cartDto);
    }
}
