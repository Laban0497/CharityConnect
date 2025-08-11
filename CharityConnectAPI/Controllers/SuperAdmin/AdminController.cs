using CharityConnect.Application.DTOs.Admin;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.API.Controllers
{
    [Route("api/superadmin/admins")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public SuperAdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminDTO dto)
        {
            await _adminService.AddAdminAsync(dto);
            return Ok(new { message = "Admin created successfully" });
        }

        [HttpDelete("{id}")]  
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var result = await _adminService.DeleteAdminAsync(id);
            if (!result) return NotFound("Admin not found");
            return Ok("Admin deleted successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var admins = await _adminService.GetAdminsAsync();
            return Ok(admins);
        }
    }
}
