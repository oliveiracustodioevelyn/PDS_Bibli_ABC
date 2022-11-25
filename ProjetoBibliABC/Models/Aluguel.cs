using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliABC.Models
{
    public class Aluguel
    {
        public int Id { get; set; }
        public DateTime? DataAluguel { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public Funcionario Funcionario { get; set; }
        public Leitor Leitor { get; set; }
        public Livro Livro { get; set; }
        //public De Name { get; set; }
    }
}
