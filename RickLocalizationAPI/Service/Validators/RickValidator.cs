using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class RickValidator : AbstractValidator<Rick>
    {
        public RickValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.Age)
                .NotEmpty().WithMessage("Please an age.")
                .NotNull().WithMessage("Please an age.");

            RuleFor(c => c.Occupation)
                .NotEmpty().WithMessage("Please enter the occupation.")
                .NotNull().WithMessage("Please enter the occupation.");
        }
    }
}
