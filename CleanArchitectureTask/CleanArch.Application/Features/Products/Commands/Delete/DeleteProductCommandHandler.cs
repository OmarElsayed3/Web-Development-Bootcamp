using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Products;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler(IRepository<Product> productRepository) : ICommandHandler<DeleteProductCommand, Guid>
{
    public async Task<Response<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            return Response<Guid>.NotFound("Product not found.");
        }

        await productRepository.DeleteAsync(product, cancellationToken);
        return Response<Guid>.Success(request.Id);
    }
}