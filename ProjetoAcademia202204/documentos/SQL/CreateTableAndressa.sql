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
