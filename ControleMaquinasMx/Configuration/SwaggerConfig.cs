using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ControleMaquinasMx.Configuration

{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            //{
            //    c.swaggerdoc("v1", new openapiinfo { title = "apimaquinasmx", version = "v1" });
            //    var xmlfile = $"{assembly.getexecutingassembly().getname().name}.xml";
            //    var xmlpath = path.combine(appcontext.basedirectory, xmlfile);
            //    c.includexmlcomments(xmlpath);
            //});
        }

            public static void AddSwaggerConfigurationApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Maquinas Mx");
            });
        }
    }
}
