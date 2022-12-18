using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;
using FinalProject.Interfaces;
using FinalProject.Helper;
using System;

namespace FinalProject.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;

        }
        public User Registration(User user)
        {
            var isExist = _context.User.Where(x => x.Email == user.Email || x.UserName == user.UserName).FirstOrDefault();
            if (isExist != null)
            {
                return null;
            }
            user.Role = Role.User;
            user.IsBlocked = false;
            user.Password = Hasher.HashMD5(user.Password);
            user.Loans = new List<Loan>() { };
            _context.User.Add(user);
            _context.SaveChanges();
            
            return user;
        }
        public User Login(LoginModel user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return null;
            var _user = _context.User.FirstOrDefault(x => x.UserName == user.Username);
            if (_user == null)
                return null;
            if (Hasher.HashMD5(user.Password) != _user.Password)
                return null;
            return _user;
        }
        public Loan CreateLoanRequest(Loan loan, int user_id)
        {
            var _user = _context.User.SingleOrDefault(x => x.Id == user_id);
            if (_user == null)
                return null;
            if (_user.IsBlocked == UserStatus.Blocked)
            {
                return null;
            }
            loan.UserId = user_id;
            loan.LoanStatus = LoanStatus.Pending;
            loan.LoanStart = DateTime.Now;
            _context.Loan.Add(loan);
            _context.SaveChanges();
            return loan;
        }
        
        public Loan UpdateLoanById(Loan loan, int loan_id, int user_id)
        {
            Loan _loan = _context.Loan.SingleOrDefault(x => x.Id == loan_id);
            if (_loan == null)
                return null;
            if (_loan.UserId != user_id)
                return null;
            if (_loan.LoanStatus == LoanStatus.Approved || 
                _loan.LoanStatus == LoanStatus.Rejected)
            {
                return null;
            }
            _loan.LoanType = loan.LoanType;
            _loan.LoanAmount = loan.LoanAmount;
            _loan.Currency = loan.Currency;
            _loan.LoanPeriod = loan.LoanPeriod;

            _context.Loan.Update(_loan);
            _context.SaveChanges();


            return _loan;
        }

        public Loan DeleteLoanById(int loan_id, int user_id)
        {
            Loan _loan = _context.Loan.SingleOrDefault(x => x.Id == loan_id);
            if (_loan == null)
                return null;
            if (_loan.UserId != user_id)
                return null;
            if (_loan.LoanStatus == LoanStatus.Approved ||
                _loan.LoanStatus == LoanStatus.Rejected)
                return null;
            
            _context.Loan.Remove(_loan);
            _context.SaveChanges();
            return _loan;
        }
    }
}
