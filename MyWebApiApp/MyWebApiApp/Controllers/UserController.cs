using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using MyWebApiApp.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly MyDbContext _context;
        private readonly AppSettings _appSettings;

        public UserController(MyDbContext context, IUserRepository userRepository, IOptionsMonitor<AppSettings> optionsMonitor) {
            _userRepository = userRepository;
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserbyId(Guid id) {
            return Ok(_userRepository.GetById(id));
        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model) {
            var user = _context.Users.SingleOrDefault(p => p.user_name == model.user_name);
            if (user.password != model.password) {
            }
            if (user == null) //không đúng
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            //cấp token

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userRepository.Delete(id);
            return NoContent();
        }


        private string GenerateToken(User nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, nguoiDung.user_name),
                    new Claim("UserName", nguoiDung.user_name),
                    new Claim("Id", nguoiDung.user_id.ToString()),

                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
