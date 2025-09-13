using FluentValidation;
using Task_3.Features.StudentCourse.Command.Models;

namespace Task_3.Features.StudentCourse.Command.Validators
{
    public class StudentCourseValidator : AbstractValidator<StudentCourseDto>
    {
        public StudentCourseValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("StudentId must be greater than zero.");

            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("CourseId must be greater than zero.");
        }
    }
}

