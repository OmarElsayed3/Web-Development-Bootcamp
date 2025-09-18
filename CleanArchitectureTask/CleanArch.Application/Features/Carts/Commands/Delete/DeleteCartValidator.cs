using FluentValidation;

namespace CleanArch.Application.Features.Carts.Commands.Delete;

public class DeleteCartValidator : AbstractValidator<DeleteCartCommand>
{
    public DeleteCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Cart ID is required.");
    }
}

