using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils.Auth.Entities.Helpers;
using Utils.Auth.Entities.Services;

namespace Utils.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return StatusCode(StatusCodes.Status400BadRequest, $"{result.Message}");

            return Ok(result);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authService.LoginAsync(model);

            if (!result.IsAuthenticated)
                return StatusCode(StatusCodes.Status400BadRequest, $"{result.Message}");

            return Ok(result);
        }
    }
}
