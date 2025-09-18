using FluentValidation;

namespace CleanArch.Application.Features.Carts.Commands.Add;

public class AddCartValidator : AbstractValidator<AddCartCommand>
{
    public AddCartValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
        RuleFor(x => x.CartItems)
            .NotEmpty().WithMessage("Cart must contain at least one item.");
        RuleForEach(x => x.CartItems).ChildRules(cartItem =>
        {
            cartItem.RuleFor(ci => ci.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");
            cartItem.RuleFor(ci => ci.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            cartItem.RuleFor(ci => ci.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        });
    }
}

