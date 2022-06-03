using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class UsersService
    {
        private AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        // Add New User to DB
        public void AddNewUser(UserInfoVM user)
        {
            var _user = new UserInfo()
            {    
                UserName = user.UserName,
                Password = user.Password,
                EmailAddress = user.EmailAddress,
                GivenName = user.GivenName,
                SurName = user.SurName,
                Role = user.Role
            };
            _context.UserInfos.Add(_user);
            _context.SaveChanges();
        }

        // Get All Users from DB
        public List<UserInfo> GetAllUsers()
        {
            return _context.UserInfos.ToList();
        }

        // Get User By ID from DB
        public UserInfo GetUserById(int userId)
        {
            var _user = _context.UserInfos.FirstOrDefault(n => n.Id == userId);
            return _user;
        }
        public UserInfo GetUserByName(string userName, string pass)
        {
            var _user = _context.UserInfos.FirstOrDefault(n => n.UserName.ToLower() == userName.ToLower() && n.Password == pass);
            return _user;
        }

        // Delete User By ID from DB
        public void DeleteUserById(int userId)
        {
            var _user = _context.UserInfos.FirstOrDefault(n => n.Id == userId);
            if (_user != null)
            {
                _context.UserInfos.Remove(_user);
                _context.SaveChanges();
            }
        }
        // Update User By ID into DB
        public UserInfo UpdateUserById(int userId, UserInfoVM user)
        {
            var _user = _context.UserInfos.FirstOrDefault(user => user.Id == userId);
            if (_user != null)
            {
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.EmailAddress = user.EmailAddress;
                _user.GivenName = user.GivenName;
                _user.SurName = user.SurName;
                _user.Role = user.Role;
                _context.SaveChanges();
            }
            return _user;
        }
    }
}
