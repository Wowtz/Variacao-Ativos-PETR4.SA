using Microsoft.OpenApi.Models;

namespace VariacaoAtivoApi.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Teste Guide Variação dos Ativos",
                    Description = "Este desafio consiste em consultar a variação do preço de " +
                        "um ativo a sua escolha nos últimos 30 pregões. Você deverá apresentar o " +
                        "percentual de variação de preço de um dia para o outro e o percentual " +
                        "desde o primeiro pregão apresentado.",
                    Contact = new OpenApiContact { Name = "Walter de Camargo", Email = "walter.camargo.gr@gmail.com" }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}
