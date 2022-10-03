using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliABC.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string NomeFornecedor { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone { get; set; }
    }
}
/*CREATE TABLE Fornecedor(
id_for int primary key auto_increment,
nomeEmpresa_for varchar(100),
cnpj_for varchar(100),
email_for varchar (100),
razaoSocial_for varchar(100),
endereco_for varchar(100),
telefone_for varchar(100),
descricao_for varchar(100) 
); */
