using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

public class UsuarioEnvelopeJSON : BaseEnvelopeJSON
{
    [JsonProperty(PropertyName = "idusuario")]
    public int IdUsuario { get; set; }

    [JsonProperty(PropertyName = "usuarioativo")]
    public bool UsuarioAtivo { get; set; }

    [JsonProperty(PropertyName = "nome")]
    public string NomeUsuario { get; set; }

    [JsonProperty(PropertyName = "email")]
    public string EmailUsuario { get; set; }

    [JsonProperty(PropertyName = "senha")]
    public string SenhaUsuario { get; set; }

    [JsonProperty(PropertyName = "situacao")]
    public bool? Situacao { get; set; }

    [JsonProperty(PropertyName = "tipousuario")]
    public string TipoUsuario { get; set; } = null!;

    public override void SetLinks()
    {
            this.Links.List = "GET /usuario";
            this.Links.Self = "GET /usuario/" + this.IdUsuario.ToString();
            this.Links.Exclude = "DELETE /usuario/" + this.IdUsuario.ToString();
            this.Links.Update = "PUT /usuario";
            this.Links.Create = "POST /usuario";
    }
}
