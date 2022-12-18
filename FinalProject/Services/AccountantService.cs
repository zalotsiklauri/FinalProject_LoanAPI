using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;
using FinalProject.Interfaces;

namespace FinalProject.Services
{
    public class AccountantService : IAccountantService
    {
        private readonly UserContext _context;

        public AccountantService(UserContext context)
        {
            _context = context;
        }
        
        public IEnumerable<User> GetUserList()
        {
            return _context.User;
        }
        public User RemoveUserById(int id)
        {
            var user = _context.User.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(user);
            _context.SaveChanges();
            return user;
        }
        
        public Loan RemoveLoanById(int id)
        {
            var loan = _context.Loan.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(loan);
            _context.SaveChanges();
            return loan;
        }
        
        public Loan UpdateLoanStatus(int id, int status)
        {
            var loan = _context.Loan.Where(x => x.Id == id).FirstOrDefault();
            loan.LoanStatus = status;
            _context.Loan.Update(loan);
            _context.SaveChanges();
            return loan;
        }

        public User BlockUnblockUserById(int id)
        {
            var user = _context.User.Where(x => x.Id == id).FirstOrDefault();
            if (user.IsBlocked)
            {
                user.IsBlocked = false;
            }
            else
            {
                user.IsBlocked = true;
            }
            _context.User.Update(user);
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<Loan> GetLoansByUserId(int id)
        {
            var loans = _context.Loan.Where(x => x.UserId == id);
            return loans;
        }
}
}
