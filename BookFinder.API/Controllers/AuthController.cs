using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using BookFinder.API.Dtos;
using BookFinder.API.Models;
using BookFinder.API.Repository;
using BC = BCrypt.Net.BCrypt;
using BookFinder.API.Dtos;
using BookFinder.API.Models;
using BookFinder.API.Repository.Interface;

namespace BookFinder.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var existingUser = await _authRepository.GetUserByEmail(request.Email);
            if (existingUser != null)
                return BadRequest(new { message = "Email already exists" });

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BC.HashPassword(request.Password) 
            };

            await _authRepository.Register(user);
            return Ok(new { message = "User registered successfully" });
        }

        // User login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var dbuser = await _authRepository.GetUserByEmail(request.Email);
            if (dbuser == null || !BC.Verify(request.Password, dbuser.PasswordHash))
                return Unauthorized(new { message = "Invalid email or password" });

            var token = GenerateJwtToken(dbuser);
            var user = new { dbuser.Id,dbuser.Email, dbuser.Name };
            return Ok(new { token, user} );
        }

        // Generate JWT Token
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name) 
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
