create database ProjetoABC;
use ProjetoABC;

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
);

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

CREATE TABLE Fornecedor(
id_for int primary key auto_increment,
nomeEmpresa_for varchar(100),
cnpj_for varchar(100),
email_for varchar (100),
razaoSocial_for varchar(100),
endereco_for varchar(100),
telefone_for varchar(100),
descricao_for varchar(100) 
); 

CREATE TABLE Devolucao(
id_dev int primary key auto_increment,
data_dev date,
hora_dev time
);

CREATE TABLE Aluguel(
id_alu int primary key auto_increment,
dataAluguel_alu date,
hora_alu time,
tempo_alu int,
dataDevolucao date,
id_fun_fk int,
id_lei_fk int,
id_dev_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun),
foreign key (id_lei_fk) references Leitor (id_lei),
foreign key (id_dev_fk) references Devolucao (id_dev)
);

CREATE TABLE Obras(
id_obra int primary key auto_increment,
titulo_obra varchar(100),
autor_obra varchar(100),
dataPublicacao_obra date,
localizacao_obra varchar (100),
edicao_obra varchar(100),
sinopse_obra varchar(100),
id_for_fk int,
foreign key (id_for_fk) references Fornecedor (id_for)
);

CREATE TABLE AluObra(
id_AluObra int primary key auto_increment,
id_alu_fk int,
id_obra_fk int,
foreign key (id_alu_fk) references Aluguel (id_alu),
foreign key (id_obra_fk) references Obras (id_obra)
);
