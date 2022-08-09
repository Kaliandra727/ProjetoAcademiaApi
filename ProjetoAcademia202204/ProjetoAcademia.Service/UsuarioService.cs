using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class UsuarioService: BaseEnvelopadaService<UsuarioPoco, Usuario, UsuarioEnvelopeJSON>
    {
        private UsuarioRepository repositorio;

        public UsuarioService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<UsuarioPoco, Usuario, UsuarioEnvelopeJSON>();
            this.repositorio = new UsuarioRepository(contexto);
        }

        public List<UsuarioEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Usuario> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }

        public UsuarioPoco ValidarEmaileSenha(string email, string senha)
        {
            Usuario? dom = this.repositorio.Browse( usu => (usu.EmailUsuario == email) && (usu.SenhaUsuario == senha)).SingleOrDefault();
            if (dom == null)
            {
                return null;
            }
            else
            {
                UsuarioPoco poco = this.mapeador.Mecanismo.Map<UsuarioPoco>(dom);
                return poco;
            }

        }
        protected override List<UsuarioEnvelopeJSON> ProcessarListaDOM(List<Usuario> listDOM)
        {
            List<UsuarioEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<UsuarioEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override UsuarioEnvelopeJSON Atualizar(UsuarioPoco obj)
        {
            Usuario temp = this.mapeador.Mecanismo.Map<Usuario>(obj);
            Usuario editado = this.repositorio.Update(temp);
            UsuarioEnvelopeJSON json = this.mapeador.Mecanismo.Map<UsuarioEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override UsuarioEnvelopeJSON Criar(UsuarioPoco obj)
        {
            Usuario temp = this.mapeador.Mecanismo.Map<Usuario>(obj);
            Usuario criado = this.repositorio.Create(temp);
            UsuarioEnvelopeJSON json = this.mapeador.Mecanismo.Map<UsuarioEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override UsuarioEnvelopeJSON Excluir(UsuarioPoco obj)
        {
            Usuario temp = this.mapeador.Mecanismo.Map<Usuario>(obj);
            Usuario excluido = this.repositorio.Delete(temp);
            UsuarioEnvelopeJSON json = this.mapeador.Mecanismo.Map<UsuarioEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override UsuarioEnvelopeJSON Excluir(int id)
        {
            Usuario excluido = this.repositorio.DeleteById(id);
            UsuarioEnvelopeJSON json = this.mapeador.Mecanismo.Map<UsuarioEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override UsuarioEnvelopeJSON Selecionar(int id)
        {
            Usuario selecionado = this.repositorio.Read(id);
            UsuarioEnvelopeJSON json = this.mapeador.Mecanismo.Map<UsuarioEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }
