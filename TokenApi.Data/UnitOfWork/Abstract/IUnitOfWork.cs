using TokenApi.Data.Repository;

namespace TokenApi.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{

    IGenericRepository<Account> AccountRepository { get; }
    IGenericRepository<Person> PersonRepository { get; }

    void CompleteWithTransaction();
    void Complete();
}
