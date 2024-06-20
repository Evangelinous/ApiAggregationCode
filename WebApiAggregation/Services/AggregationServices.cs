using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApiAggregation.Responses;
using WebApiAggregation.Services;

namespace ApiAggregation.Services
{
    public class AggregationServices : IAggregationServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKeyNewsApi;
        private readonly string _apiKeyOpenWeatherMap;

        public AggregationServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKeyNewsApi = configuration["NewsApi:ApiKey"];
            _apiKeyOpenWeatherMap = configuration["OpenWeatherMap:ApiKey"];
        }

        public async Task<NewsResponse> GetNewsAsync(string newsSearchTerm, int pageSize)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://newsapi.org/v2/everything?q={newsSearchTerm}&pageSize={pageSize}&apiKey={_apiKeyNewsApi}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NewsResponse>(content);
            }
            catch (HttpRequestException ex)
            {
                //SystemExceptions.ThrowHttpRequestException(ErrorCodes.HttpRequestException, ex.Message);
                throw ex;
            }
        }

        public async Task<WeatherResponse> GetWeatherAsync(string weatherSearchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={weatherSearchTerm}&appid={_apiKeyOpenWeatherMap}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(content);
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<NasaResponse> GetNasaPhotosAsync(string nasaSearchTerm, int pageSize)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://images-api.nasa.gov/search?q={nasaSearchTerm}&media_type=image&page_size={pageSize}");

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NasaResponse>(content);
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
