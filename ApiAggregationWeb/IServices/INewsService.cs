using System.Threading.Tasks;

namespace ApiAggregation.Services
{
    public interface INewsService
    {
        Task<string> GetNewsAsync(string query);
    }
}
