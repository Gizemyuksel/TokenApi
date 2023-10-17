namespace TokenApi.Data.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity GetById(int entityId);
    void Put(TEntity entity);
    void Post(TEntity entity);
    void Delete(TEntity entity);
    void Delete(int id);
    List<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> where);

}
