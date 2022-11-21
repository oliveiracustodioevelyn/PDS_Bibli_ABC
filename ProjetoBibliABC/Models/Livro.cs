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
        public DateTime? DataPublicacao { get; set; }
        public int NumExemplar { get; set; }
        public string EditoraObra { get; set; }
        public int NumPagina { get; set; }
        public string AutorObra { get; set; }
        public string Genero { get; set; }
        public string Tipo { get; set; }
        public string EdicaoObra { get; set; }
        public string SinopseObra { get; set; }
        public string Status { get; set; }

    }
}




/*CREATE TABLE Obras(
cod_obra int primary key auto_increment,
titulo_obra varchar(100),
dataPublicacao_obra date,
num_exemplar_obra int,
editora_obra varchar(100),
num_paginas_obra int,
autor_obra varchar(100),
genero_obra varchar(100),
tipo_obra varchar(100),
edicao_obra varchar (100),
sinopse_obra varchar(100)
);*/
