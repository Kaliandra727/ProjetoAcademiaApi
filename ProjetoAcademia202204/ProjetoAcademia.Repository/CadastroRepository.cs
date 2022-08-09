using Microsoft.EntityFrameworkCore;
using ProjetoAcademia.EF.Database;

namespace ProjetoAcademia.Repository;

public class CadastroRepository
{
    private ProjetoAcademiaContext context;

    public CadastroRepository(ProjetoAcademiaContext context)
    {
        this.context = context;
    }

    public bool Create(Usuario usuario, Endereco endereco, Aluno aluno)
    {
        var trans = this.context.Database.BeginTransaction();

        try
        {
            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();

            this.context.Enderecos.Add(endereco);
            this.context.SaveChanges();

            aluno.IdUsuario = usuario.IdUsuario;
            aluno.IdEndereco = endereco.IdEndereco;

            this.context.Alunos.Add(aluno);

            this.context.SaveChanges();

            trans.Commit();

            return true;
        }
        catch (Exception ex)
        {
            trans.Rollback();
            throw ex;
        }
    }
}
