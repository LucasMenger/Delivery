using Microsoft.EntityFrameworkCore;
using VehicleService.Domain.Entities;
using VehicleService.Domain.Models;

namespace VehicleService.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<VehicleNotification> VehicleNotifications => Set<VehicleNotification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(v => v.Id);
            entity.HasIndex(v => v.LicensePlate).IsUnique();
            entity.Property(v => v.Identifier).IsRequired();
            entity.Property(v => v.Year).IsRequired();
            entity.Property(v => v.Model).IsRequired();
            entity.Property(v => v.LicensePlate).IsRequired();
        });

        modelBuilder.Entity<VehicleNotification>(entity =>
        {
            entity.HasKey(v => v.Id);
            entity.Property(v => v.Model).IsRequired();
            entity.Property(v => v.ReceivedAt).IsRequired();
        });
    }
}