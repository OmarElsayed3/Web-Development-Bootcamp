using Ardalis.Specification;

namespace CleanArch.Application.Features.Categories.Specifications;

public class CategoriesSpec : Specification<Domain.Models.Categories.Category>
{
    public CategoriesSpec(string? name, int pageSize, int pageNumber)
    {
        if (!string.IsNullOrWhiteSpace(name))
            Query.Where(x => x.Name.Contains(name));
        Query.Skip(pageSize * (pageNumber - 1));
        Query.Take(pageSize);
    }
}

