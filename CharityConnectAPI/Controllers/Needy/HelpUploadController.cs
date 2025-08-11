using CharityConnect.Application.DTOs.User;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CharityConnect.API.Controllers.Needy
{
    [ApiController]
    [Route("api/needy/help-upload")]
    [Authorize(Roles = "Needy")]
    public class HelpUploadController : ControllerBase
    {
        private readonly IHelpUploadService _service;

        public HelpUploadController(IHelpUploadService service)
        {
            _service = service;
        }

        [HttpPost]
        [RequestSizeLimit(5 * 1024 * 1024)] // 5 MB
        public async Task<IActionResult> Submit([FromForm] HelpRequestUploadDTO dto)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var success = await _service.SubmitAsync(userId, dto);
            if (!success) return BadRequest("Failed to submit");

            return Ok(new { message = "Submitted with image" });
        }
    }
}
