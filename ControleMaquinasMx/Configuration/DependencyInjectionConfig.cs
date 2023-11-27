using ControleMaquinasMx_Core.Interfaces;
using ControleMaquinasMx_Data.Repository;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_Manager.Implementation;

namespace ControleMaquinasMx.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMaquinasRepository, MaquinasRepository>();
            services.AddScoped<IMaquinasManager, MaquinasManager>();
            services.AddScoped<IPacotesRepository, PacotesRepository>();
            services.AddScoped<IPacotesManager, PacotesManager>();
        }
    }
}
