create database ProjetoABC;
use ProjetoABC;

CREATE TABLE Funcionario(
id_fun int primary key auto_increment,
nome_fun varchar(100),
cpf_fun varchar(100),
rg_fun varchar(100),
sexo_fun varchar(100),
telefone1_fun varchar(100),
telefone2_fun varchar(100),
dataNascimento_fun date,
email_fun varchar(100), 
senha_fun varchar(100),
rua_fun varchar(100),
bairro_fun varchar(100),
numero_fun varchar(100),
complemento_fun varchar(100),
cidade_fun varchar(100),
estado_fun varchar(100)
);

CREATE TABLE Endereco(
id_end int primary key auto_increment,
rua_end varchar(100),
numero_end varchar(100),
bairro_end varchar(100),
complemento_end varchar(100),
cidade_end varchar(100),
estado_end varchar(100)
);

CREATE TABLE Leitor(
cod_lei int primary key auto_increment,
nome_lei varchar(100),
cpf_lei varchar(100),
rg_lei varchar(100),
email_lei varchar(100),
telefone_lei varchar(100),
dataNascimento_lei date,
sexo_lei varchar(100),
rua_lei varchar(100),
bairro_lei varchar(100),
numero_lei varchar(100),
cep_lei varchar(100),
complemento_lei varchar(100),
cidade_lei varchar(100),
estado_lei varchar(100)
);

CREATE TABLE Editora(
cod_edi int primary key auto_increment,
razaoSocial_edi varchar(100),
nomeFantasia_edi varchar(100),
cnpj_edi varchar(100),
telefone1_edi varchar(100),
telefone2_edi varchar(100),
representante_edi varchar(100), 
email_edi varchar(100),
rua_edi varchar(100),
bairro_edi varchar(100),
numero_edi varchar(100),
cep_edi varchar(100),
complemento_edi varchar(100),
cidade_edi varchar(100),
estado_edi varchar(100)
); 

select * FROM editora;

/*CREATE TABLE Devolucao(
id_dev int primary key auto_increment,
data_dev date
);*/

CREATE TABLE Obras(
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
sinopse_obra varchar(100),
status_obra varchar(100)
);


CREATE TABLE Aluguel(
id_alu int primary key auto_increment,
dataAluguel_alu date,
dataDevolucao_alu date,
id_fun_fk int,
cod_lei_fk int,
cod_obra_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun),
foreign key (cod_lei_fk) references Leitor (cod_lei),
foreign key (cod_obra_fk) references Obras (cod_obra)
);

/*#comando.CommandText = "INSERT INTO  Obras VALUES (null, @titulo_obra,  @dataPublicacao_obra, @num_exemplar_obra, @editora_obra, @num_paginas_obra, @autor_obra," +"@genero_obra,@tipo_obra,@edicao_obra, @sinopse_obra);";
CREATE TABLE AluObra(
id_AluObra int primary key auto_increment,
id_alu_fk int,
cod_obra_fk int,
foreign key (id_alu_fk) references Aluguel (id_alu),
foreign key (cod_obra_fk) references Obras (cod_obra)
);*/

select	* from obras;
select * from leitor;
select * from aluguel;

INSERT INTO `projetoabc`.`aluguel` (`id_alu`, @dataAluguel, `dataDevolucao_alu`, `id_fun_fk`, `cod_lei_fk`) VALUES (null, null, null, null, null);


UPDATE `projetoabc`.`aluguel` SET dataAluguel_alu = @dataAluguel, dataDevolucao_alu = @dataDevolucao, id_fun_fk = @idFuncionario, cod_lei_fk = @idLeitor, cod_obra_fk = @idObra  WHERE (`id_alu` = @id);

null, @dataAluguel, " +
                    "@dataDevolucao, @idFuncionario, @idLeitor, @idObra




