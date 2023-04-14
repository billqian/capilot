using Microsoft.Extensions.Options;
using Syntop.Pilot.Domain.Demo;
using System.Reflection;
using System.Transactions;

namespace Syntop.Pilot.Pesistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    #region UnitOfWork

    public IUnitOfWork UnitOfWork => this;
    public bool IsTransactionExists => Database.GetEnlistedTransaction() != null;

    public void BeginTrans()
    {
        Database.BeginTransaction();
    }

    public void Commit()
    {
        Database.CommitTransaction();
    }

    public void Rollback()
    {
        Database.RollbackTransaction();
    }

    #endregion
    
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _publisher.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);

    }
}
