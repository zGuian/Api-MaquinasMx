namespace ControleMaquinasMx.Configuration
{
    public static class ServicesConfig
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors();
        }

        public static void AppCorsConfiguration(this WebApplication app)
        {
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
        }
    }
}
