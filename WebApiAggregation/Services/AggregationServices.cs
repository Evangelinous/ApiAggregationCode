using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using WebApiAggregation.Responses;
using WebApiAggregation.Services;
using System.Collections.Generic;

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
        public async Task<List<BreweryResponse>> GetBreweriesAsync(string brewerySearchTerm, int pageSize)
        {
            var cacheKey = $"Breweries_{brewerySearchTerm}_{pageSize}";
            if (_cache.TryGetValue(cacheKey, out List<BreweryResponse> cachedBreweries))
            {

                return cachedBreweries;
            }

            try
            {
                var response = await _httpClient.GetAsync($"https://api.openbrewerydb.org/breweries?by_city={brewerySearchTerm}&per_page={pageSize}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var breweriesResponse = JsonConvert.DeserializeObject<List<BreweryResponse>>(content);

                _cache.Set(cacheKey, breweriesResponse, _cacheDuration);
                return breweriesResponse;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
