using ATWebAPI.Facade.Interface;
using EFRepository.DTO;
using EFRepository.Models;
using EFRepository.Services.Interace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserBusiness userBusiness, ILogger<UserController> logger)
        {
            _userBusiness = userBusiness;
            _logger = logger;

        }
        [HttpGet]
        [Route("api/[controller]/Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userBusiness.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace, ex.InnerException);
                return Ok(Results.BadRequest);
            }

        }
        [HttpGet]
        [Route("api/[controller]/Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var users = await _userBusiness.GetUser(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace, ex.InnerException);
                return Ok(Results.BadRequest);
            }

        }
        [HttpGet]
        [Route("api/[controller]/Get/{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            try
            {
                var users = await _userBusiness.GetUser(userName);
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace, ex.InnerException);
                return Ok(Results.BadRequest);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDTO user)
        {
            try
            {
                await _userBusiness.Add(user);
                return Ok("Inserted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace, ex.InnerException);
                return Ok(Results.BadRequest);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            try
            {
                await _userBusiness.Update(user);
                return Ok("Inserted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace, ex.InnerException);
                return Ok(Results.BadRequest);
            }

        }
    }
}
