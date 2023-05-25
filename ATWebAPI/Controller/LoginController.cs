using ATWebAPI.Models;
using ATWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(ITokenService tokenService, ILogger<LoginController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }
        [HttpPost]
        [Route("api/[controller]/GetToken")]
        public async Task<IActionResult> GetToken(User user)
        {
            _logger.LogInformation("Seri Log is Working");
            if (user is not null && user.UserName == "Anil" && user.Password == "admin")
            {
                string token = _tokenService.GenerateToken(user,new string[] { "admin"});
                return Ok(token);
            }
            if (user is not null && user.UserName == "Anil" && user.Password == "user")
            {
                string token = _tokenService.GenerateToken(user, new string[] { "user" });
                return Ok(token);
            }
            return (IActionResult)Results.Unauthorized();
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("api/[controller]/GetDetails")]
        public async Task<IActionResult> GetDetails()
        {
            return Ok("Please enter details");
        }
    }
}
