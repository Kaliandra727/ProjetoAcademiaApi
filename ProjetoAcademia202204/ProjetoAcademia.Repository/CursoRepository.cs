using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class CursoRepository : BaseRepository<Curso>
{
    public CursoRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override Curso DeleteById(int id)
    {
        Curso curso = this.Read(id);
        this.context.Set<Curso>().Remove(curso);
        this.context.SaveChanges();
        return curso;
    }
}
