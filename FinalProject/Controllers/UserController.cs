using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FinalProject.Models;
using FinalProject.Interfaces;
using FinalProject.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using FinalProject.Validator;
using FluentValidation;

namespace FinalProject.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, IOptions<AppSettings> appsettings, ILogger<UserController> logger)
        {
            _service = service;
            _appSettings = appsettings.Value;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("reg")]
        public IActionResult Registration([FromBody] User user)
        {
            try
            {
                _logger.LogInformation("[USER] Register Request");
                var _validation = new RegistrationValidator().Validate(user);
                if (!_validation.IsValid)
                {
                    return BadRequest(new { message = _validation.Errors[0].ErrorMessage });
                }
                var response = _service.Registration(user);
                if (response == null)
                {
                    return BadRequest("Username or Email already exist");
                }
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[USER] Register Request {0}" ,ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {  
            try
            {
                _logger.LogInformation("[USER] Login Request with username - " + user.Username);
                var _validation = new LoginValidator().Validate(user);
                if (!_validation.IsValid)
                {
                    return BadRequest(new { message = _validation.Errors[0].ErrorMessage });
                }
                var _user = _service.Login(user);
                if (_user == null)
                {
                    _logger.LogInformation("[USER] Failed to login username - " + user.Username);

                    return Unauthorized(new { message = "Username or password is incorrect" });
                }

                var token = new Token(_appSettings).GenerateToken(_user);
                _logger.LogInformation("[USER] Success to login username - " + user.Username);
                return Ok(new
                {
                    Username = _user.UserName,
                    Password = _user.Password,
                    Role = _user.Role,
                    Token = token
                });
            }
            catch (System.Exception ex)
            { 
                _logger.LogError("[USER] Loan Request Error {0}", ex.Message);
                return Unauthorized(new { message = ex.Message });
            }
            
        }

        [Authorize(Roles = Role.User )]
        [HttpPost("RequestLoan")]
        public IActionResult CreateLoanRequest([FromBody] Loan loan)
        {  
            try
            {
                var _validation = new LoanValidator().Validate(loan);
                if (!_validation.IsValid)
                {
                    return BadRequest(new { message = _validation.Errors[0].ErrorMessage });
                }
                _logger.LogInformation("[USER] Loan Request");
                int user_id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                var _loan = _service.CreateLoanRequest(loan, user_id);
                _logger.LogInformation("[USER] Loan Request Success");
                return Ok(_loan);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[USER] Loan Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
           
        }

        [Authorize(Roles = Role.User)]
        [HttpPut("UpdateLoan/{id}")]
        public IActionResult UpdateLoanById([FromBody] Loan loan, int id)
        {
            try
            {
                _logger.LogInformation("[USER] LoanUpdate Request");
                int user_id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);

                var _loan = _service.UpdateLoanById(loan, id, user_id);
                _logger.LogInformation("[USER] LoanUpdate Request Success");
                return Ok(_loan);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[USER] LoanUpdate Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            
        }

        [Authorize(Roles = Role.User)]
        [HttpDelete("DeleteLoan/{id}")]
        public IActionResult DeleteLoanById(int id)
        {
            
            try
            {
                _logger.LogInformation("[USER] LoanRemove Request");
                int user_id = int.Parse(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                
                var _loan = _service.DeleteLoanById(id, user_id);
                _logger.LogInformation("[USER] LoanRemove Request Success");
                return Ok(_loan);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(" [USER] LoanRemove Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            
        }

    }
}
