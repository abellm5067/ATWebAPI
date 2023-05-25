using ATWebAPI.Facade.Interface;
using ATWebAPI.Models;
using AutoMapper;
using EFRepository.DTO;
using EFRepository.Models;
using EFRepository.Services.Interace;
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

        public async Task<IList<UserDTO>> GetAll()
        {
            var get = await _userService.GetAll();
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
                             UserName = g.UserName
                MidleNameName = g.MidleNameName,
                             State = g.State,
                             Zip = g.Zip
                         });
            return users.ToList();
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var get = await _userService.GetUser(id);
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

        public async Task<UserDTO> GetUser(string userName)
        {
            try
            {
                var get = await _userService.GetUser(userName);
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
            catch (Exception ex)
            {

                throw ex;
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
            throw new NotImplementedException();
        }
    }
}
