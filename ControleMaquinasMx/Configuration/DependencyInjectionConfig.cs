using ControleMaquinasMx_Domain.Interfaces;
using ControleMaquinasMx_Data.Repository;
using ControleMaquinasMx_Application.Interfaces;
using ControleMaquinasMx_Application.Services;
using ControleMaquinasMx_Data.Services;

namespace ControleMaquinasMx.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IMaquinasRepository, MaquinasRepository>();
            services.AddScoped<IMaquinasServices, MaquinaServices>();
            services.AddScoped<IPacotesRepository, PacotesRepository>();
            services.AddScoped<IPacotesServices, PacotesServices>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
        }
    }
}
