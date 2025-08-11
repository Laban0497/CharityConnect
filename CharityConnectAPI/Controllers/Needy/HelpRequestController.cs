using CharityConnect.Application.Common;
using CharityConnect.Application.DTOs.Help;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CharityConnect.Application.Common;

namespace CharityConnect.API.Controllers.Needy
{
    [ApiController]
    [Route("api/needy/help")]
    [Authorize(Roles = "Needy")]
    public class HelpRequestController : ControllerBase
    {
        private readonly IHelpRequestService _service;

        public HelpRequestController(IHelpRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Submit(HelpRequestDTO dto)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _service.CreateRequestAsync(userId, dto);
            return Ok(ApiResponse<string>.Ok("Help request submitted"));

        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyRequests()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _service.GetMyRequestsAsync(userId);

            return Ok(ApiResponse<List<HelpRequestDTO>>.Ok(result));
        }
    }
}
