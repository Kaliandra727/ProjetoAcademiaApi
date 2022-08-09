using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class AlunosPorTurmaService: BaseEnvelopadaService<AlunosPorTurmaPoco, AlunosPorTurma, AlunosPorTurmaEnvelopeJSON>
    {
        private AlunosPorTurmaRepository repositorio;

        public AlunosPorTurmaService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<AlunosPorTurmaPoco, AlunosPorTurma, AlunosPorTurmaEnvelopeJSON>();
            this.repositorio = new AlunosPorTurmaRepository(contexto);
        }

        public List<AlunosPorTurmaEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<AlunosPorTurma> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<AlunosPorTurmaEnvelopeJSON> ProcessarListaDOM(List<AlunosPorTurma> listDOM)
        {
            List<AlunosPorTurmaEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<AlunosPorTurmaEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override AlunosPorTurmaEnvelopeJSON Atualizar(AlunosPorTurmaPoco obj)
        {
            AlunosPorTurma temp = this.mapeador.Mecanismo.Map<AlunosPorTurma>(obj);
            AlunosPorTurma editado = this.repositorio.Update(temp);
            AlunosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunosPorTurmaEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override AlunosPorTurmaEnvelopeJSON Criar(AlunosPorTurmaPoco obj)
        {
            AlunosPorTurma temp = this.mapeador.Mecanismo.Map<AlunosPorTurma>(obj);
            AlunosPorTurma criado = this.repositorio.Create(temp);
            AlunosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunosPorTurmaEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override AlunosPorTurmaEnvelopeJSON Excluir(AlunosPorTurmaPoco obj)
        {
            AlunosPorTurma temp = this.mapeador.Mecanismo.Map<AlunosPorTurma>(obj);
            AlunosPorTurma excluido = this.repositorio.Delete(temp);
            AlunosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunosPorTurmaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override AlunosPorTurmaEnvelopeJSON Excluir(int id)
        {
            AlunosPorTurma excluido = this.repositorio.DeleteById(id);
            AlunosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunosPorTurmaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override AlunosPorTurmaEnvelopeJSON Selecionar(int id)
        {
            AlunosPorTurma selecionado = this.repositorio.Read(id);
            AlunosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<AlunosPorTurmaEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
