namespace Application.Shared.Services;

public interface IUnitOfWork
{
    void BeginTrans();
    void Commit();
    void Rollback();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}