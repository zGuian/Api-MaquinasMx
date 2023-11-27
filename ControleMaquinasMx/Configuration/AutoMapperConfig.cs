using AutoMapper;
using ControleMaquinasMx_Manager.Profiles;

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
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
