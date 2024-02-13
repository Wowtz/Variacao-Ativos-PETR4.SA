using VariacaoAtivoApi.Repositories;
using VariacaoAtivoApi.Services;
using VariacaoAtivosApi.Repositories;

namespace VariacaoAtivoApi.Configuration
{
    public static class ServicesRepositoriesConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IConsultarAtivosServices, ConsultarAtivosServices>();
            services.AddScoped<IVariacaoAtivosService, VariacaoAtivosService>();
            #endregion

            #region
            services.AddScoped<IVariacaoAtivosRepository, VariacaoAtivosRepository>();
            #endregion

            return services;
        }
    }
}
