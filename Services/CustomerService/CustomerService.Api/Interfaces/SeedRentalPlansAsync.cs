using Shared.Data;
using SharedKernel.Models.Domain.Models;

namespace CustomerService.Api.Interfaces;

public static async Task SeedRentalPlansAsync(AppDbContext context)
{
    if (!context.RentalPlans.Any())
    {
        var plans = new List<RentalPlan>
        {
            new() { Days = 7, DailyPrice = 30.00m, PenaltyPercentage = 0.20m },
            new() { Days = 15, DailyPrice = 28.00m, PenaltyPercentage = 0.40m },
            new() { Days = 30, DailyPrice = 22.00m, PenaltyPercentage = 0.00m },
            new() { Days = 45, DailyPrice = 20.00m, PenaltyPercentage = 0.00m },
            new() { Days = 50, DailyPrice = 18.00m, PenaltyPercentage = 0.00m },
        };

        context.RentalPlans.AddRange(plans);
        await context.SaveChangesAsync();
    }
}
