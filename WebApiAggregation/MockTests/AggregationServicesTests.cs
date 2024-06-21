using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiAggregation.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using WebApiAggregation.Responses;
using Xunit;
using System.Collections.Generic;
using System.Threading;
using WebApiAggregation.Services;
using ApiAggregation.Controllers;
using Microsoft.Extensions.Logging;

public class AggregationServicesTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly IMemoryCache _memoryCache;
    private readonly AggregationServices _aggregationServices;
    private readonly AuthService _authService;

    public AggregationServicesTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _configurationMock = new Mock<IConfiguration>();
        _memoryCache = new MemoryCache(new MemoryCacheOptions());

        var loggerMock = new Mock<ILogger<AuthController>>();
        _authService = new AuthService(loggerMock.Object, _configurationMock.Object);

        _aggregationServices = new AggregationServices(_httpClient, _configurationMock.Object, _memoryCache);

        _configurationMock.Setup(config => config["NewsApi:ApiKey"]).Returns("fake_news_api_key");
        _configurationMock.Setup(config => config["OpenWeatherMap:ApiKey"]).Returns("fake_weather_api_key");
    }

    [Fact]
    public async Task GetWeatherAsync_ShouldReturnWeatherResponse_WhenCalled()
    {
        // Arrange
        var weatherSearchTerm = "Athens";
        var expectedResponse = new WeatherResponse { Name = "Athens", Weather = new List<Weather> { new Weather { Description = "clear sky" } } };
        var responseContent = JsonConvert.SerializeObject(expectedResponse);

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _aggregationServices.GetWeatherAsync(weatherSearchTerm);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedResponse.Name, result.Name);
        Assert.Single(result.Weather);
        Assert.Equal(expectedResponse.Weather[0].Description, result.Weather[0].Description);
    }

    [Fact]
    public async Task GetNasaPhotosAsync_ShouldReturnNasaResponse_WhenCalled()
    {
        // Arrange
        var nasaSearchTerm = "moon";
        var pageSize = 5;
        var expectedResponse = new NasaResponse { Collection = new Collection { Items = new List<Item> { new Item { Href = "http://example.com" } } } };
        var responseContent = JsonConvert.SerializeObject(expectedResponse);

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _aggregationServices.GetNasaPhotosAsync(nasaSearchTerm, pageSize);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Collection);
        Assert.Single(result.Collection.Items);
        Assert.Equal(expectedResponse.Collection.Items[0].Href, result.Collection.Items[0].Href);
    }

    [Fact]
    public async Task GetBreweryAsync_ShouldReturnBreweryResponse_WhenCalled()
    {
        // Arrange
        var brewerySearchTerm = "ale";
        var pageSize = 5;
        var expectedResponse = new List<BreweryResponse> { new BreweryResponse { Name = "Test Brewery" } };
        var responseContent = JsonConvert.SerializeObject(expectedResponse);

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _aggregationServices.GetBreweriesAsync(brewerySearchTerm, pageSize);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expectedResponse[0].Name, result[0].Name);
    }
}
