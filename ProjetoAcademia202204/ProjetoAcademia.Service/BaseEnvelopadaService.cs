using ProjetoAcademia.Mapper;

namespace ProjetoAcademia.Service;

public abstract class BaseEnvelopadaService<TPoco, TDom, TEnvelope>
    where TPoco : class
    where TDom : class
    where TEnvelope : class
{
    protected MapeadorGenericoEnvelopado<TPoco, TDom, TEnvelope> mapeador;

    protected List<string> mensagemProcessamento;

    protected List<string> MensagemProcessamento => this.mensagemProcessamento;

    public BaseEnvelopadaService() 
    {
        this.mensagemProcessamento = new List<string>();
    }

    public virtual List<TEnvelope> Listar()
    {
        throw new NotImplementedException("Não rela no meu código");
    }

    public virtual TEnvelope Selecionar(int id)
    {
        throw new NotImplementedException("Não rela no meu código");
    }

    public virtual TEnvelope Criar(TPoco obj)
    {
        throw new NotImplementedException("Não rela no meu código");
    }

    public virtual TEnvelope Atualizar(TPoco obj)
    {
        throw new NotImplementedException("Não rela no meu código");
    }

    public virtual TEnvelope Excluir(TPoco obj)
    {
        throw new NotImplementedException("Não rela no meu código");
    }

    public virtual TEnvelope Excluir(int id)
    {
        throw new NotImplementedException("Não rela no meu código");
    }

    protected virtual List<TEnvelope> ProcessarListaDOM(List<TDom> listDOM)
    {
        throw new NotImplementedException("Não rela no meu código");
    }
}
