using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Responses;
using CleanArch.Domain.Models.Products;

namespace CleanArch.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler (IMapper mapper,IRepository<Product> productRepository) : ICommandHandler<UpdateProductCommand, Guid>
{
    public async Task<Response<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        
        mapper.Map(request, product);
        await productRepository.UpdateAsync(product, cancellationToken);
        return Response<Guid>.Success(product.Id);
    }
}