using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class PeriodoService: BaseEnvelopadaService<PeriodoPoco, Periodo, PeriodoEnvelopeJSON>
    {
        private PeriodoRepository repositorio;

        public PeriodoService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<PeriodoPoco, Periodo, PeriodoEnvelopeJSON>();
            this.repositorio = new PeriodoRepository(contexto);
        }

        public List<PeriodoEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Periodo> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<PeriodoEnvelopeJSON> ProcessarListaDOM(List<Periodo> listDOM)
        {
            List<PeriodoEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<PeriodoEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override PeriodoEnvelopeJSON Atualizar(PeriodoPoco obj)
        {
            Periodo temp = this.mapeador.Mecanismo.Map<Periodo>(obj);
            Periodo editado = this.repositorio.Update(temp);
            PeriodoEnvelopeJSON json = this.mapeador.Mecanismo.Map<PeriodoEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override PeriodoEnvelopeJSON Criar(PeriodoPoco obj)
        {
            Periodo temp = this.mapeador.Mecanismo.Map<Periodo>(obj);
            Periodo criado = this.repositorio.Create(temp);
            PeriodoEnvelopeJSON json = this.mapeador.Mecanismo.Map<PeriodoEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override PeriodoEnvelopeJSON Excluir(PeriodoPoco obj)
        {
            Periodo temp = this.mapeador.Mecanismo.Map<Periodo>(obj);
            Periodo excluido = this.repositorio.Delete(temp);
            PeriodoEnvelopeJSON json = this.mapeador.Mecanismo.Map<PeriodoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override PeriodoEnvelopeJSON Excluir(int id)
        {
            Periodo excluido = this.repositorio.DeleteById(id);
            PeriodoEnvelopeJSON json = this.mapeador.Mecanismo.Map<PeriodoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override PeriodoEnvelopeJSON Selecionar(int id)
        {
            Periodo selecionado = this.repositorio.Read(id);
            PeriodoEnvelopeJSON json = this.mapeador.Mecanismo.Map<PeriodoEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
