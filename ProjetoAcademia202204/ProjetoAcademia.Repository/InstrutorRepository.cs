using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class InstrutorRepository : BaseRepository<Instrutor>
{
    public InstrutorRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

     public override Instrutor DeleteById(int id)
        {
            Instrutor instrutor = this.Read(id);
            this.context.Set<Instrutor>().Remove(instrutor);
            this.context.SaveChanges();
            return instrutor;
        }
}
