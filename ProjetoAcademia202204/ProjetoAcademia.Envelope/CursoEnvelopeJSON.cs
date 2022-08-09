using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

     public class CursoEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "idcurso")]
        public int IdCurso { get; set; }

        [JsonProperty(PropertyName = "nomecurso")]
        public string NomeCurso { get; set; } = null!;
		
		[JsonProperty(PropertyName = "situacao")]
        public bool? Situacao { get; set; }

        [JsonProperty(PropertyName = "idperiodo")]
        public int IdPeriodo { get; set; }

        public override void SetLinks()
        {
            Links.List = "GET /curso ";
            Links.Self = "GET /curso /" + IdCurso.ToString();
            Links.Exclude = "DELETE /curso /" + IdCurso.ToString();
            Links.Update = "PUT /curso ";
            Links.Create = "POST /curso ";
        }
    }
