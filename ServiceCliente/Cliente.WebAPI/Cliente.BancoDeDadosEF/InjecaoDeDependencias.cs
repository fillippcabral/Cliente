using Cliente.BancoDeDadosEF.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.BancoDeDadosEF
{
    public static class InjecaoDeDependencias
    {
        public static void AdicionarDependenciasDeBancoDeDados(this IServiceCollection services)
        {
            services.AddTransient<IArmazenadorCliente, ArmazenadorCliente>();

        }
    }
}
