using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

public class TurmaEnvelopeJSON : BaseEnvelopeJSON
{
    [JsonProperty(PropertyName = "idturma")]
    public int IdTurma { get; set; }

    [JsonProperty(PropertyName = "turmatag")]
    public string TurmaTag { get; set; }

    [JsonProperty(PropertyName = "situacao")] 
    public bool? Situacao { get; set; }           
    public override void SetLinks()
    {
        this.Links.List = "GET /turma";
        this.Links.Self = "GET /turma/" + this.IdTurma.ToString();
        this.Links.Exclude = "DELETE /turma/" + this.IdTurma.ToString();
        this.Links.Update = "PUT /turma";
        this.Links.Create = "POST /turma";
    }
}
