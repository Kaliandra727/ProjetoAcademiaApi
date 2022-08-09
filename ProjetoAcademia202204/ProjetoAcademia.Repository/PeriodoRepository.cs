using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class PeriodoRepository : BaseRepository<Periodo>
{
    public PeriodoRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override Periodo DeleteById(int id)
    {
        Periodo periodo = this.Read(id);
        this.context.Set<Periodo>().Remove(periodo);
        this.context.SaveChanges();
        return periodo;
    }
}
