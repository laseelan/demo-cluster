using demo_api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: false)
    .AddJsonFile($"appsettings.overrides.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1-api0.7",
        Title = "DemoApi",
        Description = "An ASP.NET Core Web API for testing deployments",
        TermsOfService = new Uri("https://fischeridentity.com/terms"),
        License = new OpenApiLicense
        {
            Name = "Fischer License",
            Url = new Uri("https://fischeridentity/license")
        }
    });
});

builder.Services.Configure<SecretProvider>(builder.Configuration.GetSection(ConfigSectionSettings.SecretProvider));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
