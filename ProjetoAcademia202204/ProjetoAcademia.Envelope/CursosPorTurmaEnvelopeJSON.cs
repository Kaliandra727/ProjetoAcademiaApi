using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

public class CursosPorTurmaEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "idcursoporturma")]
        public int IdCursoTurma { get; set; }

        [JsonProperty(PropertyName = "idturma")]
        public int IdTurma  { get; set; }
		
		[JsonProperty(PropertyName = "idcurso")]
        public int IdCurso { get; set; }
		
		[JsonProperty(PropertyName = "situacao")]
        public bool? Situacao { get; set; }

        public override void SetLinks()
        {
            Links.List = "GET /cursoPorTurma ";
            Links.Self = "GET /cursoPorTurma /" + IdCursoTurma.ToString();
            Links.Exclude = "DELETE /cursoPorTurma /" + IdCursoTurma.ToString();
            Links.Update = "PUT /cursoPorTurma ";
            Links.Create = "POST /cursoPorTurma ";
        }
    }