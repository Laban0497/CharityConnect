using CharityConnect.Application.DTOs.Auth;
using CharityConnect.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.API.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(new { token });
        }

        [HttpGet("me")]
        public IActionResult Me() =>
            Ok(new { message = "You are authenticated", user = User.Identity?.Name });
    }
}
