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
        public string Razao_social { get; set; }
        public string Nome_fantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Representante { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}

