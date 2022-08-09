using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

public class InstrutorService : BaseEnvelopadaService<InstrutorPoco, Instrutor, InstrutorEnvelopeJSON>
{
    private InstrutorRepository repositorio;

    public InstrutorService(ProjetoAcademiaContext contexto) : base()
    {
        this.mapeador = new MapeadorGenericoEnvelopado<InstrutorPoco, Instrutor, InstrutorEnvelopeJSON>();
        this.repositorio = new InstrutorRepository(contexto);
    }
    public List<InstrutorEnvelopeJSON> Listar(int pular, int exibir)
    {
        List<Instrutor> listDom = this.repositorio.Read(pular, exibir).ToList();
        return this.ProcessarListaDOM(listDom);
    }

    protected override List<InstrutorEnvelopeJSON> ProcessarListaDOM(List<Instrutor> listDOM)
    {
        List<InstrutorEnvelopeJSON> lista = listDOM.Select(dom => this.mapeador.Mecanismo.Map<InstrutorEnvelopeJSON>(dom)).ToList();
        lista.ForEach(json => json.SetLinks());
        return lista;
    }

    public override InstrutorEnvelopeJSON Atualizar(InstrutorPoco obj)
    {   
        Instrutor instrutor = this.mapeador.Mecanismo.Map<Instrutor>(obj);
        Instrutor atualizado = this.repositorio.Update(instrutor);
        InstrutorEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutorEnvelopeJSON>(atualizado);
        json.SetLinks();
        return json;
    }

    public override InstrutorEnvelopeJSON Criar(InstrutorPoco obj)
    {
        Instrutor instrutor = this.mapeador.Mecanismo.Map<Instrutor>(obj);
        Instrutor criado = this.repositorio.Create(instrutor);
        InstrutorEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutorEnvelopeJSON>(criado);
        json.SetLinks();
        return json;
    }

    public override InstrutorEnvelopeJSON Selecionar(int id)
    {
        Instrutor selecionado = this.repositorio.Read(id);
        InstrutorEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutorEnvelopeJSON>(selecionado);
        json.SetLinks();
        return json;
    }

    public override InstrutorEnvelopeJSON Excluir(InstrutorPoco obj)
    {
        Instrutor instrutor = this.mapeador.Mecanismo.Map<Instrutor>(obj);
        Instrutor excluido = this.repositorio.Delete(instrutor);
        InstrutorEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutorEnvelopeJSON>(excluido);
        json.SetLinks();
        return json;
    }

    public override InstrutorEnvelopeJSON Excluir(int id)
    {
        Instrutor excluido = this.repositorio.DeleteById(id);
        InstrutorEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutorEnvelopeJSON>(excluido);
        json.SetLinks();
        return json;
    }

}
