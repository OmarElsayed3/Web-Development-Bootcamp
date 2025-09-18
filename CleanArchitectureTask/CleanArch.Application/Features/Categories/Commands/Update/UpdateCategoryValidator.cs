using FluentValidation;

namespace CleanArch.Application.Features.Categories.Commands.Update;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.");
    }
}

