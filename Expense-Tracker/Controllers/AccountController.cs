using Expense_Tracker.Application.Interfaces;
using Expense_Tracker.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _userService.GetAllAsync();
            return Ok(products);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userService.LoginAsync(model);
            if (result == "Invalid credentials")
                return Unauthorized(result);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> Refresh(TokenModel tokenModel)
        {
            var result = await _userService.RefreshTokenAsync(tokenModel);
            return Ok(result);
        }
    }
}
