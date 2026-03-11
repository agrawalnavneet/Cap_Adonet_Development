using app.Services;
using Microsoft.AspNetCore.Mvc;
using app.DTO;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _tokenService;

    public AuthController(JwtTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {

        if (request.Username == "admin" && request.Password == "123")
        {
            var token = _tokenService.GenerateToken(request.Username);

            return Ok(new app.DTO.LoginResponse { Token = token });
        }

        return Unauthorized();
    }
}