using ControleMaquinasMx.Configuration;

var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{ambiente}.json")
    .Build();


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ConfiguraLog(configuration);
builder.Logging.ClearProvidersConfiguration();
builder.Services.AddControllersConfiguration();
builder.Services.AddJwtConfiguration(configuration);
builder.Services.AddDataBaseConfiguration(builder);
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerConfigurationApp();
}
app.AppCorsConfiguration();
app.UseDataBaseConfiguration();
app.UseHttpsRedirection();
app.UseJwtConfiguration();
app.MapControllers();
app.Run();
