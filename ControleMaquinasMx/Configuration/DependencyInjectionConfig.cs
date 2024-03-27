using ControleMaquinasMx_Domain.Interfaces;
using ControleMaquinasMx_Data.Repository;
using ControleMaquinasMx_Manager.Interfaces;
using ControleMaquinasMx_Manager.Implementation;
using ControleMaquinasMx_Data.Services;

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
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
        }
    }
}
