using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "FirstName required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Age required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Salary required")]
        public int Salary { get; set; }
        public bool IsBlocked { get; set; } 
        public string Role { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
