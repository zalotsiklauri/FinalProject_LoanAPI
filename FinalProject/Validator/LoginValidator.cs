using FluentValidation;
using FinalProject.Models;
namespace FinalProject.Validator
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Password).MaximumLength(50).MinimumLength(5).NotEmpty().WithMessage("Password must be less than 50 characters");
            RuleFor(x => x.Username).MaximumLength(50).MinimumLength(5).NotEmpty().WithMessage("UserName must be less than 50 characters");
        }
    }
}
