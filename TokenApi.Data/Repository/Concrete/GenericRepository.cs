using TokenApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Azure;


namespace TokenApi.Data.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext context;
    private DbSet<TEntity> entities;

    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        this.entities = this.context.Set<TEntity>();
    }
    public List<TEntity> GetAll()
    {
        return entities.AsNoTracking().Take(1000).ToList();
    }

    public TEntity GetById(int entityId)
    {
        return entities.Find(entityId);
    }

    public void Put(TEntity entity)
    {
        entities.Update(entity);
    }
    public void Post(TEntity entity)
    {
        entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        var column = entity.GetType().GetProperty("IsDeleted");
        if (column is not null)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }
        else
        {
            entities.Remove(entity);
        }
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        var column = entity.GetType().GetProperty("IsDeleted");
        if (column is not null)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }
        else
        {
            entities.Remove(entity);
        }
    }


    public List<TEntity> Where(Expression<Func<TEntity, bool>> where)
    {
        return entities.Where(where).ToList();
    }

   
}