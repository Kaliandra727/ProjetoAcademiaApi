using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class AlunoRepository : BaseRepository<Aluno>
{
    public AlunoRepository(ProjetoAcademiaContext context) : base(context)
    {
    }

    public override Aluno DeleteById(int id)
    {
        Aluno aluno = this.Read(id);
        this.context.Set<Aluno>().Remove(aluno);
        this.context.SaveChanges();
        return aluno;
    }
}
