using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjcet.DTO;
using SchoolProjcet.Models;
using SchoolProjcet.Repo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SchoolProjcet.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork _UOW;
        private IConfiguration _CONF;

        public AuthController(IUnitOfWork uOW, IConfiguration cONF)
        {
            _UOW = uOW;
            _CONF = cONF;
        }

        [HttpPost("Login")]
        public IActionResult Login (UserDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.UserName) || string.IsNullOrEmpty(dto.Password))
                return BadRequest("Username and password are required.");

            var user = _UOW.Users.GetUserByUserName(dto.UserName);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            if (!VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid username or password.");

            var token = GenerateToken(user);
            return Ok(new { token });
        }
        [HttpPost("Register")]
        public IActionResult Register(UserDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.UserName) || string.IsNullOrEmpty(dto.Password))
                return BadRequest("Username and password are required.");

            var exists = _UOW.Users.GetUserByUserName(dto.UserName);
            if (exists != null)
                return Conflict("Username already exists.");

            var user = new User
            {
                UserName = dto.UserName,
                Role = "User"
            };

            // Use ASP.NET Core's PasswordHasher for simpler secure hashing
            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, dto.Password);

            _UOW.Users.Create(user);
            _UOW.Save();
            return CreatedAtAction(null, new { user.UserId, user.UserName });
        }
        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role)

            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_CONF["JWT:Key"]));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _CONF["JWT:Issuer"],
                audience: _CONF["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static bool VerifyPassword(string password, string storedHash, User user = null)
        {
            try
            {
                var hasher = new PasswordHasher<User>();
                var verificationResult = hasher.VerifyHashedPassword(user ?? new User(), storedHash, password);
                return verificationResult == PasswordVerificationResult.Success || verificationResult == PasswordVerificationResult.SuccessRehashNeeded;
            }
            catch
            {
                return false;
            }
        }
    }
}
