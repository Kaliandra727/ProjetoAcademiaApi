using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

public class PeriodoEnvelopeJSON : BaseEnvelopeJSON
{
    [JsonProperty(PropertyName = "idperiodo")]
    public int IdPeriodo { get; set; }

    [JsonProperty(PropertyName = "periodo")]
    public string PeriodoDescricao { get; set; }

    [JsonProperty(PropertyName = "situacao")]  
    public bool? Situacao { get; set; }      

    public override void SetLinks()
    {
            this.Links.List = "GET /periodo";
            this.Links.Self = "GET /periodo/" + this.IdPeriodo.ToString();
            this.Links.Exclude = "DELETE /periodo/" + this.IdPeriodo.ToString();
            this.Links.Update = "PUT /periodo";
            this.Links.Create = "POST /periodo";
    }
}
