using WebApiAggregation.Models;

namespace WebApiAggregation.Services
{
    public interface IUserService
    {
        UserDataModel ValidateUser(string username, string password);
    }
}
