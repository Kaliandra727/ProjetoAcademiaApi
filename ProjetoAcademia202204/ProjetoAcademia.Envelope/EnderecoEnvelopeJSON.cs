using Newtonsoft.Json;

namespace ProjetoAcademia.Envelope;
public class EnderecoEnvelopeJSON : BaseEnvelopeJSON

    {
        [JsonProperty(PropertyName = "idendereco")]
        public int IdEndereco { get; set; }

        [JsonProperty(PropertyName = "cep")]
        public int EnderecoCep  { get; set; }
		
		[JsonProperty(PropertyName = "iduf")]
        public int EnderecoIdUf { get; set; }
		
		[JsonProperty(PropertyName = "uf")]
        public string EnderecoUf { get; set; } = null!;
		
		[JsonProperty(PropertyName = "idcidade")]
		public int EnderecoIdCidade { get; set; }

		[JsonProperty(PropertyName = "cidade")]
		public string EnderecoCidade { get; set; } = null!;
		
		[JsonProperty(PropertyName = "bairro")]
		public string EnderecoBairro { get; set; } = null!;
		
		[JsonProperty(PropertyName = "rua")]
		public string EnderecoRua { get; set; } = null!;
		
		[JsonProperty(PropertyName = "numero")]
		public int EnderecoNumero { get; set; }
		
		[JsonProperty(PropertyName = "complemento")]
		public string? EnderecoComplemento { get; set; }
		
		[JsonProperty(PropertyName = "situacao")]
		public bool? Situacao { get; set; }
		
        public override void SetLinks()
        {
            Links.List = "GET /endereco ";
            Links.Self = "GET /endereco /" + IdEndereco.ToString();
            Links.Exclude = "DELETE /endereco /" + IdEndereco.ToString();
            Links.Update = "PUT /endereco ";
            Links.Create = "POST /endereco ";
        }
    }