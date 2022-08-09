using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class TurmaService: BaseEnvelopadaService<TurmaPoco, Turma, TurmaEnvelopeJSON>
    {
        private TurmaRepository repositorio;

        public TurmaService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<TurmaPoco, Turma, TurmaEnvelopeJSON>();
            this.repositorio = new TurmaRepository(contexto);
        }

        public List<TurmaEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Turma> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<TurmaEnvelopeJSON> ProcessarListaDOM(List<Turma> listDOM)
        {
            List<TurmaEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<TurmaEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override TurmaEnvelopeJSON Atualizar(TurmaPoco obj)
        {
            Turma temp = this.mapeador.Mecanismo.Map<Turma>(obj);
            Turma editado = this.repositorio.Update(temp);
            TurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TurmaEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override TurmaEnvelopeJSON Criar(TurmaPoco obj)
        {
            Turma temp = this.mapeador.Mecanismo.Map<Turma>(obj);
            Turma criado = this.repositorio.Create(temp);
            TurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TurmaEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override TurmaEnvelopeJSON Excluir(TurmaPoco obj)
        {
            Turma temp = this.mapeador.Mecanismo.Map<Turma>(obj);
            Turma excluido = this.repositorio.Delete(temp);
            TurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TurmaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override TurmaEnvelopeJSON Excluir(int id)
        {
            Turma excluido = this.repositorio.DeleteById(id);
            TurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TurmaEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override TurmaEnvelopeJSON Selecionar(int id)
        {
            Turma selecionado = this.repositorio.Read(id);
            TurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<TurmaEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
