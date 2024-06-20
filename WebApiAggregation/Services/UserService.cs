using System.Collections.Generic;
using System.Linq;
using WebApiAggregation.Models;
using WebApiAggregation.Services;

public class UserService : IUserService
{
    private readonly List<UserDataModel> _users = new List<UserDataModel>
    {
        new UserDataModel { UserName = "user1", Roles = new List<string> { "User" } },
        new UserDataModel { UserName = "admin", Roles = new List<string> { "Admin" } }
    };

    private readonly Dictionary<string, string> _userPasswords = new Dictionary<string, string>
    {
        { "user1", "password1" },
        { "admin", "password2" }
    };

    public UserDataModel ValidateUser(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.UserName == username);

        if (user != null && _userPasswords.ContainsKey(username) && _userPasswords[username] == password)
        {
            return user;
        }

        return null;
    }
}
