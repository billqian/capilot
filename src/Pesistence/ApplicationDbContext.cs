using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using Syntop.Pilot.Domain.Demo;
using System.Reflection;
using System.Transactions;

namespace Syntop.Pilot.Pesistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IPublisher _publisher;
    private static readonly LoggerFactory _loggerFactory
        = new LoggerFactory(new[] { new DebugLoggerProvider() });


    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }
        
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

    public DbSet<City> Cities => Set<City>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        //optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _publisher.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);

    }
}
