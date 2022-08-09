using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

public class InstrutorEnvelopeJSON : BaseEnvelopeJSON
{
    [JsonProperty(PropertyName = "idinstrutor")]

    public int IdInstrutor { get; set; }

    [JsonProperty(PropertyName = "cpf")]

    public string InstrutorCpf { get; set; }

    [JsonProperty(PropertyName = "nome")]

    public string InstrutorNome { get; set; }

    [JsonProperty(PropertyName = "sexo")]

    public string InstrutorSexo { get; set; }


    [JsonProperty(PropertyName = "datanasc")]

    public DateTime InstrutorDataNasc { get; set; }


    [JsonProperty(PropertyName = "email")]

    public string InstrutorEmail { get; set; }


    [JsonProperty(PropertyName = "idusuario")]

    public int IdUsuario { get; set; }


    [JsonProperty(PropertyName = "situacao")]

    public bool? Situacao { get; set; }

    [JsonProperty(PropertyName = "idendereco")]
    public int IdEndereco { get; set; }


    public override void SetLinks()
    {
        this.Links.List = "GET /instrutor";
        this.Links.Self = "GET /instrutor/" + this.IdInstrutor.ToString();
        this.Links.Exclude = "DELETE /instrutor/" + this.IdInstrutor.ToString();
        this.Links.Update = "PUT /instrutor";
        this.Links.Create = "POST /instrutor";
    }
}
