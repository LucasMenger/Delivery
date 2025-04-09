using DeliverymanService.Domain.Entities;
using VehicleService.Domain.Models;

namespace CustomerService.Domain.Entities;

public class Rental
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = default!;

    public int DeliverymanId { get; set; }
    public Deliveryman Deliveryman { get; set; } = default!;

    public int RentalPlanId { get; set; }
    public RentalPlan RentalPlan { get; set; } = default!;

    public DateTime StartDate { get; set; }
    public DateTime ExpectedEndDate { get; set; }
    public DateTime EndDate { get; set; } // Quando devolveu
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}