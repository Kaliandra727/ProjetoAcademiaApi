namespace ProjetoAcademia.Poco;

public class RelatorioPorTurmaPoco
{
    public int IdTurma {get; set;}

    public int IdAlunoTurma {get; set;}

    public string TurmaTag {get; set;} = null!;

    public int IdCurso {get; set;}

    public string NomeCurso {get; set;} = null!;

    public int IdInstrutor {get; set;}

    public string InstrutorNome {get; set;} = null!;

    public int IdPeriodo {get; set;}

    public int IdAluno {get; set;}

    public string NomeAluno {get; set;} = null!;

    public string PeriodoDescricao {get; set;} = null!;
}
