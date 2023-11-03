using ControleMaquinasMx.Configuration;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataBaseConfiguration(builder);
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddControllersConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerConfigurationApp();
}
if (app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}

app.UseDataBaseConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
