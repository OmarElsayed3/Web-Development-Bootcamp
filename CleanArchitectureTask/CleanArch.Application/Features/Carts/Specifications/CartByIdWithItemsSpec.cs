using Ardalis.Specification;
using CleanArch.Domain.Models.Carts;

namespace CleanArch.Application.Features.Carts.Specifications;

public class CartByIdWithItemsSpec : Specification<Cart>
{
    public CartByIdWithItemsSpec(Guid cartId)
    {
        Query.Where(x => x.Id == cartId);
        Query.Include(x => x.CartItems);
    }
}

