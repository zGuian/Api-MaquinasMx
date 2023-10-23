using ControleMaquinasMx.Data.Data;
using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_Data.Repository;
using ControleMaquinasMx_Manager.Implementation;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(
    builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddScoped<IMaquinasRepository, MaquinasRepository>();
builder.Services.AddScoped<IMaquinasManager, MaquinasManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiMaquinasMx");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
