using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Categories;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Categories.Commands.Add;

public class AddCategoryCommandHandler(IMapper mapper, IRepository<Category> categoryRepository) : ICommandHandler<AddCategoryCommand, string>
{
    public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request);
        await categoryRepository.AddAsync(category, cancellationToken);
        return Response<string>.Success();
    }
}

