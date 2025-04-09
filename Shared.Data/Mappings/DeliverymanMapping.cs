using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models.Domain.Models;

namespace Shared.Data.Mappings;

public class DeliverymanMapping : IEntityTypeConfiguration<Deliveryman>
{
    public void Configure(EntityTypeBuilder<Deliveryman> builder)
    {
        // builder.ToTable("Deliverymen");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Identifier).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(150);
        builder.Property(d => d.Cnpj).IsRequired().HasMaxLength(20);
        builder.Property(d => d.CnhNumber).IsRequired().HasMaxLength(20);
        builder.Property(d => d.CnhType).IsRequired().HasMaxLength(5);
        builder.Property(d => d.CnhImagePath).HasMaxLength(250); 
        builder.HasIndex(d => d.Cnpj).IsUnique();
        builder.HasIndex(d => d.CnhNumber).IsUnique();
    }
}