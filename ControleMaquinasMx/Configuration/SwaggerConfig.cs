using Microsoft.OpenApi.Models;

namespace ControleMaquinasMx.Configuration

{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
