using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class AlunosPorTurmaRepository : BaseRepository<AlunosPorTurma>
{
    public AlunosPorTurmaRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override AlunosPorTurma DeleteById(int id)
    {
        AlunosPorTurma aporturma = this.Read(id);
        this.context.Set<AlunosPorTurma>().Remove(aporturma);
        this.context.SaveChanges();
        return aporturma;
    }
}
