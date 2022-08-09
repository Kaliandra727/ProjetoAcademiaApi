using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

public class InstrutoresPorTurmaEnvelopeJSON : BaseEnvelopeJSON
{
    [JsonProperty(PropertyName = "idinstrutorturma")]
    public int IdInstrutorTurma { get; set; }

    [JsonProperty(PropertyName = "idturma")]
    public int IdTurma { get; set; }

    [JsonProperty(PropertyName = "idinstrutor")]
    public int IdInstrutor { get; set; }

    [JsonProperty(PropertyName = "situacao")]
    public bool? Situacao { get; set; }

    public override void SetLinks()
    {
            this.Links.List = "GET /instrutorturma";
            this.Links.Self = "GET /instrutorturma/" + this.IdInstrutorTurma.ToString();
            this.Links.Exclude = "DELETE /instrutorturma/" + this.IdInstrutorTurma.ToString();
            this.Links.Update = "PUT /instrutorturma";
            this.Links.Create = "POST /instrutorturma";
    }
}
