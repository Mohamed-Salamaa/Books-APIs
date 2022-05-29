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
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                CreateDate = DateTime.Now,
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
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Email = user.Email;
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _context.SaveChanges();
            }
            return _user;
        }
    }
}
