using ATWebAPI.Facade.Interface;
using AutoMapper;
using EFRepository.DTO;
using EFRepository.Models;
using EFRepository.Services.Interace;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using User = EFRepository.Models.User;

namespace ATWebAPI.Facade
{
    public class UserBusiness : IUserBusiness
    {
        private IMapper _mapper;
        private IUserService _userService;
        public UserBusiness(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task Add(UserDTO user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException("user");
                var userInfo = _mapper.Map<UserDTO, User>(user);
                userInfo.PasswordSalt = ATSingleton.Instance.GenerateSalt();
                userInfo.PasswordHash = ATSingleton.Instance.ComputeHash(user.Password, userInfo.PasswordSalt, 3);
                await _userService.Add(userInfo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("user");
            await _userService.Delete(id);
        }

        public async Task<IList<UserDTO>> Get()
        {
            var get = await _userService.Get();
            var users = (from g in get
                         select new UserDTO
                         {
                             Id = g.Id,
                             Address = g.Address,
                             Address2 = g.Address2,
                             AlternateContact = g.AlternateContact,
                             City = g.City,
                             Contact = g.Contact,
                             CreatedDate = g.CreatedDate,
                             Email = g.Email,
                             FirstName = g.FirstName,
                             Gender = g.Gender,
                             IsActive = g.IsActive,
                             LastName = g.LastName,
                             UserName = g.UserName,
                MidleNameName = g.MidleNameName,
                             State = g.State,
                             Zip = g.Zip
                         });
            return users.ToList();
        }

        public async Task<UserDTO> Get(int id)
        {
            var get = await _userService.Get(id);
            var user = new UserDTO
            {
                Id = get.Id,
                Address = get.Address,
                Address2 = get.Address2,
                AlternateContact = get.AlternateContact,
                City = get.City,
                Contact = get.Contact,
                CreatedDate = get.CreatedDate,
                Email = get.Email,
                FirstName = get.FirstName,
                Gender = get.Gender,
                IsActive = get.IsActive,
                LastName = get.LastName,
                UserName = get.UserName,
                MidleNameName = get.MidleNameName,
                State = get.State,
                Zip = get.Zip
            };
            return user;
        }

        public async Task<UserDTO> Get(string userName)
        {
            try
            {
                var get = await _userService.Get(userName);
                var user = new UserDTO
                {
                    Id = get.Id,
                    Address = get.Address,
                    Address2 = get.Address2,
                    AlternateContact = get.AlternateContact,
                    City = get.City,
                    Contact = get.Contact,
                    CreatedDate = get.CreatedDate,
                    Email = get.Email,
                    FirstName = get.FirstName,
                    Gender = get.Gender,
                    IsActive = get.IsActive,
                    LastName = get.LastName,
                    UserName = get.UserName,
                    MidleNameName = get.MidleNameName,
                    State = get.State,
                    Zip = get.Zip
                };
                return user;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task Update(UserDTO user)
        {
            try
            {
                if (user == null) throw new ArgumentNullException("user");
                var userInfo = _mapper.Map<UserDTO, User>(user);
                await _userService.Update(userInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> ValidateUser(LoginDTO loginDTO)
        {
            try
            {
                if (loginDTO == null) throw new ArgumentNullException("Please enter valid details");
                var user = await _userService.Get(loginDTO.UserName ?? "");
                string? passwordHash = ATSingleton.Instance.ComputeHash(loginDTO.Password, user.PasswordSalt, 3)??"";
                if (user.PasswordHash != passwordHash) throw new Exception("Username or password did not match.");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
