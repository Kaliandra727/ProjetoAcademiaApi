using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class TurmaRepository : BaseRepository<Turma>
{
    public TurmaRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override Turma DeleteById(int id)
    {
        Turma turma = this.Read(id);
        this.context.Set<Turma>().Remove(turma);
        this.context.SaveChanges();
        return turma;
    }
}
