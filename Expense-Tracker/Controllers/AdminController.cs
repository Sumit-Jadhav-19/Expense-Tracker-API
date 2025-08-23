using Expense_Tracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _adminService.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("Category{Id:int}")]
        public async Task<IActionResult> GetCategory(int Id)
        {
            var category = await _adminService.GetByIdAsync(Id);
            return Ok(category);
        }
    }
}
