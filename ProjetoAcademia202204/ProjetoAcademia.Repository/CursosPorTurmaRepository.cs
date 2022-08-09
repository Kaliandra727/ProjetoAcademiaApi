using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class CursosPorTurmaRepository : BaseRepository<CursosPorTurma>
{
    public CursosPorTurmaRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override CursosPorTurma DeleteById(int id)
    {
        CursosPorTurma cporturma = this.Read(id);
        this.context.Set<CursosPorTurma>().Remove(cporturma);
        this.context.SaveChanges();
        return cporturma;
    }
}
