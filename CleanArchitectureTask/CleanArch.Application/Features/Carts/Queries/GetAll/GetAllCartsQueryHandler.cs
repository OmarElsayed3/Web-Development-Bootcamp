using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Carts.Dtos;
using CleanArch.Application.Features.Carts.Specifications;
using CleanArch.Domain.Models.Carts;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Carts.Queries.GetAll;

public class GetAllCartsQueryHandler(IMapper mapper, IReadRepository<Cart> cartRepository) : IQueryHandler<GetAllCartsQuery, PaginatedResult<CartDto>>
{
    public async Task<Response<PaginatedResult<CartDto>>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
    {
        var carts = await cartRepository
            .ListAsync(new CartsSpec(request.UserId,
                request.PageSize,
                request.PageNumber), cancellationToken);

        var cartsCount = await cartRepository
            .CountAsync(new CartsSpec(request.UserId,
                request.PageSize,
                request.PageNumber), cancellationToken);

        var mappedCarts = mapper.Map<IEnumerable<CartDto>>(carts);
        var totalPages = (int)Math.Ceiling((double)cartsCount / request.PageSize);
        return Response<CartDto>.GetData(mappedCarts ,request.PageNumber, request.PageSize, cartsCount);
    }
}
