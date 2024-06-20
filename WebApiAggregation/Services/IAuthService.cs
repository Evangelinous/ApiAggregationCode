using System.Collections.Generic;
using WebApiAggregation.Models;

namespace WebApiAggregation.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username, IList<string> roles);
    }
}
