using EFRepository.DTO;
using EFRepository.Models;
using EFRepository.Services.Interace;
using Microsoft.EntityFrameworkCore;

namespace EFRepository.Services
{
    public class UserService : IUserService
    {
        public async Task Add(User user)
        {
            if (user == null) throw new ArgumentNullException("user");

            using var context = new ATWebDbContext();
            context.Users.Add(user);
            await context.SaveChangesAsync();

        }
        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("user");
            using var context = new ATWebDbContext();
            User _user = await context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_user is null) throw new Exception("User Not found");
            context.Users.Remove(_user);
            context.SaveChanges();
        }

        public async Task<IList<User>> Get()
        {
            using var context = new ATWebDbContext();
            IEnumerable<User> users = await context.Users.ToListAsync();
            return users.ToList();
        }

        public async Task<User> Get(int id)
        {
            if (id == 0) throw new ArgumentNullException("user");
            using var context = new ATWebDbContext();
            User _user = await context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _user;
        }
        public async Task<string> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException("user");
            using var context = new ATWebDbContext();
            string _userEmail = await context.Users.Where(x => x.Email==email).Select(x=>x.UserName).FirstOrDefaultAsync();
            return _userEmail;
        }
        public async Task<User> Get(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("user");
            using var context = new ATWebDbContext();
            User _user = await context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            return _user;
        }

        public async Task Update(User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            using var context = new ATWebDbContext();
            User userinfo = await context.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
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
            userinfo.PasswordSalt=user.PasswordSalt;
            userinfo.PasswordHash = user.PasswordHash;
            await context.SaveChangesAsync();
        }
    }
}
