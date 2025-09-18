using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Products;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Products.Commands.Add;

public class AddProductCommandHandler(IMapper mapper, IRepository<Product> productRepository) : ICommandHandler<AddProductCommand, string>
{
    public async Task<Response<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = mapper.Map<Product>(request);
        await productRepository.AddAsync(product, cancellationToken);
        return Response<string>.Success();
    }
}