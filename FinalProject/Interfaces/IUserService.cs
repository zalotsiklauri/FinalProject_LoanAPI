using FinalProject.Models;
using FinalProject.Services;

namespace FinalProject.Interfaces
{
    public interface IUserService
    {
        User Registration(User user);
        User Login(LoginModel user);
        Loan CreateLoanRequest(Loan loan, int user_id);
        Loan UpdateLoanById(Loan loan, int loan_id, int user_id);
        Loan DeleteLoanById(int loan_id, int user_id);
    }
}
