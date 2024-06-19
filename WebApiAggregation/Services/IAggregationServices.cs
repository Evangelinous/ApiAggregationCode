using System.Threading.Tasks;

namespace WebApiAggregation.Services;

public interface IAggregationServices
{
    Task<string> GetNewsAsync(string newsSearchTerm, int pageSize);
    Task<string> GetWeatherAsync(string weatherSearchTerm);
    Task<string> GetNasaPhotosAsync(string nasaSearchTerm, int pageSize);
}
