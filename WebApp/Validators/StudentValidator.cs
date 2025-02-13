using FluentValidation;
using WebApp.Models;

namespace WebApp.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@gmail\.com$").WithMessage("Only @gmail.com emails are allowed.");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.")
                .Length(10).WithMessage("Phone number must be 10 digits.")
                .Matches(@"^\d+$").WithMessage("Phone number must contain only number.");
        }
    }
}