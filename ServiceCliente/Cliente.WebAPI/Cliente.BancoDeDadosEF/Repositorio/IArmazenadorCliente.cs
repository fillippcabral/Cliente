using Cliente.BancoDeDadosEF.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.BancoDeDadosEF.Repositorio
{
    public interface IArmazenadorCliente
    {
        void InserirCliente(EntidadeCliente cliente);
        List<EntidadeCliente> ObterClientes();
        void AtualizarCliente(EntidadeCliente cliente);
        void DeletarCliente(Guid Id);

    }
}
