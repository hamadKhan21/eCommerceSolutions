using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core;
using eCommerce.Infrastructure;
using eCommerce.UI.Middleware;
using System.Text.Json.Serialization;
using System.Text.Json;

// Configure the DI container by registering services.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();
builder.Services.AddInfraStructure();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Configure JSON serialization options
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // Use camelCase for JSON properties
        options.JsonSerializerOptions.WriteIndented = true; // Pretty-print JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; // Ignore null values
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Convert enums to strings
    });


// Configure the middleware pipeline to handle HTTP requests and responses.
var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
