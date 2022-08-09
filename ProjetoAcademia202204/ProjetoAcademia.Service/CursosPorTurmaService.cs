using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class CursosPorTurmaService: BaseEnvelopadaService<CursosPorTurmaPoco, CursosPorTurma, CursosPorTurmaEnvelopeJSON>
    {
        private CursosPorTurmaRepository repositorio;

        public CursosPorTurmaService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<CursosPorTurmaPoco, CursosPorTurma, CursosPorTurmaEnvelopeJSON>();
            this.repositorio = new CursosPorTurmaRepository(contexto);
        }

        public List<CursosPorTurmaEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<CursosPorTurma> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<CursosPorTurmaEnvelopeJSON> ProcessarListaDOM(List<CursosPorTurma> listDOM)
        {
            List<CursosPorTurmaEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<CursosPorTurmaEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override CursosPorTurmaEnvelopeJSON Atualizar(CursosPorTurmaPoco obj)
        {
            CursosPorTurma temp = this.mapeador.Mecanismo.Map<CursosPorTurma>(obj);
            CursosPorTurma editado = this.repositorio.Update(temp);
            CursosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursosPorTurmaEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override CursosPorTurmaEnvelopeJSON Criar(CursosPorTurmaPoco obj)
        {
            CursosPorTurma temp = this.mapeador.Mecanismo.Map<CursosPorTurma>(obj);
            CursosPorTurma criado = this.repositorio.Create(temp);
            CursosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursosPorTurmaEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override CursosPorTurmaEnvelopeJSON Excluir(CursosPorTurmaPoco obj)
        {
            CursosPorTurma temp = this.mapeador.Mecanismo.Map<CursosPorTurma>(obj);
            CursosPorTurma excluido = this.repositorio.Delete(temp);
            CursosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursosPorTurmaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override CursosPorTurmaEnvelopeJSON Excluir(int id)
        {
            CursosPorTurma excluido = this.repositorio.DeleteById(id);
            CursosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursosPorTurmaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override CursosPorTurmaEnvelopeJSON Selecionar(int id)
        {
            CursosPorTurma selecionado = this.repositorio.Read(id);
            CursosPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursosPorTurmaEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
