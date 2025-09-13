using FluentValidation;
using Task_3.Features.Student.Command.Models;

namespace Task_3.Features.Student.Command.Validators
{
    public class StudentValidator : AbstractValidator<StudentDto>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Student name is required.")
                .MaximumLength(100).WithMessage("Student name must not exceed 100 characters.");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Student age must be greater than zero.");
        }
    }
}

