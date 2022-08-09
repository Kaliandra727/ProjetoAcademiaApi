using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class CursoService: BaseEnvelopadaService<CursoPoco, Curso, CursoEnvelopeJSON>
    {
        private CursoRepository repositorio;

        public CursoService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<CursoPoco, Curso, CursoEnvelopeJSON>();
            this.repositorio = new CursoRepository(contexto);
        }

        public List<CursoEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Curso> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<CursoEnvelopeJSON> ProcessarListaDOM(List<Curso> listDOM)
        {
            List<CursoEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<CursoEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override CursoEnvelopeJSON Atualizar(CursoPoco obj)
        {
            Curso temp = this.mapeador.Mecanismo.Map<Curso>(obj);
            Curso editado = this.repositorio.Update(temp);
            CursoEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursoEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override CursoEnvelopeJSON Criar(CursoPoco obj)
        {
            Curso temp = this.mapeador.Mecanismo.Map<Curso>(obj);
            Curso criado = this.repositorio.Create(temp);
            CursoEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursoEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override CursoEnvelopeJSON Excluir(CursoPoco obj)
        {
            Curso temp = this.mapeador.Mecanismo.Map<Curso>(obj);
            Curso excluido = this.repositorio.Delete(temp);
            CursoEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override CursoEnvelopeJSON Excluir(int id)
        {
            Curso excluido = this.repositorio.DeleteById(id);
            CursoEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override CursoEnvelopeJSON Selecionar(int id)
        {
            Curso selecionado = this.repositorio.Read(id);
            CursoEnvelopeJSON json = this.mapeador.Mecanismo.Map<CursoEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
