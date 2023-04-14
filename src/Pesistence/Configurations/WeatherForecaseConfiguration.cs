using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syntop.Pilot.Domain.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntop.Pilot.Pesistence.Configurations;

internal class WeatherForecaseConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.Property(t => t.Summary)
            .HasMaxLength(200);
    }
}
