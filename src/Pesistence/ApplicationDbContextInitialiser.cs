using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Pesistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task InitialiseAsync()
    {
        try {
            if (_context.Database.IsNpgsql() || _context.Database.IsSqlite()) {
                await _context.Database.MigrateAsync();
            }
        } catch (Exception ex) {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try {
            await TrySeedAsync();
        } catch (Exception ex) {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.WeatherForecasts.Any()) {

            await _context.WeatherForecasts.AddRangeAsync(
                new WeatherForecast() {
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Summary = "Tokyo", TemperatureC = 25
                },
                new WeatherForecast() {
                    Date = DateOnly.FromDateTime(new DateTime(2008, 6, 5)),
                    Summary = "Suzhou", TemperatureC = 20
                },
                new WeatherForecast() {
                    Date = DateOnly.FromDateTime(new DateTime(1976, 8, 31)),
                    Summary = "Lianshui", TemperatureC = 20
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}
