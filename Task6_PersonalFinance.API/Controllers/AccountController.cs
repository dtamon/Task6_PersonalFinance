using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task6_PersonalFinance.Core.Dto;
using Task6_PersonalFinance.Core.Services.Interfaces;

namespace Task6_PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerDto)
        {
            await _accountService.RegisterUser(registerDto);
            return Ok("Registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn(LoginUserDto loginDto)
        {
            string token = await _accountService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
