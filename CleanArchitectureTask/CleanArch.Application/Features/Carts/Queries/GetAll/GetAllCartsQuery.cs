using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Features.Carts.Dtos;
using CleanArch.Domain.Filters;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Carts.Queries.GetAll;

public record GetAllCartsQuery(Guid? UserId) : BaseFilter, IQuery<PaginatedResult<CartDto>>;


