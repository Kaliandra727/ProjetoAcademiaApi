using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class AlunoService: BaseEnvelopadaService<AlunoPoco, Aluno, AlunoEnvelopeJSON>
    {
        private AlunoRepository repositorio;

        public AlunoService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<AlunoPoco, Aluno, AlunoEnvelopeJSON>();
            this.repositorio = new AlunoRepository(contexto);
        }

        public List<AlunoEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Aluno> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<AlunoEnvelopeJSON> ProcessarListaDOM(List<Aluno> listDOM)
        {
            List<AlunoEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<AlunoEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override AlunoEnvelopeJSON Atualizar(AlunoPoco obj)
        {
            Aluno temp = this.mapeador.Mecanismo.Map<Aluno>(obj);
            Aluno editado = this.repositorio.Update(temp);
            AlunoEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunoEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override AlunoEnvelopeJSON Criar(AlunoPoco obj)
        {
            Aluno temp = this.mapeador.Mecanismo.Map<Aluno>(obj);
            Aluno criado = this.repositorio.Create(temp);
            AlunoEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunoEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override AlunoEnvelopeJSON Excluir(AlunoPoco obj)
        {
            Aluno temp = this.mapeador.Mecanismo.Map<Aluno>(obj);
            Aluno excluido = this.repositorio.Delete(temp);
            AlunoEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override AlunoEnvelopeJSON Excluir(int id)
        {
            Aluno excluido = this.repositorio.DeleteById(id);
            AlunoEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override AlunoEnvelopeJSON Selecionar(int id)
        {
            Aluno selecionado = this.repositorio.Read(id);
            AlunoEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunoEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }

         public AlunoPoco SelecionarUsuario(int usuario){
            Aluno? dom = this.repositorio.Browse( alu => alu.IdUsuario == usuario).SingleOrDefault();
            if (dom == null)
            {
                return null;
            }
            else
            {
                AlunoPoco poco = this.mapeador.Mecanismo.Map<AlunoPoco>(dom);
                return poco;
            }
         }
    }
