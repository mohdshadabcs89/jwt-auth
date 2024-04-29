using jwt_token.Auth;
using jwt_token.Model.JwtRequest;
using jwt_token.Model.JwtResponse;
using Microsoft.AspNetCore.Mvc;

namespace jwt_token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IGenerateJwtToken _jwtToken;
        public LoginController(IGenerateJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
        }
        [Route("token")]
        [HttpPost]
        public IActionResult Login(JwtRequest jwtRequest)
        {
            JwtResponse tokenResponse = new();
            tokenResponse = _jwtToken.GenerateTokenAsync(jwtRequest);
            if (tokenResponse.Status == StatusCodes.Status200OK)
            {
                return Ok(tokenResponse);
            }
            return Unauthorized();
        }
    }
}
