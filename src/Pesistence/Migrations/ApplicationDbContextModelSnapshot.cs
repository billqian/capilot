﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Syntop.Pilot.Pesistence;

#nullable disable

namespace Syntop.Pilot.Pesistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Syntop.Pilot.Domain.Demo.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT")
                        .HasColumnName("city_name");

                    b.HasKey("Id")
                        .HasName("pk_city");

                    b.ToTable("city", (string)null);
                });

            modelBuilder.Entity("Syntop.Pilot.Domain.Demo.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<string>("Summary")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("summary");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("INTEGER")
                        .HasColumnName("temperature_c");

                    b.HasKey("Id")
                        .HasName("pk_weather_forecast");

                    b.ToTable("weather_forecast", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
