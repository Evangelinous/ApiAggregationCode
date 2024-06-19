using ApiAggregation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAggregation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggregationController : ControllerBase, IAggregationController
    {
        private readonly IWeatherService _weatherService;
        private readonly INewsService _newsService;

        public AggregationController(IWeatherService weatherService, INewsService newsService)
        {
            _weatherService = weatherService;
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetData(string city, string query)
        {
            var weatherTask = await _weatherService.GetWeatherAsync(city);
            var newsTask = await _newsService.GetNewsAsync(query);

            var result = new
            {
                Weather = weatherTask,
                News = newsTask
            };

            return Ok(result);
        }
    }
}
