using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebApiAggregation.Models;
using WebApiAggregation.Services;

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
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger,
                                 IConfiguration configuration,
                                 IUserService userService,
                                 IAuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _userService = userService;
            _authService = authService; 
        }

        /// <summary>
        /// Authenticates the user and returns a JWT token if the credentials are valid.
        /// </summary>
        /// <param name="loginModel">The login model containing the username and password.</param>
        /// <returns>An IActionResult containing the JWT token if authentication is successful.</returns>
        /// <response code="200">Returns the JWT token.</response>
        /// <response code="401">If the credentials are invalid.</response>
        [HttpGet("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {   
            var user = _userService.ValidateUser(loginModel.Username, loginModel.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _authService.GenerateJwtToken(user.UserName, user.Roles);
            return Ok(new { token });
        }
    }
}

