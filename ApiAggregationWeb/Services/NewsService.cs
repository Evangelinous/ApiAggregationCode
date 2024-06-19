using System.Net.Http;
using System.Threading.Tasks;

namespace ApiAggregation.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetNewsAsync(string query)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://newsapi.org/v2/everything?q={query}&apiKey=YOUR_API_KEY");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
