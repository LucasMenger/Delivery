using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Models.Domain.Models;

namespace Shared.Data.Mappings;

public class RentalPlanConfiguration : IEntityTypeConfiguration<RentalPlan>
{
    public void Configure(EntityTypeBuilder<RentalPlan> builder)
    {
        // builder.ToTable("RentalPlans");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Days).IsRequired();
        builder.Property(p => p.DailyPrice).IsRequired();
        builder.Property(p => p.PenaltyPercentage).IsRequired();
    }
}
