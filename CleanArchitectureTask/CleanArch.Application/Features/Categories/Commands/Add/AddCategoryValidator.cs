using FluentValidation;

namespace CleanArch.Application.Features.Categories.Commands.Add;

public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.");
    }
}

