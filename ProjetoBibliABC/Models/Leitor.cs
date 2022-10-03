using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliABC.Models
{
    internal class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
    }
}

/*
    CREATE TABLE Leitor(
    id_lei int primary key auto_increment,
    nome_lei varchar(100),
    cpf_lei varchar(100),
    email_lei varchar(100),
    rg_lei varchar(100),
    endereco_lei varchar(100),
    telefone_lei varchar(100),
    dataNascimento_lei date,
     sexo_lei varchar(100)
);
 */