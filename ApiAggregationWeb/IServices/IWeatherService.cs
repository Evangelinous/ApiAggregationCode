using System.Threading.Tasks;

namespace ApiAggregation.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync(string city);
    }
}
