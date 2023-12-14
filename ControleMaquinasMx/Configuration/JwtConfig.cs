using ControleMaquinasMx_Data.Services;
using ControleMaquinasMx_Manager.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ControleMaquinasMx.Configuration
{
    public static class JwtConfig
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJWTService, JWTServices>();

            var chave = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JWT:Audience").Value,
                    ValidateLifetime = true,
                };
            });
        }

        public static void UseJwtConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
