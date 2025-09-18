using Ardalis.Specification;

namespace CleanArch.Application.Features.Products.Specifications;

public class ProductsSpec : Specification<Domain.Models.Products.Product>
{
    public ProductsSpec(string? name, int pageSize, int pageNumber)
    {
        if (name != null)
            Query.Where(x=>x.Name.Contains(name));
        Query.Skip(pageSize * (pageNumber - 1));
        Query.Take(pageSize);
    }
}