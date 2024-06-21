API Aggregation Service Documentation

Overview

The API Aggregation Service provides a unified interface to fetch data from multiple external APIs. It combines responses from Weather, News, NASA, and Brewery APIs based on user input and returns a consolidated response.
Usage Instructions

Getting JWT Token

Send a POST request to /AuthController/login with 
username = “user1” and password "password1" for the Role = "User".
username = “admin” and password "password2" for the Role = "Admin"
If the credentials are valid, a JWT token will be returned.

Using JWT Token
Include the token in the Authorization header as Bearer <token> when making requests to protected endpoints.
Endpoints

1. Login
   
Description
Authenticates a user and returns a JWT token if the credentials are valid.

HTTP Method
POST
URL
/AuthController/login
Parameters
LoginModel (body): The login model containing username and password.
Responses
200 OK
Returns a JWT token.
401 Unauthorized
If the credentials are invalid.
Example Request


POST /AuthController/login
Content-Type: application/json

{
  "username": "testuser",
  "password": "testpassword"
}

Example Response

{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}

2. GetData
   
Description
Gets combined data from Weather, News, NASA, and Brewery APIs based on user input.
HTTP Method
GET
URL
/AggregationController/GetData
Parameters
weatherSearchTerm: The city name for which to fetch weather data using the Weather API.
newsSearchTerm: The search term to fetch related news using the News API.
nasaSearchTerm: The search term to fetch NASA images using the NASA API.
brewerySearchTerm: The search term to fetch Brewery information using the Brewery API.
pageSize: The number of results that all the APIs will return.
Responses
200 OK
Returns the combined data from Weather, News, NASA, and Brewery APIs.
500 Internal Server Error
If there was an error processing the request.
Example Request
sql

GET /AggregationController/GetData?weatherSearchTerm=Athens&newsSearchTerm=Technology&nasaSearchTerm=Moon&brewerySearchTerm=IPA&pageSize=5

Example Response
{
  "weather": [
    {
      "coord": {
        "lon": 23.7162,
        "lat": 37.9795
      },
      "weather": [
        {
          "id": 800,
          "main": "Clear",
          "description": "clear sky",
          "icon": "01d"
        }
      ],
      "base": "stations",
      "main": {
        "temp": 308.28,
        "feels_like": 306.6,
        "temp_min": 306.8,
        "temp_max": 309.4,
        "pressure": 1013,
        "humidity": 22
      },
      "visibility": 10000,
      "wind": {
        "speed": 7.72,
        "deg": 350,
        "gust": 15.43
      },
      "clouds": {
        "all": 0
      },
      "dt": 1718801688,
      "sys": {
        "type": 2,
        "id": 2005332,
        "country": "GR",
        "sunrise": 1718766152,
        "sunset": 1718819432
      },
      "timezone": 10800,
      "id": 264371,
      "name": "Athens",
      "cod": 200
    }
  ],
  "nasa": [
    {
      "collection": {
        "version": "1.0",
        "href": "http://images-api.nasa.gov/search?q=Moon&media_type=image&page_size=1",
        "items": [
          {
            "href": "https://images-assets.nasa.gov/image/PIA12235/collection.json",
            "data": [
              {
                "center": "JPL",
                "title": "Nearside of the Moon",
                "nasa_id": "PIA12235",
                "date_created": "2009-09-24T18:00:22Z",
                "keywords": [
                  "Moon",
                  "Chandrayaan-1"
                ],
                "media_type": "image",
                "description_508": "Nearside of the Moon",
                "secondary_creator": "ISRO/NASA/JPL-Caltech/Brown Univ.",
                "description": "Nearside of the Moon"
              }
            ],
            "links": [
              {
                "href": "https://images-assets.nasa.gov/image/PIA12235/PIA12235~thumb.jpg",
                "rel": "preview",
                "render": "image"
              }
            ]
          }
        ],
        "metadata": {
          "total_hits": 15303
        },
        "links": [
          {
            "rel": "next",
            "prompt": "Next",
            "href": "http://images-api.nasa.gov/search?q=Moon&media_type=image&page_size=1&page=2"
          }
        ]
      }
    }
  ],
  "brewery": [
    {
      "id": "10-56-brewing-company-knox",
      "name": "10-56 Brewing Company",
      "breweryType": "micro",
      "street": "400 Brown Cir",
      "city": "Knox",
      "state": "Indiana",
      "postalCode": "46534",
      "country": "United States",
      "longitude": "-86.625",
      "latitude": "41.2895",
      "phone": "6308165790",
      "websiteUrl": "http://www.10-56brewing.com"
    }
  ]
}


Configuration Instructions
appsettings.json

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "JwtSettings": {
    "Issuer": "YourIssuer",
    "Audience": "YourAudience",
    "SecretKey": "B4A98DE0F6A34711A914B50D6BC041F51234D0EC46D6A9B5E1BFA287B7F99E36"
  },
  "ConnectionStrings": {
    "Redis": "localhost:6379"
  },
  "OpenWeatherMap": {
    "ApiKey": "4b17385bb3c16eab9ab631e68a6a0193"
  },
  "NasaApi": {
    "ApiKey": "OaDVnFY4a1W9LzGGenyhXlo7pen29io8fZd4qBQr"
  },
  "AllowedHosts": "*"
}
