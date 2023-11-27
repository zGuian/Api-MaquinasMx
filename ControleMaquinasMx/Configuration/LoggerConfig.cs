using Serilog;

namespace ControleMaquinasMx.Configuration
{
    public static class LoggerConfig
    {
        public static void ConfiguraLog(this ILoggingBuilder builder, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Information("Iniciado o WebApi");
            builder.AddSerilog(logger);
        }

        public static void ClearProvidersConfiguration(this ILoggingBuilder builder)
        {
            builder.ClearProviders();
        }
    }
}
