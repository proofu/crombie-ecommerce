using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoeCommerce.DTOs;
using ProyectoeCommerce.Services;

namespace ProyectoeCommerce.Controllers
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
            public async Task<ActionResult<AuthResponseDto>> Register(RegisterRequestDto request)
            {
                try
                {
                    var response = await _authService.Register(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            [HttpPost("login")]
            public async Task<ActionResult<AuthResponseDto>> Login(AuthRequestDto request)
            {
                try
                {
                    var response = await _authService.Login(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
        }
}
