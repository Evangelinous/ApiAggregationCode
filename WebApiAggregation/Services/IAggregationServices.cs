using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiAggregation.Responses;

namespace WebApiAggregation.Services;

public interface IAggregationServices
{
    Task<WeatherResponse> GetWeatherAsync(string weatherSearchTerm);
    Task<NasaResponse> GetNasaPhotosAsync(string nasaSearchTerm, int pageSize);
    Task<List<BreweryResponse>> GetBreweriesAsync(string brewerySearchTerm, int pageSize);

}
