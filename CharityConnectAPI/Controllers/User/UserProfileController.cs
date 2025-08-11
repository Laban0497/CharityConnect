using CharityConnect.Application.DTOs.User;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CharityConnect.API.Controllers.User
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserService _service;

        public UserProfileController(IUserService service)
        {
            _service = service;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _service.GetProfileAsync(GetUserId());
            return Ok(profile);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] string fullName)
        {
            var success = await _service.UpdateProfileAsync(GetUserId(), fullName);
            if (!success) return NotFound();
            return Ok(new { message = "Profile updated." });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            var result = await _service.ChangePasswordAsync(GetUserId(), dto);
            if (!result) return BadRequest("Current password is incorrect.");
            return Ok(new { message = "Password changed." });
        }
    }
}