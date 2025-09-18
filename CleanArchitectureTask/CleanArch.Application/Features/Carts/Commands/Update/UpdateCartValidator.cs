using FluentValidation;

namespace CleanArch.Application.Features.Carts.Commands.Update;

public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Cart ID is required.");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}

