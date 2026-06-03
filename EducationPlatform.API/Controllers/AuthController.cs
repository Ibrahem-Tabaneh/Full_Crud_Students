using Azure.Core;
using EducationPlatform.Application.DTOs;
using EducationPlatform.Application.DTOs.Auth;
using EducationPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.Tasks;

namespace EducationPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;
        private readonly ILogger<AuthController> logger;

        public AuthController(IAuthRepository authRepository, ILogger<AuthController> logger)
        {
            this.authRepository = authRepository;
            this.logger = logger;
        }


        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpPost("login")]
        [EnableRateLimiting("AuthLimiter")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            var token = await authRepository.Login(request);

            if (token == null)
            {
                logger.LogWarning("Failed login attempt (email not found). Email={Email}, IP={IP}",
          request.Email,
             ip);
                return Unauthorized("Invalid credentials");
            }

            return Ok(token);
          
        }

        [HttpPost("refresh")]
        [EnableRateLimiting("AuthLimiter")]
        public async Task<ActionResult<TokenResponse>> Refresh([FromBody] RefreshRequest request)
        {
            var result = await authRepository.Refresh(request);

            if (result == null) return Unauthorized();

            return Ok( result);
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            await authRepository.Logout(request);
            return Ok();
        }


    }
}
