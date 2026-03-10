using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // if client does not specify version, assume v1
    options.AssumeDefaultVersionWhenUnspecified = true;

    // adds version information in response headers
    options.ReportApiVersions = true;

    // version will be read from URL
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();   // ⭐ VERY IMPORTANT

app.Run();