namespace ProjetoAcademia.Poco;

public class AlunoPoco
{
    public int IdAluno { get; set; }

    public long AlunoMatricula { get; set; }

    public string AlunoCpf { get; set; }

    public string AlunoNome { get; set; } = null!;

    public string AlunoSexo { get; set; } = null!;

    public DateTime AlunoDataNasc { get; set; }

    public string AlunoEmail { get; set; } = null!;

    public int IdEndereco { get; set; }

    public int IdUsuario { get; set; }

    public bool? Situacao { get; set; }
}
