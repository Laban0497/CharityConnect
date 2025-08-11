using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.API.Controllers.Common
{
    [ApiController]
    [Route("api/upload")]
    [Authorize]
    public class UploadController : ControllerBase
    {
        private readonly IFileService _fileService;

        public UploadController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var url = await _fileService.UploadAsync(file);
            return Ok(new { url });
        }
    }
}
