using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models.Domain.Models;

namespace Shared.Data.Mappings;

public class VehicleMapping: IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        // builder.ToTable("Vehicles");
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Identifier).IsRequired().HasMaxLength(100);
        builder.Property(v => v.Year).IsRequired();
        builder.Property(v => v.Model).IsRequired().HasMaxLength(150);
        builder.Property(v => v.LicensePlate).IsRequired().HasMaxLength(10);
        builder.HasIndex(v => v.LicensePlate).IsUnique();
    }
}