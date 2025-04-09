namespace SharedKernel.Models.Domain.Models;

public class RentalPlan
{
    public int Id { get; set; }
    public int Days { get; set; }
    public decimal DailyPrice { get; set; }
    public decimal PenaltyPercentage { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}