using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;

    public class AlunoEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "idaluno")]
        public int IdAluno { get; set; }

        [JsonProperty(PropertyName = "matricula")]
        public long AlunoMatricula { get; set; }

        [JsonProperty(PropertyName = "cpf")]
        public string AlunoCpf { get; set; } = null!;

        [JsonProperty(PropertyName = "nome")]
        public string AlunoNome { get; set; } = null!;

        [JsonProperty(PropertyName = "sexo")]
        public string AlunoSexo { get; set; } = null!;

        [JsonProperty(PropertyName = "datanascimento")]
        public DateTime AlunoDataNasc { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string AlunoEmail { get; set; } = null!;

        [JsonProperty(PropertyName = "idendereco")]
        public int IdEndereco { get; set; }
		
		[JsonProperty(PropertyName = "idusuario")]
        public int IdUsuario { get; set; }
		
		[JsonProperty(PropertyName = "situacao")]
        public bool? Situacao { get; set; }

        public override void SetLinks()
        {
            Links.List = "GET /aluno ";
            Links.Self = "GET /aluno /" + IdAluno.ToString();
            Links.Exclude = "DELETE /aluno /" + IdAluno.ToString();
            Links.Update = "PUT /aluno ";
            Links.Create = "POST /aluno ";
        }
    }
