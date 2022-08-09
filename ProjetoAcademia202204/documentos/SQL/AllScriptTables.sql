create table Usuario(
	IdUsuario int not null identity(1,1),
    UsuarioAtivo bit not null,
    NomeUsuario varchar(max) not null,
	EmailUsuario varchar(max) not null,
	SenhaUsuario varchar(max) not null,
	Situacao bit NULL DEFAULT 1,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdUsuario PRIMARY KEY(IdUsuario)
)
GO
create table Curso(
	IdCurso int not null identity(1,1),
	NomeCurso varchar(max) not null,
    Situacao bit NULL DEFAULT 1,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdCurso PRIMARY KEY(IdCurso)
)
GO
create table Periodo(
	IdPeriodo int  not null identity(1,1), 
	PeriodoDescricao varchar(MAX) not null,
    Situacao bit NULL DEFAULT 1,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdPeriodo PRIMARY KEY (IdPeriodo)
)
go

create table Endereco(
	IdEndereco int not null identity (1,1) , 
	EnderecoCep int not null,
    EnderecoIdUf int not null,
    EnderecoUf varchar(2) not null,
	EnderecoIdCidade int not null,
	EnderecoCidade varchar(MAX) not null,
	EnderecoBairro varchar(MAX) not null,
	EnderecoRua varchar(MAX) not null,
	EnderecoNumero int,
	EnderecoComplemento varchar(MAX),
    Situacao bit NULL DEFAULT 1,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdEndereco PRIMARY KEY (IdEndereco)
)
go

create table Instrutor(
	IdInstrutor int not null identity(1,1), 
    InstrutorCpf varchar(14),
    InstrutorNome varchar(MAX) not null,
    InstrutorSexo varchar(2) not null,
	InstrutorDataNasc date not null,
    InstrutorEmail varchar(MAX) not null,
    UsuarioId int not null,
    Situacao bit NULL DEFAULT 1,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdInstrutor PRIMARY KEY (IdInstrutor)
)
go
create table Aluno(
	IdAluno int not null identity(1,1),
	AlunoMatricula int not null,
    AlunoCpf varchar(14),
    AlunoNome varchar(max) not null,
    AlunoSexo varchar(1) not null,
	AlunoDataNasc date not null,
    AlunoEmail varchar(max) not null,
    IdEndereco int not null,
    IdUsuario int not null,
    Situacao bit NULL,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdAluno PRIMARY KEY (IdAluno)
)
GO

create table Turma(
	IdTurma int not null identity(1,1),
	TurmaTag varchar(max) not null,
	Situacao bit NULL,
	DataInclusao datetime NULL default getdate(),
	DataAlteracao datetime NULL,
	DataExclusao datetime NULL
	CONSTRAINT PKIdTurma PRIMARY KEY (IdTurma)
)
GO
CREATE TABLE CursosPorTurma(
	IdCursoTurma INT NOT NULL IDENTITY(1,1),
	IdTurma INT NOT NULL,
	IdCurso INT NOT NULL,
	Situacao BIT NULL DEFAULT 1,
	DataInclusao DATETIME NULL DEFAULT GETDATE(),
	DataAlteracao DATETIME NULL,
	DataExclusao DATETIME NULL,
	CONSTRAINT PKIdCursoTurma PRIMARY KEY (IdCursoTurma)
)
GO

CREATE TABLE AlunosPorTurma(
	IdAlunoTurma INT NOT NULL IDENTITY(1,1),
	IdTurma INT NOT NULL,
	IdAluno INT NOT NULL,
	Situacao BIT NULL DEFAULT 1,
	DataInclusao DATETIME NULL DEFAULT GETDATE(),
	DataAlteracao DATETIME NULL,
	DataExclusao DATETIME NULL,
	CONSTRAINT PKIdAlunoTurma PRIMARY KEY (IdAlunoTurma)	
)
GO

CREATE TABLE InstrutoresPorTurma(
	IdInstrutorTurma INT NOT NULL IDENTITY(1,1),
	IdTurma INT NOT NULL,
	IdInstrutor INT NOT NULL,
	Situacao BIT NULL DEFAULT 1,
	DataInclusao DATETIME NULL DEFAULT GETDATE(),
	DataAlteracao DATETIME NULL,
	DataExclusao DATETIME NULL,
	CONSTRAINT PKIdInstrutorTurma PRIMARY KEY (IdInstrutorTurma)	
)
GO
