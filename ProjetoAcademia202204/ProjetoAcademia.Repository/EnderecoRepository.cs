using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class EnderecoRepository : BaseRepository<Endereco>
{
    public EnderecoRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override Endereco DeleteById(int id)
    {
        Endereco endereco = this.Read(id);
        this.context.Set<Endereco>().Remove(endereco);
        this.context.SaveChanges();
        return endereco;
    }
}
