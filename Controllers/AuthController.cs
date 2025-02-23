using Microsoft.AspNetCore.Mvc;
using SupermercadoAPI.Models;
using SupermercadoAPI.Service;
using System.Threading.Tasks;

namespace SupermercadoAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
                return BadRequest("Datos inválidos");

            var result = await _authService.RegisterUser(user.Username, user.PasswordHash);
            if (!result)
                return BadRequest(new { message = "El usuario ya existe" });

            return Ok(new { message = "Usuario registrado correctamente" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordHash))
                return BadRequest("Datos inválidos");

            var validatedUser = await _authService.ValidateUser(user.Username, user.PasswordHash);
            if (validatedUser == null)
                return Unauthorized(new { message = "Credenciales incorrectas" });

            var token = _jwtService.GenerateToken(validatedUser);
            return Ok(new { token });
        }
    }
}
