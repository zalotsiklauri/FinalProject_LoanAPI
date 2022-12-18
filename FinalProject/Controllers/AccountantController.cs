using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FinalProject.Models;
using FinalProject.Helper;
using FinalProject.Interfaces;

namespace FinalProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountantController : Controller
    {
        private readonly IAccountantService _service;
        private readonly ILogger<AccountantController> _logger;

        public AccountantController(IAccountantService service, ILogger<AccountantController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        [Authorize(Roles = Role.Accountant)]
        [HttpGet("GetUserList")]
        public IActionResult GetUserList()
        {
            try
            {
                _logger.LogInformation("[Accountant] GetUserList Request");
                var users = _service.GetUserList();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[Accountant] UpdateLoanStatus Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            
        }
        
        [Authorize(Roles = Role.Accountant)]
        [HttpDelete("RemoveUserById/{id}")]
        public IActionResult RemoveUserById(int id)
        {
            try
            {
                _logger.LogInformation("[Accountant] RemoveUserById Request");
                var user = _service.RemoveUserById(id);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[Accountant] UpdateLoanStatus Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            
        }

        [Authorize(Roles = Role.Accountant)]
        [HttpDelete("RemoveLoanById/{id}")]
        public IActionResult RemoveLoanById(int id)
        {
            try
            {
                _logger.LogInformation("[Accountant] RemoveLoanById Request");
                var loan = _service.RemoveLoanById(id);
                return Ok(loan);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[Accountant] UpdateLoanStatus Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
           
        }

        [Authorize(Roles = Role.Accountant)]
        [HttpPut("UpdateLoanStatus/{id}/{status}")]
        public IActionResult UpdateLoanStatus(int id, int status)
        {
            try
            {
                _logger.LogInformation("[Accountant] UpdateLoanStatus Request");
                var loan = _service.UpdateLoanStatus(id, status);
                return Ok(loan);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[Accountant] UpdateLoanStatus Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            
        }

        [Authorize(Roles = Role.Accountant)]
        [HttpPut("BlockUnblockUserById/{id}")]
        public IActionResult BlockUnblockUserById(int id)
        {
            try
            {
                _logger.LogInformation("[Accountant] BlockUnblockUserById Request");
                var user = _service.BlockUnblockUserById(id);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[Accountant] BlockUnblockUserById Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }

        }

        [Authorize(Roles = Role.Accountant)]
        [HttpPut("GetLoansByUserId/{id}")]
        public IActionResult GetLoansByUserId(int id)
        {
            try
            {
                _logger.LogInformation("[Accountant] GetLoansByUserId Request");
                var loans = _service.GetLoansByUserId(id);
                return Ok(loans);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("[Accountant] GetLoansByUserId Request Error {0}", ex.Message);
                return BadRequest(new { message = ex.Message });
            }

        }

    }
}
