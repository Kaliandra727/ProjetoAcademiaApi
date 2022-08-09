namespace ProjetoAcademia.Poco;

public class InstrutorPoco
{
    public int IdInstrutor { get; set; }
        
    public string InstrutorCpf { get; set; }
        
    public string InstrutorNome { get; set; } = null!;
        
    public string InstrutorSexo { get; set; } = null!;
        
    public DateTime InstrutorDataNasc { get; set; }
        
    public string InstrutorEmail { get; set; } = null!;

    public int IdUsuario { get; set; }

    public bool? Situacao { get; set; }

    public int IdEndereco { get; set; }
}
