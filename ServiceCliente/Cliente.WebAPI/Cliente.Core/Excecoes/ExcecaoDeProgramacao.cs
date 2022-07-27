using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Core.Excecoes
{
    public class ExcecaoDeProgramacao : Exception
    {
        public ExcecaoDeProgramacao(string mensagem, Exception inner = null) : base(mensagem, inner) { }

    }
}
