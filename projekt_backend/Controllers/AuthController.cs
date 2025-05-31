using Microsoft.AspNetCore.Mvc;
using projekt_backend.Infrastructure.Persistence;
using projekt_backend.Core.Entities;
using projekt_backend.Services;
using Microsoft.AspNetCore.Authorization;

namespace projekt_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SnacksContext _context;
        private readonly JwtService _jwtService;

        public AuthController(SnacksContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);
            if (dbUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, dbUser.PasswordHash))
                return Unauthorized();

            var token = _jwtService.GenerateToken(user.Username);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("You are authorized!");
        }
    }
}