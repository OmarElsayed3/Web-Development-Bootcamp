using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Categories;
using CleanArch.Domain.Responses;


namespace CleanArch.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandHandler (IMapper mapper,IRepository<Category> categoryRepository) : ICommandHandler<UpdateCategoryCommand, Guid>
{
    public async Task<Response<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        
        mapper.Map(request, category);
        await categoryRepository.UpdateAsync(category, cancellationToken);
        return Response<Guid>.Success(category.Id);
    }
}

