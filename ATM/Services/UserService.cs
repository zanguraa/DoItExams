using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new List<User>();

        public User RegisterUser(string username)
        {
            var newUser = new User(username);
            users.Add(newUser);
            return newUser;
        }

        public User GetUserById(Guid userId)
        {
            return users.FirstOrDefault(user => user.UserId == userId);
        }
    }
}
