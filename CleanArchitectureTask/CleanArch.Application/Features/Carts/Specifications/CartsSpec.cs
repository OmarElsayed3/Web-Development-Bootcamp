using Ardalis.Specification;

namespace CleanArch.Application.Features.Carts.Specifications;

public class CartsSpec : Specification<Domain.Models.Carts.Cart>
{
    public CartsSpec(Guid? userId, int pageSize, int pageNumber)
    {
        if (userId.HasValue)
            Query.Where(x => x.UserId == userId.Value);
        Query.Include(x => x.CartItems);
        Query.Skip(pageSize * (pageNumber - 1));
        Query.Take(pageSize);
    }
}
