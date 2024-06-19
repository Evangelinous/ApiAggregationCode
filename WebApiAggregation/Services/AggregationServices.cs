using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using WebApiAggregation.Services;
using static System.Net.WebRequestMethods;

namespace ApiAggregation.Services
{
    public class AggregationServices : IAggregationServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKeyNewsApi;
        private readonly string _apiKeyOpenWeatherMap;
        private readonly string _apiKeyNasaApi;

        public AggregationServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKeyNewsApi = configuration["NewsApi:ApiKey"];
            _apiKeyOpenWeatherMap = configuration["OpenWeatherMap:ApiKey"];
            _apiKeyNasaApi = configuration["NasaApi:ApiKey"];
        }

        public async Task<string> GetNewsAsync(string newsSearchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://newsapi.org/v2/everything?q={newsSearchTerm}&apiKey={_apiKeyNewsApi}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> GetWeatherAsync(string weatherSearchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={weatherSearchTerm}&appid={_apiKeyOpenWeatherMap}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> GetNasaPhotosAsync(string nasaSearchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://images-api.nasa.gov/search?q={nasaSearchTerm}&media_type=image"); response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
