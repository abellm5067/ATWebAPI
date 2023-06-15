using EFRepository.DTO;
using EFRepository.Models;
using EFRepository.Services.Interace;
using Microsoft.EntityFrameworkCore;

namespace EFRepository.Services
{
    //// <summary>
    //// This is service where we manipulate the user
    //// </summary>
    public class UserService : IUserService
    {
        private readonly IStorage<User> _storage;
        public UserService(IStorage<User> storage)
        {
            _storage = storage;
        }

        //// <summary>
        //// Add the user if it has data other wise throw exception
        //// </summary>
        public async Task Add(User user)
        {
            if (user == null) throw new ArgumentNullException("Invalid user info");

            await _storage.Insert(user);
            await _storage.SaveChangesAsync();

        }

        //// <summary>
        //// Delete the user if it has data other wise throw exception
        //// </summary>
        public async Task Delete(int id)
        {
            var seller = await _storage.Get(id);
            if (seller is null) throw new ArgumentNullException("Invalid user info");
            _storage.Delete(seller);
            await _storage.SaveChangesAsync();
        }

        //// <summary>
        //// Get all users
        //// </summary>
        public async Task<IList<User>> Get()
        {
            return await _storage.Get();
        }

        //// <summary>
        //// Get user by id
        //// </summary>
        public async Task<User> Get(int id)
        {
            if (id == 0) throw new ArgumentNullException("user");

            return await _storage.Get(id);
        }

        //// <summary>
        //// Get user by email
        //// </summary>
        public async Task<string> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("user");

            using var context = new ATWebDbContext();
            string _userEmail = await context.Users.Where(x => x.Email == email).Select(x => x.UserName).FirstOrDefaultAsync();
            return _userEmail;
        }

        //// <summary>
        //// Get user by username
        //// </summary>
        public async Task<User> Get(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("user");

            using var context = new ATWebDbContext();
            User _user = await context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            return _user;
        }

        //// <summary>
        //// update user by email
        //// </summary>
        public async Task Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");

            User userinfo = await _storage.Get(user.Id);
            if (userinfo is null) throw new Exception("User Not found");
            userinfo.Address = user.Address;
            userinfo.Address2 = user.Address2;
            userinfo.AlternateContact = user.AlternateContact;
            userinfo.City = user.City;
            userinfo.Contact = user.Contact;
            userinfo.CreatedDate = user.CreatedDate;
            userinfo.Email = user.Email;
            userinfo.FirstName = user.FirstName;
            userinfo.Gender = user.Gender;
            userinfo.IsActive = user.IsActive;
            userinfo.LastName = user.LastName;
            userinfo.UserName = user.UserName;
            userinfo.MidleNameName = user.MidleNameName;
            userinfo.State = user.State;
            userinfo.Zip = user.Zip;
            userinfo.PasswordSalt = user.PasswordSalt;
            userinfo.PasswordHash = user.PasswordHash;
            _storage.Update(userinfo);
            await _storage.SaveChangesAsync();
        }
    }
}
