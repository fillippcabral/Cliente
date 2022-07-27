using Cliente.BancoDeDadosEF.Entidade;
using Cliente.Core.Excecoes;
using Cliente.Dominio.BancoDeDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.BancoDeDadosEF.Repositorio
{
    public class ArmazenadorCliente : IArmazenadorCliente
    {
        private readonly ContextoDoBancoDeDados _context;

        public ArmazenadorCliente(ContextoDoBancoDeDados context)
        {
            _context = context;
        }

        public void AtualizarCliente(EntidadeCliente cliente)
        {
            var entidade = _context.Cliente.Where(c => c.Id == cliente.Id).First();
           
            if(entidade.Id.ToString() == "")
            {
                new ExcecaoDeProgramacao("O Cliente não existe");
            }

            entidade.Nome = cliente.Nome;
            entidade.Idade = cliente.Idade;

            _context.AtualizarESalvar(entidade);

        }

        public void DeletarCliente(Guid Id)
        {
            if (Id.ToString() == "")
            {
                new ExcecaoDeProgramacao("O Cliente não existe");
            }

            var entidade = _context.Cliente.Where(c => c.Id == Id).First();
            _context.RemoverESalvar(entidade);
        }

        public void InserirCliente(EntidadeCliente cliente)
        {
            _context.AdicionarESalvar(cliente);
        }

        public List<EntidadeCliente> ObterClientes()
        {
            return _context.Listar<EntidadeCliente>().ToList();
        }
    }
}
