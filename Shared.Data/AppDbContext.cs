
using Microsoft.EntityFrameworkCore;
using SharedKernel.Models.Domain.Models;

namespace Shared.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Deliveryman> Deliverymen { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalPlan> RentalPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}