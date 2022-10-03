using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliABC.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string  TituloObra { get; set; }
        public string AutorObra { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string LocalizacaoObra { get; set; }
        public string EdicaoObra { get; set; }
        public string SinopseObra { get; set; }
       

    }
}
/*CREATE TABLE Obras(
id_obra int primary key auto_increment,
titulo_obra varchar(100),
autor_obra varchar(100),
dataPublicacao_obra date,
localizacao_obra varchar (100),
edicao_obra varchar(100),
sinopse_obra varchar(100),
id_for_fk int,
foreign key (id_for_fk) references Fornecedor (id_for)
);*/
