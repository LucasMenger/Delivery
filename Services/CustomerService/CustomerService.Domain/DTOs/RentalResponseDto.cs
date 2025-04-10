namespace CustomerService.Domain.DTOs;

public class RentalResponseDto
{
    public int Id { get; set; }
    public int DeliverymanId { get; set; }
    public int VehicleId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime ExpectedEndDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }

    public int PlanDays { get; set; }
    public decimal PlanPrice { get; set; }
    public decimal PenaltyPercentage { get; set; }
}