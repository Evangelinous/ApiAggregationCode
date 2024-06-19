using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using WebApiAggregation.Services;

namespace ApiAggregation.Controllers;

[ApiController]
[Route("[controller]")]
public class AggregationController : ControllerBase, IAggregationController
{
    private readonly IAggregationServices _aggregationServices;
    private readonly ILogger<AggregationController> _logger;

    public AggregationController(IAggregationServices aggregationServices, ILogger<AggregationController> logger)
    {
        _aggregationServices = aggregationServices;
        _logger = logger;
    }

    /// <summary>
    /// Made for getting information for the Weather of a certain city and News based on a certain query, both given by input of the user.
    /// </summary>
    /// <param name="weatherSearchTerm"> The city that we want to search, with the WeatherApi </param>
    /// <param name="newsSearchTerm"> The search term that we want to search, with the NewsApi </param>
    /// <param name="nasaSearchTerm"> The photo that we want to search, with the NasaApi </param>
    /// <returns></returns>

    [HttpGet("[action]")]
    public async Task<IActionResult> GetData(string weatherSearchTerm, string newsSearchTerm, string nasaSearchTerm)
    {
        try
        {
            var newsTask = await _aggregationServices.GetNewsAsync(newsSearchTerm);
            var weatherTask = await _aggregationServices.GetWeatherAsync(weatherSearchTerm);
            var nasaTask = await _aggregationServices.GetNasaPhotosAsync(nasaSearchTerm);

            var result = new
            {
                Weather = weatherTask,
                News = newsTask,
                Nasa = nasaTask
            };

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting data.");
            return StatusCode(500, new { Error = "An error occurred while processing your request." });
        }
    }
}
