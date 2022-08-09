using ProjetoAcademia.EF.Database;
using ProjetoAcademia.Envelope;
using ProjetoAcademia.Mapper;
using ProjetoAcademia.Poco;
using ProjetoAcademia.Repository;

namespace ProjetoAcademia.Service;

public class InstrutoresPorTurmaService : BaseEnvelopadaService<InstrutoresPorTurmaPoco, InstrutoresPorTurma, InstrutoresPorTurmaEnvelopeJSON>
{
      private InstrutoresPorTurmaRepository repositorio;

    public InstrutoresPorTurmaService(ProjetoAcademiaContext contexto) : base()
    {
        this.mapeador = new MapeadorGenericoEnvelopado<InstrutoresPorTurmaPoco, InstrutoresPorTurma, InstrutoresPorTurmaEnvelopeJSON>();
        this.repositorio = new InstrutoresPorTurmaRepository(contexto);
    }
    public List<InstrutoresPorTurmaEnvelopeJSON> Listar(int pular, int exibir)
    {
        List<InstrutoresPorTurma> listDom = this.repositorio.Read(pular, exibir).ToList();
        return this.ProcessarListaDOM(listDom);
    }

    protected override List<InstrutoresPorTurmaEnvelopeJSON> ProcessarListaDOM(List<InstrutoresPorTurma> listDOM)
    {
        List<InstrutoresPorTurmaEnvelopeJSON> lista = listDOM.Select(dom => this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(dom)).ToList();
        lista.ForEach(json => json.SetLinks());
        return lista;
    }

    public override InstrutoresPorTurmaEnvelopeJSON Atualizar(InstrutoresPorTurmaPoco obj)
    {   
        // InstrutoresPorTurma InstrutoresPorTurma = this.mapeador.Mecanismo.Map<InstrutoresPorTurma>(obj);
        // InstrutoresPorTurma atualizado = this.repositorio.Update(InstrutoresPorTurma);
        // InstrutoresPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(atualizado);
        // json.SetLinks();
        // return json;

        //Adicionado pelo programador 01/08/2022
        InstrutoresPorTurma selecionado = this.repositorio.Read(obj.IdInstrutorTurma);
        selecionado.IdInstrutor = obj.IdInstrutor;
        selecionado.IdTurma = obj.IdTurma;
        selecionado.Situacao = obj.Situacao;
        InstrutoresPorTurma atualizado = this.repositorio.Update(selecionado);
        InstrutoresPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(atualizado);
        json.SetLinks();
        return json;
    }

    public override InstrutoresPorTurmaEnvelopeJSON Criar(InstrutoresPorTurmaPoco obj)
    {
        InstrutoresPorTurma InstrutoresPorTurma = this.mapeador.Mecanismo.Map<InstrutoresPorTurma>(obj);
        InstrutoresPorTurma criado = this.repositorio.Create(InstrutoresPorTurma);
        InstrutoresPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(criado);
        json.SetLinks();
        return json;
    }

    public override InstrutoresPorTurmaEnvelopeJSON Selecionar(int id)
    {
        InstrutoresPorTurma selecionado = this.repositorio.Read(id);
        InstrutoresPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(selecionado);
        json.SetLinks();
        return json;
    }

    public override InstrutoresPorTurmaEnvelopeJSON Excluir(InstrutoresPorTurmaPoco obj)
    {
        InstrutoresPorTurma InstrutoresPorTurma = this.mapeador.Mecanismo.Map<InstrutoresPorTurma>(obj);
        InstrutoresPorTurma excluido = this.repositorio.Delete(InstrutoresPorTurma);
        InstrutoresPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(excluido);
        json.SetLinks();
        return json;
    }

    public override InstrutoresPorTurmaEnvelopeJSON Excluir(int id)
    {
        InstrutoresPorTurma excluido = this.repositorio.DeleteById(id);
        InstrutoresPorTurmaEnvelopeJSON json = this.mapeador.Mecanismo.Map<InstrutoresPorTurmaEnvelopeJSON>(excluido);
        json.SetLinks();
        return json;
    }
}
