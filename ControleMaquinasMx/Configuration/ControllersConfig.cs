using System.Text.Json.Serialization;

namespace ControleMaquinasMx.Configuration
{
    public static class ControllersConfig
    {
        public static void AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
            .AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }
    }
}
