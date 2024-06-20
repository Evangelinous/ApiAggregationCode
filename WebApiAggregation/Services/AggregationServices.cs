using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);

        public AggregationServices(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _apiKeyNewsApi = configuration["NewsApi:ApiKey"];
            _apiKeyOpenWeatherMap = configuration["OpenWeatherMap:ApiKey"];
            _cache = cache;
        }

        public async Task<NewsResponse> GetNewsAsync(string newsSearchTerm, int pageSize)
        {
            var cacheKey = $"News_{newsSearchTerm}_{pageSize}";
            if (_cache.TryGetValue(cacheKey, out NewsResponse cachedNews))
            {
                return cachedNews;
            }

            try
            {
                var response = await _httpClient.GetAsync($"https://newsapi.org/v2/everything?q={newsSearchTerm}&pageSize={pageSize}&apiKey={_apiKeyNewsApi}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var newsResponse = JsonConvert.DeserializeObject<NewsResponse>(content);

                _cache.Set(cacheKey, newsResponse, _cacheDuration);
                return newsResponse;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<WeatherResponse> GetWeatherAsync(string weatherSearchTerm)
        {
            var cacheKey = $"Weather_{weatherSearchTerm}";
            if (_cache.TryGetValue(cacheKey, out WeatherResponse cachedWeather))
            {
                return cachedWeather;
            }

            try
            {
                var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={weatherSearchTerm}&appid={_apiKeyOpenWeatherMap}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(content);

                _cache.Set(cacheKey, weatherResponse, _cacheDuration);
                return weatherResponse;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<NasaResponse> GetNasaPhotosAsync(string nasaSearchTerm, int pageSize)
        {
            var cacheKey = $"Nasa_{nasaSearchTerm}_{pageSize}";
            if (_cache.TryGetValue(cacheKey, out NasaResponse cachedNasa))
            {
                return cachedNasa;
            }

            try
            {
                var response = await _httpClient.GetAsync($"https://images-api.nasa.gov/search?q={nasaSearchTerm}&media_type=image&page_size={pageSize}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var nasaResponse = JsonConvert.DeserializeObject<NasaResponse>(content);

                _cache.Set(cacheKey, nasaResponse, _cacheDuration);
                return nasaResponse;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
