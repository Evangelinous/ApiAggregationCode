using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ApiAggregation.Models;
using ApiAggregation.Services;

namespace ApiAggregation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(ILogger<AuthController> logger,
                                 IConfiguration configuration,
                                 IUserService userService)
        {
            _logger = logger;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginModel loginModel)
        {
            if (!_userService.ValidateUser(loginModel.Username, loginModel.Password))
            {
                return Unauthorized(new LoginResponseBaseModel<string>("Invalid username or password"));
            }

            var token = GenerateJwtToken(loginModel.Username);

            return Ok(new LoginResponseBaseModel<string>(token));
        }

        [Authorize]
        [HttpGet("GetUserData")]
        public ActionResult GetUserData()
        {
            var username = User.Identity.Name;
            var userData = _userService.GetUserData(username);

            return Ok(new LoginResponseBaseModel<UserDataModel>(userData));
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
