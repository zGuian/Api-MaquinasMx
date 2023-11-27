using ControleMaquinasMx.Configuration;

//{
var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{ambiente}.json")
    .Build();
//}

//{
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataBaseConfiguration(builder);
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddControllersConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Logging.ConfiguraLog(configuration);
builder.Logging.ClearProvidersConfiguration();
//}

//{
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerConfigurationApp();
}

app.AppCorsConfiguration();
app.UseDataBaseConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
//}