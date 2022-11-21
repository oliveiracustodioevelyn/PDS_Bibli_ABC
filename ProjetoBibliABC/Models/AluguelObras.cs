using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliABC.Models
{
    internal class AluguelObras
    {
        public int Id { get; set; }
        public Aluguel Aluguel { get; set; }
        public Livro Livro { get; set; }

        /*
         id_AluObra int primary key auto_increment,
        id_alu_fk int,
        cod_obra_fk int,
        foreign key (id_alu_fk) references Aluguel (id_alu),
        foreign key (cod_obra_fk) references Obras (cod_obra)*/
    }
}
