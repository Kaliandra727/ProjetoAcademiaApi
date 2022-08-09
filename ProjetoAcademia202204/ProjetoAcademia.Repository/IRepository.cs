namespace ProjetoAcademia.Repository;

public interface IRepository<TEntity>
{
    TEntity Create(TEntity obj);

    IEnumerable<TEntity> Read(int skip = 0, int take = 0);

    TEntity Update(TEntity obj);

    TEntity Delete(TEntity obj);
}
