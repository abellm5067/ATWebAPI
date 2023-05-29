using ATWebAPI.Facade.Interface;
using EFRepository.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ATWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenBusiness _tokenService;
        private readonly ILogger<LoginController> _logger;
        private readonly IUserBusiness _userBusiness;
        private readonly ILoginBusiness _loginBusiness;
        public LoginController(ITokenBusiness tokenService, ILogger<LoginController> logger, IUserBusiness userBusiness, ILoginBusiness loginBusiness)
        {
            _tokenService = tokenService;
            _logger = logger;
            _userBusiness = userBusiness;
            _loginBusiness = loginBusiness;
        }
        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> Get(LoginDTO user)
        {
            if (await _userBusiness.ValidateUser(user))
            {
                var useInfo = await _userBusiness.Get(user.UserName);
                string token = _tokenService.GenerateToken(useInfo, new string[] { "admin"});
                return Ok(token);
            }
            return (IActionResult)Results.Unauthorized();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPasswordLink")]
        public async Task<IActionResult> ResetPasswordLink([FromBody]string email)
        {
            return Ok(await _loginBusiness.GenerateResetPasswordLink(email));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            return Ok(await _loginBusiness.Register(userDTO));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromQuery] string token, [FromQuery] string userName, [FromBody] string password)
        {
            await _loginBusiness.UpdatePassword(token, userName, password);
            return Ok("Password updated successfully");
        }
        
    }
}
