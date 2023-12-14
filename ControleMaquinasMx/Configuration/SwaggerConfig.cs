using Microsoft.OpenApi.Models;

namespace ControleMaquinasMx.Configuration

{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Gerenciamento de maquinas MX",
                        Version = "v1",
                        Description = "API aplicação de gerenciamento de maquinas MX.",
                        Contact = new OpenApiContact
                        {
                            Name = "Guian Rocha",
                            Email = "guian.rocha@t-systems.com"
                        },
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference= new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }
                    },
                        new string[]{ }
                    }
                });
                c.OperationFilter<ConflictingActionsResolver>();

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                //xmlPath = Path.Combine(AppContext.BaseDirectory, "ControleMaquinasMx_CoreShared.xml");
                //c.IncludeXmlComments(xmlPath);
            });
        }

        public static void AddSwaggerConfigurationApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Maquina Mx");
            });
        }
    }
}
