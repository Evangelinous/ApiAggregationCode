using ApiAggregation.Models;
using ApiAggregation.Services;
using System.Collections.Generic;
using System.Linq;

namespace WebApiAggregation.Services
{
    public class UserService : IUserService
    {
        // For simplicity, we use a hardcoded user. In a real application, you'd query a database.
        private readonly List<UserDataModel> _users = new List<UserDataModel>
        {
            new UserDataModel
            {
                Username = "testuser",
                FullName = "Test User",
                Email = "testuser@example.com",
                Password = "password" 
            }
        };

        public bool ValidateUser(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public UserDataModel GetUserData(string username)
        {
            return _users.SingleOrDefault(u => u.Username == username);
        }
    }
}
