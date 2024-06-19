using System.Threading.Tasks;

namespace WebApiAggregation.Services;

public interface IAggregationServices
{
    Task<string> GetNewsAsync(string newsSearchTerm);
    Task<string> GetWeatherAsync(string weatherSearchTerm);
    Task<string> GetNasaPhotosAsync(string nasaSearchTerm);
}
