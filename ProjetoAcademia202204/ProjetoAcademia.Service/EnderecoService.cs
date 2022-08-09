using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

 public class EnderecoService: BaseEnvelopadaService<EnderecoPoco, Endereco, EnderecoEnvelopeJSON>
    {
        private EnderecoRepository repositorio;

        public EnderecoService(ProjetoAcademiaContext contexto) : base()
        {
            this.mapeador = new MapeadorGenericoEnvelopado<EnderecoPoco, Endereco, EnderecoEnvelopeJSON>();
            this.repositorio = new EnderecoRepository(contexto);
        }

        public List<EnderecoEnvelopeJSON> Listar(int pular, int exibir)
        {
            List<Endereco> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }
        protected override List<EnderecoEnvelopeJSON> ProcessarListaDOM(List<Endereco> listDOM)
        {
            List<EnderecoEnvelopeJSON> lista =
                listDOM.Select(dom => this.mapeador.Mecanismo.Map<EnderecoEnvelopeJSON>(dom)).ToList();
            lista.ForEach(json => json.SetLinks());
            return lista;
        }

        public override EnderecoEnvelopeJSON Atualizar(EnderecoPoco obj)
        {
            Endereco temp = this.mapeador.Mecanismo.Map<Endereco>(obj);
            Endereco editado = this.repositorio.Update(temp);
            EnderecoEnvelopeJSON json = this.mapeador.Mecanismo.Map<EnderecoEnvelopeJSON>(editado);
            json.SetLinks();
            return json;
        }

        public override EnderecoEnvelopeJSON Criar(EnderecoPoco obj)
        {
            Endereco temp = this.mapeador.Mecanismo.Map<Endereco>(obj);
            Endereco criado = this.repositorio.Create(temp);
            EnderecoEnvelopeJSON json = this.mapeador.Mecanismo.Map<EnderecoEnvelopeJSON>(criado);
            json.SetLinks();
            return json;
        }

        public override EnderecoEnvelopeJSON Excluir(EnderecoPoco obj)
        {
            Endereco temp = this.mapeador.Mecanismo.Map<Endereco>(obj);
            Endereco excluido = this.repositorio.Delete(temp);
            EnderecoEnvelopeJSON json = this.mapeador.Mecanismo.Map<EnderecoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }

        public override EnderecoEnvelopeJSON Excluir(int id)
        {
            Endereco excluido = this.repositorio.DeleteById(id);
            EnderecoEnvelopeJSON json = this.mapeador.Mecanismo.Map<EnderecoEnvelopeJSON>(excluido);
            json.SetLinks();
            return json;
        }
        public override EnderecoEnvelopeJSON Selecionar(int id)
        {
            Endereco selecionado = this.repositorio.Read(id);
            EnderecoEnvelopeJSON json = this.mapeador.Mecanismo.Map<EnderecoEnvelopeJSON>(selecionado);
            json.SetLinks();
            return json;
        }
    }

