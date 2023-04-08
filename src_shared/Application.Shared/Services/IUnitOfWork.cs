namespace Application.Shared.Services;

public interface IUnitOfWork
{
    void BeginTransaction();
    
    void CommitTransaction();

    void RollbackTransaction();

    bool ExistTransaction { get; }
}