
using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service
{
    public class CadastroService
    {
        private CadastroRepository cadRepository;
        private ProjetoAcademiaContext contexto;
        private MapeadorGenerico<AlunoPoco, Aluno> mapAluno;
        private MapeadorGenerico<UsuarioPoco, Usuario> mapUsuario;
        private MapeadorGenerico<EnderecoPoco, Endereco> mapEndereco;

        private List<string> mensagensProcessamento;

        public List<string> MensagensProcessamento
        { 
            get { return this.mensagensProcessamento;}
        }

        public CadastroService(ProjetoAcademiaContext contexto)
        {
            this.contexto = contexto;

            this.cadRepository = new CadastroRepository(this.contexto);
 
            this.mapAluno = new MapeadorGenerico<AlunoPoco, Aluno>();
            this.mapUsuario = new MapeadorGenerico<UsuarioPoco, Usuario>();
            this.mapEndereco = new MapeadorGenerico<EnderecoPoco, Endereco>();
            this.mensagensProcessamento = new List<string>();
        }

        public bool Persistir(CadastroPoco obj)
        {
            bool situacao = true;

            Usuario usuario = new Usuario(){
                UsuarioAtivo = obj.UsuarioAtivo,
                IdUsuario = obj.IdUsuario,
                NomeUsuario = obj.NomeUsuario,
                SenhaUsuario = obj.SenhaUsuario,
                EmailUsuario = obj.EmailUsuario,
                TipoUsuario = obj.TipoUsuario,
                Situacao = situacao
            };

            Endereco endereco = new Endereco(){
                IdEndereco = obj.IdEndereco,
                EnderecoBairro = obj.EnderecoBairro,
                EnderecoCep = obj.EnderecoCep,
                EnderecoCidade = obj.EnderecoCidade,
                EnderecoComplemento = obj.EnderecoComplemento,
                EnderecoIdCidade = obj.EnderecoIdCidade,
                EnderecoIdUf = obj.EnderecoIdUf,
                EnderecoNumero = obj.EnderecoNumero,
                EnderecoRua = obj.EnderecoRua,
                EnderecoUf = obj.EnderecoUf,
                Situacao = situacao
            };

            DateTime dt = DateTime.Now;

            string ano = dt.Year.ToString();
            string mes = dt.Month.ToString();
            string dia = dt.Day.ToString();
            string hora = dt.Hour.ToString();
            string min = dt.Minute.ToString();
            string sec = dt.Second.ToString();

            string val = ano + mes + dia + hora + min + sec;
            long valor = Convert.ToInt64(val);

            Aluno aluno = new Aluno(){
                AlunoCpf = obj.AlunoCpf,
                AlunoDataNasc = obj.AlunoDataNasc,
                AlunoEmail = obj.EmailUsuario,
                AlunoMatricula = valor,
                AlunoNome = obj.NomeUsuario,
                AlunoSexo = obj.AlunoSexo,
                IdAluno = obj.IdAluno,
                Situacao = situacao
            };

            try
            {
                return this.cadRepository.Create(usuario, endereco, aluno);
            }
            catch (Exception ex)
            {
                this.mensagensProcessamento.Add(ex.Message);
                return false;
            }
        }
    }
}