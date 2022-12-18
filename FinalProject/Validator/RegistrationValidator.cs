using FluentValidation;
using FinalProject.Models;

namespace FinalProject.Validator
{
    public class RegistrationValidator: AbstractValidator<User>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Password).MaximumLength(50).MinimumLength(5).NotEmpty().WithMessage("Password must be less than 50 characters");
            RuleFor(x => x.UserName).MaximumLength(50).MinimumLength(5).NotEmpty().WithMessage("UserName must be less than 50 characters");
            RuleFor(x => x.Age).InclusiveBetween(18, 100).WithMessage("Age must be between 18 and 100");
            RuleFor(x => x.Salary).InclusiveBetween(100, 100000).WithMessage("Salary must be between 100 and 100000");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email must be valid");
            RuleFor(x => x.FirstName).MaximumLength(50).MinimumLength(3).NotEmpty().WithMessage("FirstName must be less than 50 characters");
            RuleFor(x => x.LastName).MaximumLength(50).MinimumLength(3).NotEmpty().WithMessage("LastName must be less than 50 characters");
        }
    }
}
