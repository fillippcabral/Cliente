using Cliente.BancoDeDadosEF;

namespace Cliente.WebAPI
{
    public static class InjecaoDeDependencias
    {
        public static IServiceCollection IncluirTodasAsDependencias(this IServiceCollection services)
        {
            services.AdicionarDependenciasDeBancoDeDados();
            return services;

        }
    }
}
