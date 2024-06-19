using ApiAggregation.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiAggregation.Responses
{
    public class AggregatedResponse
    {
        public List<WeatherResponse> Weather { get; set; }
        public List<NewsResponse> News { get; set; }
        public List<NasaResponse> Nasa { get; set; }
    }

    public class WeatherResponse
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class NewsResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }

    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class NasaResponse
    {
        public Collection Collection { get; set; }
    }

    public class Collection
    {
        public string Version { get; set; }
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public Metadata Metadata { get; set; }
        public List<Link> Links { get; set; }
    }

    public class Item
    {
        public string Href { get; set; }
        public List<Datum> Data { get; set; }
        public List<Link> Links { get; set; }
    }

    public class Datum
    {
        public string Center { get; set; }
        public string Title { get; set; }
        public string NasaId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> Keywords { get; set; }
        public string MediaType { get; set; }
        public string Description508 { get; set; }
        public string SecondaryCreator { get; set; }
        public string Description { get; set; }
    }

    public class Metadata
    {
        public int TotalHits { get; set; }
    }

    public class Link
    {
        public string Rel { get; set; }
        public string Prompt { get; set; }
        public string Href { get; set; }
    }

    public class ApiResponse
    {
        public WeatherResponse Weather { get; set; }
        public NewsResponse News { get; set; }
        public NasaResponse Nasa { get; set; }
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse))]
    [Authorize(Roles = $"{nameof(AuthorizationRoles.Individual)}, {nameof(AuthorizationRoles.Manager)}, {nameof(AuthorizationRoles.HRBP)}")]
    public async Task<ActionResult<ApiResponse>> GetData(string weatherSearchTerm, string newsSearchTerm, string nasaSearchTerm, int limit = 10)
    {
        var weatherTask = _weatherService.GetWeatherAsync(weatherSearchTerm);
        var newsTask = _newsService.GetNewsAsync(newsSearchTerm, limit);
        var nasaTask = _nasaService.GetNasaImagesAsync(nasaSearchTerm, limit);

        await Task.WhenAll(weatherTask, newsTask, nasaTask);

        var result = new ApiResponse
        {
            Weather = JsonConvert.DeserializeObject<WeatherResponse>(weatherTask.Result),
            News = JsonConvert.DeserializeObject<NewsResponse>(newsTask.Result),
            Nasa = JsonConvert.DeserializeObject<NasaResponse>(nasaTask.Result)
        };

        return Ok(result);
    }

}
