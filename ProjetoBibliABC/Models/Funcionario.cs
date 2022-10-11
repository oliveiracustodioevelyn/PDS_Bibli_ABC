﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliABC.Models
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Turno { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

/*
 CREATE TABLE Funcionario(
id_fun int primary key auto_increment,
nome_fun varchar(100),
cpf_fun varchar(100),
rg_fun varchar(100),
endereco_fun varchar(100),
telefone_fun varchar(100),
dataNascimento_fun date,
sexo_fun varchar(100),
turno_fun varchar(100),
email_fun varchar(100), 
senha_fun varchar(100)
 */