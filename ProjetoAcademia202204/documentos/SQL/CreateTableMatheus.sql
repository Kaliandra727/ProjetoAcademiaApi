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