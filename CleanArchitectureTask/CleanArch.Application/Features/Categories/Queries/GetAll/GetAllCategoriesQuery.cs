using CleanArch.Application.Abstractions.Messaging;
using MediatR;
using CleanArch.Application.Features.Categories.Dtos;
using CleanArch.Domain.Filters;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Categories.Queries.GetAll;

public record GetAllCategoriesQuery(string? Name) : BaseFilter, IQuery<PaginatedResult<CategoryDto>>;

