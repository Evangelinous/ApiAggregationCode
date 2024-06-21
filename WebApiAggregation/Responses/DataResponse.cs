using System;
using System.Collections.Generic;

namespace WebApiAggregation.Responses
{
    public class AggregatedResponse
    {
        public List<WeatherResponse> Weather { get; set; }
        public List<NasaResponse> Nasa { get; set; }
        public List<BreweryResponse> Breweries { get; set; }

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

    public class BreweryResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BreweryType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
    }
}
