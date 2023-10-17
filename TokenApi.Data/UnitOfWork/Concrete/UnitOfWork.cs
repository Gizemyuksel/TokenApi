using TokenApi.Data;
using TokenApi.Data.Repository;

namespace TokenApi.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private bool disposed;

    public IGenericRepository<Account> AccountRepository { get; private set; }

    public IGenericRepository<Person> PersonRepository { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;

        AccountRepository = new GenericRepository<Account>(context);
        PersonRepository = new GenericRepository<Person>(context);
    }

    public void CompleteWithTransaction()
    {
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            try
            {
                context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                // logging                    
                dbContextTransaction.Rollback();
            }
        }
    }

    public void Complete()
    {
        context.SaveChanges();
    }

    protected virtual void Clean(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}