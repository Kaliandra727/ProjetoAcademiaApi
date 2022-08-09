namespace ProjetoAcademia.Poco;

public class UsuarioPoco
{
    public int IdUsuario {get; set;}

    public bool UsuarioAtivo {get; set;}

    public string NomeUsuario {get; set;}

    public string EmailUsuario {get; set;}

    public string SenhaUsuario {get; set;}

    public bool? Situacao {get; set;}

    public string TipoUsuario { get; set; }
}
