using Cliente.BancoDeDadosEF.Repositorio;
using Cliente.Dominio.BancoDeDados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.BancoDeDadosEF.Entidade
{
    [Table(nameof(ContextoDoBancoDeDados.Cliente), Schema = ContextoDoBancoDeDados.Schema)]
    [Index(nameof(Id), IsUnique = true, Name = "IX_Id")]
    public class EntidadeCliente : EntidadeDoBancoDeDados
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
        
        public int Idade { get; set; }
    }
}
