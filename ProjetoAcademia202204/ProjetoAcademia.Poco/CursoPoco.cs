namespace ProjetoAcademia.Poco;

public class CursoPoco
{
    public int IdCurso { get; set; }

    public string NomeCurso { get; set; } = null!;
    
    public bool? Situacao { get; set; }

    public int IdPeriodo { get; set; }
}
