using ControleMaquinasMx.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScoped = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScoped.ServiceProvider.GetService<AppDbContext>();
            //context.Database.Migrate();
            //context.Database.EnsureCreatedAsync().Wait();
        }
    }
}
