using ATWebAPI.Facade.Interface;
using EFRepository.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenBusiness _tokenService;
        private readonly ILogger<LoginController> _logger;
        private readonly IUserBusiness _userBusiness;
        public LoginController(ITokenBusiness tokenService, ILogger<LoginController> logger, IUserBusiness userBusiness)
        {
            _tokenService = tokenService;
            _logger = logger;
            _userBusiness = userBusiness;
        }
        [HttpPost]
        [Route("api/[controller]/Get")]
        public async Task<IActionResult> Get(LoginDTO user)
        {
            if (await _userBusiness.ValidateUser(user))
            {
                var useInfo = await _userBusiness.Get(user.UserName);
                string token = _tokenService.GenerateToken(useInfo, new string[] { "admin"});
                return Ok(token);
            }
            //if (await _userBusiness.ValidateUser(user))
            //{
            //    string token = _tokenService.GenerateToken(user, new string[] { "user" });
            //    return Ok(token);
            //}
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
