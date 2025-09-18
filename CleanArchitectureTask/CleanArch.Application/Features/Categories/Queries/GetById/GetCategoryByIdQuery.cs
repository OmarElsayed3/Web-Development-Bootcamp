using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Features.Categories.Dtos;

namespace CleanArch.Application.Features.Categories.Queries.GetById;

public record GetCategoryByIdQuery(Guid Id) : IQuery<CategoryDto>;

