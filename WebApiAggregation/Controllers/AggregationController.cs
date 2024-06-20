using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using WebApiAggregation.Services;
using ApiAggregation.Responses;
using WebApiAggregation.Responses;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using ApiAggregation.Enums;

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
    /// Gets combined data from Weather, News, and NASA APIs based on user input.
    /// </summary>
    /// <param name="weatherSearchTerm">The city name for which to fetch weather data using the Weather API.</param>
    /// <param name="newsSearchTerm">The search term to fetch related news using the News API.</param>
    /// <param name="nasaSearchTerm">The search term to fetch NASA images using the NASA API.</param>
    /// <param name="pageSize">The number of results that will all the api will return.</param>
    /// <returns>An IActionResult containing weather information, news articles, and NASA images.</returns>
    /// <response code="200">Returns the combined data from Weather, News, and NASA APIs.</response>
    /// <response code="500">If there was an error processing the request.</response>
    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ResponseBaseModel<AggregatedResponse>))]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetData(string weatherSearchTerm, string newsSearchTerm, string nasaSearchTerm, int pageSize)
    {
        try
        {
            var newsTask = await _aggregationServices.GetNewsAsync(newsSearchTerm, pageSize);
            var weatherTask = await _aggregationServices.GetWeatherAsync(weatherSearchTerm);
            var nasaTask = await _aggregationServices.GetNasaPhotosAsync(nasaSearchTerm, pageSize);

            var result = new AggregatedResponse
            {
                Weather = new List<WeatherResponse> { weatherTask },
                News = new List<NewsResponse> { newsTask },
                Nasa = new List<NasaResponse> {  nasaTask }
            };

            return Ok(new ResponseBaseModel<AggregatedResponse> { Payload = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting data.");
            return StatusCode(500, new { Error = "An error occurred while processing your request." });
        }
    }
}
