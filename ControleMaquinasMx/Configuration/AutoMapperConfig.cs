using AutoMapper;
using ControleMaquinasMx_Application.Profiles;

namespace ControleMaquinasMx.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MaquinaProfile());
                mc.AddProfile(new PacotesProfile());
                mc.AddProfile(new UsuarioProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
