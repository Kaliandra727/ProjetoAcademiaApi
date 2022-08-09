namespace ProjetoAcademia.Poco;

public class CadastroPoco
{
    public int IdAluno { get; set; }

    public long AlunoMatricula { get; set; }

    public string AlunoCpf { get; set; }

    public string AlunoSexo { get; set; } = null!;

    public DateTime AlunoDataNasc { get; set; }

    public int IdUsuario {get; set;}

    public bool UsuarioAtivo {get; set;}

    public string NomeUsuario {get; set;}

    public string EmailUsuario {get; set;}

    public string SenhaUsuario {get; set;}

    public string TipoUsuario { get; set; }

    public int IdEndereco { get; set; }

    public int EnderecoCep { get; set; }

    public int EnderecoIdUf { get; set; }

    public string EnderecoUf { get; set; } = null!;
    
    public int EnderecoIdCidade { get; set; }

    public string EnderecoCidade { get; set; } = null!;

    public string EnderecoBairro { get; set; } = null!;

    public string EnderecoRua { get; set; } = null!;

    public int EnderecoNumero { get; set; }

    public string? EnderecoComplemento { get; set; }

}