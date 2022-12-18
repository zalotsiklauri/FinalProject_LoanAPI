using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "LoanType required")]
        public int LoanType { get; set; }
        [Required(ErrorMessage = "LoanAmount required")]
        public int LoanAmount { get; set; }
        [Required(ErrorMessage = "Currency required")]
        public string Currency { get; set; }
        public DateTime LoanStart { get; set; }
        [Required(ErrorMessage = "LoanPeriod required")]
        public int LoanPeriod { get; set; }
        public int LoanStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
