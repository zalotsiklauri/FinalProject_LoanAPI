using System.Collections.Generic;
using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface IAccountantService
    {
        IEnumerable<User> GetUserList();
        User RemoveUserById(int id);
        Loan RemoveLoanById(int id);
        Loan UpdateLoanStatus(int id, int status);
        User BlockUnblockUserById(int id);
        IEnumerable<Loan> GetLoansByUserId(int id);

    }
}
