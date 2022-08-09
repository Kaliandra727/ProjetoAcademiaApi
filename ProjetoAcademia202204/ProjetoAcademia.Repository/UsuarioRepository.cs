using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class UsuarioRepository : BaseRepository<Usuario>
{
    public UsuarioRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override Usuario DeleteById(int id)
    {
        Usuario usuario = this.Read(id);
        this.context.Set<Usuario>().Remove(usuario);
        this.context.SaveChanges();
        return usuario;
    }
}
