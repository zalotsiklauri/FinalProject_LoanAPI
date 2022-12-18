using FluentValidation;
using FinalProject.Models;

namespace FinalProject.Validator
{
    public class LoanValidator : AbstractValidator<Loan>
    {
        //validate loan
        public LoanValidator()
        {
            RuleFor(x => x.LoanAmount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(x => x.LoanType).NotEmpty().InclusiveBetween(1, 3).WithMessage("LoanType must be not empty");
            RuleFor(x => x.LoanPeriod).NotEmpty().InclusiveBetween(1, 60).WithMessage("LoanPeriod must be not empty");
            RuleFor(x => x.Currency).NotEmpty().Must(x => LoanCurrency.Currencies.Contains(x));
        }
    }
}
