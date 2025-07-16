
using Server.Models;
using Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await _userRepository.RegisterAsync(model);
            if (!success)
            {
                _logger.LogWarning("Registration failed for email: {Email}", model.Email);
                return BadRequest("User already exists or registration failed.");
            }
            _logger.LogInformation("User registered successfully: {Email}", model.Email);
            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await _userRepository.LoginAsync(model);
            if (!success)
            {
                _logger.LogWarning("Login failed for email: {Email}", model.Email);
                return Unauthorized("Invalid email or password.");
            }
            _logger.LogInformation("User logged in successfully: {Email}", model.Email);
            return Ok("Login successful.");
        }

    }
}
