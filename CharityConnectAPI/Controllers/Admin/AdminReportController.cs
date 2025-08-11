using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/reports")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AdminReportController : ControllerBase
    {
        private readonly IAdminReportService _service;

        public AdminReportController(IAdminReportService service)
        {
            _service = service;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var result = await _service.GetDashboardAsync();
            return Ok(result);
        }
    }
}
