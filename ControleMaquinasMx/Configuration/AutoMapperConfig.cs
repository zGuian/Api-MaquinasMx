﻿using ControleMaquinasMx_Manager.Profiles;

namespace ControleMaquinasMx.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MaquinaProfile), typeof(PacotesProfile));
        }
    }
}
