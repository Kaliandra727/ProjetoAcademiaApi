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
