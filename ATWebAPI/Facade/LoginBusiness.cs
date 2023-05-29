using ATWebAPI.Facade.Interface;
using AutoMapper;
using EFRepository.DTO;
using EFRepository.Models;
using EFRepository.Services.Interace;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;

namespace ATWebAPI.Facade
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;
        public LoginBusiness(IMemoryCache memoryCache, IConfiguration configuration, IUserService userService, IMapper mapper, IUserBusiness userBusiness)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;
            _userService = userService;
            _mapper = mapper;
            _userBusiness = userBusiness;
        }

        private void StoreToken(string key, string token, TimeSpan expirationTime)
        {
            _memoryCache.Set(key, token, expirationTime);
        }
        
        private bool ValidateToken(string guid, string userName)
        {
            if (guid == RetrieveToken(userName))
                return true;
            throw new Exception("Link got expired");
        }
        public async Task<bool> UpdatePassword(string token, string userName, string password)
        {
            ValidateToken(token, userName);
            var userInfo = await _userService.Get(userName);
            userInfo.PasswordSalt = ATSingleton.Instance.GenerateSalt();
            userInfo.PasswordHash = ATSingleton.Instance.ComputeHash(password, userInfo.PasswordSalt, 3);
            await _userService.Update(userInfo);
            _memoryCache.Set(userName,
                token, DateTime.Now);
            return true;
        }
        public async Task<bool> Register(UserDTO userDTO)
        {
            await _userBusiness.Add(userDTO);
            return true;
        }
        private string RetrieveToken(string key)
        {
            return _memoryCache.Get<string>(key);
        }
        public async Task<string> GenerateResetPasswordLink(string email)
        {
            Guid token = Guid.NewGuid();
            string userName = await _userService.GetUserByEmail(email);
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("User not found");
            }
            _memoryCache.Set(userName, token.ToString(), DateTime.Now.AddMinutes(30));
            List<string> toEmail = new List<string> { 
                email
            };
            ATSingleton.Instance.SendEmail(toEmail, "Reset Password", $"{_configuration["baseUrl"]}?token={token}&userName={userName}");
            return "Link sent successfully";
        }
    }
}