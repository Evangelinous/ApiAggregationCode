using ApiAggregation.Models;

namespace ApiAggregation.Services
{
    public interface IUserService
    {
        bool ValidateUser(string username, string password);
        UserDataModel GetUserData(string username);
    }
}
