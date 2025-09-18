using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Features.Products.Dtos;
using CleanArch.Domain.Filters;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Products.Queries.GetAll;

public record GetAllProductsQuery(string? Name): BaseFilter, IQuery<PaginatedResult<ProductDto>>;