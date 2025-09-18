using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Categories;
using CleanArch.Domain.Models.Products;
using FluentValidation;

namespace CleanArch.Application.Features.Products.Commands.Add;

public class AddProductValidator : AbstractValidator<AddProductCommand>
{
    private readonly IReadRepository<Category> _categoryRepository;
    public AddProductValidator(IReadRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Products name is required.")
            .MaximumLength(ProductConstants.ProductNameMaxLengthValue).WithMessage(ProductConstants.ProductNameMaxLengthMessage);

        RuleFor(p => p.CategoryId)
            .NotEmpty()
            .WithMessage("Categories ID is required.");
    }
}