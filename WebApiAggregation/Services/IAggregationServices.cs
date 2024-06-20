using System.Threading.Tasks;
using WebApiAggregation.Responses;

namespace WebApiAggregation.Services;

public interface IAggregationServices
{
    Task<NewsResponse> GetNewsAsync(string newsSearchTerm, int pageSize);
    Task<WeatherResponse> GetWeatherAsync(string weatherSearchTerm);
    Task<NasaResponse> GetNasaPhotosAsync(string nasaSearchTerm, int pageSize);
}
