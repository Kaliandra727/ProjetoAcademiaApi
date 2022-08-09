namespace ProjetoAcademia.Poco;

public class EnderecoPoco
{
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

    public bool? Situacao { get; set; }
}
