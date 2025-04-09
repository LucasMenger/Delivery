using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Data.Mappings;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        // builder.ToTable("Rentals");
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Vehicle)
            .WithMany(v => v.Rentals)
            .HasForeignKey(r => r.VehicleId);

        builder.HasOne(r => r.Deliveryman)
            .WithMany(d => d.Rentals)
            .HasForeignKey(r => r.DeliverymanId);

        builder.HasOne(r => r.RentalPlan)
            .WithMany(p => p.Rentals)
            .HasForeignKey(r => r.RentalPlanId);
    }
}
