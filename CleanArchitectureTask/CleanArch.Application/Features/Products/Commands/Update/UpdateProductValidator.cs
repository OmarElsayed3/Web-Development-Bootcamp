using FluentValidation;

namespace CleanArch.Application.Features.Products.Commands.Update;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.");
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Category ID is required.");
    }
}