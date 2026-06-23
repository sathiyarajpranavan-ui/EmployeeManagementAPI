using EmployeeManagementAPI.Dto;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto dto)
        {
            // Validate user
            if (dto.UserName == "admin" && dto.Password == "admin123")
            {
                var token = _authService.GenerateJwtToken(dto.UserName);
                return Ok(new
                {
                    Token = token
                });
            }

            return Unauthorized();
        }
    }
}