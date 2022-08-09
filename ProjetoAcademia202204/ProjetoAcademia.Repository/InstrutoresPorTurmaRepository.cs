using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class InstrutoresPorTurmaRepository : BaseRepository<InstrutoresPorTurma>
{
    public InstrutoresPorTurmaRepository(ProjetoAcademiaContext context) : base(context)
    {
    }
    public override InstrutoresPorTurma DeleteById(int id)
    {
        InstrutoresPorTurma iporturma = this.Read(id);
        this.context.Set<InstrutoresPorTurma>().Remove(iporturma);
        this.context.SaveChanges();
        return iporturma;
    }
}
