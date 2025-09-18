using FluentValidation;

namespace CleanArch.Application.Features.Products.Queries.GetById;

public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdValidator()
    {
         RuleFor(x => x.Id).NotEmpty();
    }
}