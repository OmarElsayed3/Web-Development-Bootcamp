namespace Task_3.Features.Course.Command.Validators
{
    public class CourseValidator : AbstractValidator<CourseDto>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Course name is required.")
                .MaximumLength(100).WithMessage("Course name must not exceed 100 characters.");

            RuleFor(x => x.Hours)
                .GreaterThan(0).WithMessage("Course hours must be greater than zero.");
        }
    }
}

