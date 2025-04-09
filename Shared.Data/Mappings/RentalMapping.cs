using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models.Domain.Models;

namespace Shared.Data.Mappings;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        // builder.ToTable("Rentals");
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.RentalPlan)
            .WithMany(p => p.Rentals)
            .HasForeignKey(r => r.RentalPlanId);
    }
}
