CREATE DATABASE ProjetoAcademia202204
use ProjetoAcademia202204;

create table Usuario(
	usuario_id int primary key identity(1,1) not null,
    usuario_ativo bit not null,
    usuario_nome varchar(max) not null,
	usuario_email varchar(max) not null,
	usuario_senha varchar(64) not null
)

create table Curso(
	curso_id int primary key not null identity(1,1),
	curso_nome varchar(max) not null,
    Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table Periodo(
	periodo_id int primary key  not null identity(1,1),
	periodo_descricao varchar(10) not null,
    Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table Endereco(
	endereco_id int primary key identity(1,1) not null,
	endereco_cep int not null,
    endereco_id_uf int not null,
    endereco_uf varchar(2) not null,
	endereco_id_cidade int not null,
	endereco_cidade varchar(30) not null,
	endereco_bairro varchar(30) not null,
	endereco_rua varchar(30) not null,
	endereco_numero int,
	endereco_complemento varchar(30),
    Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table Instrutor(
	instrutor_id int not null primary key identity(1,1),
    instrutor_cpf varchar(14),
    instrutor_nome varchar(50) not null,
    instrutor_sexo varchar(20) not null,
	instrutor_data_nasc date not null,
    instrutor_email varchar(50) not null,
    usuario_id int not null,
    Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table Aluno(
	aluno_id int not null primary key identity(1,1),
	aluno_matricula int not null,
    aluno_cpf varchar(14),
    aluno_nome varchar(50) not null,
    aluno_sexo varchar(20) not null,
	aluno_data_nasc date not null,
    aluno_email varchar(50) not null,
    endereco_id int not null,
    usuario_id int not null,
    Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table Turma(
	turma_id int not null primary key identity(1,1),
	turma_tag varchar(10) not null,
	Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table CursosPorTurma(
	cursoturma_id int not null primary key identity(1,1),
	turma_id int not null,
	curso_id int not null,
	Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)

create table AlunosPorTurma(
	alunoturma_id int not null primary key identity(1,1),
	turma_id int not null,
	aluno_id int not null,
	Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL	
)

create table InstrutoresPorTurma(
	instrutorturma_id int not null primary key identity(1,1),
	turma_id int not null,
	instrutor_id int not null,
	Situacao bit NULL,
	DataInclusao datetime NULL default(getdate()),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
)


