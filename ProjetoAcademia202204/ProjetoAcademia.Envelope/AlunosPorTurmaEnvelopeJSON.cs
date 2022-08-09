using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

    public class AlunosPorTurmaEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "idalunoturma")]
        public int IdAlunoTurma { get; set; }

        [JsonProperty(PropertyName = "idturma")]
        public int IdTurma { get; set; }

        [JsonProperty(PropertyName = "idaluno")]
        public int IdAluno { get; set; }
		
		[JsonProperty(PropertyName = "situacao")]
        public bool? Situacao { get; set; }

        public override void SetLinks()
        {
            Links.List = "GET /alunoTurma ";
            Links.Self = "GET /alunoTurma /" + IdAlunoTurma.ToString();
            Links.Exclude = "DELETE /alunoTurma /" + IdAlunoTurma.ToString();
            Links.Update = "PUT /alunoTurma ";
            Links.Create = "POST /alunoTurma ";
        }
    }

