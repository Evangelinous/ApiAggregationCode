using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using ApiAggregation.Services;
using ApiAggregation.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ApiAggregation.Middlewares;
using WebApiAggregation.Services;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var builder = WebApplication.CreateBuilder(args);

// Configure the Configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true)
    .AddEnvironmentVariables();

// Add services to the container
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

// Add logging
builder.Services.AddLogging();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebApiAggregation.xml"));
});

// Add custom services
builder.Services.AddHttpClient<IAggregationServices, AggregationServices>();

// Add JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Add Redis Caching
builder.Services.AddRedisCaching(builder.Configuration);

// Add Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Configure Kestrel
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Προσθήκη middleware για χειρισμό εξαιρέσεων
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

public partial class Program { }
