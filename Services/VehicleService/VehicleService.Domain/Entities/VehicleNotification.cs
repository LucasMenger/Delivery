namespace VehicleService.Domain.Entities;

public class VehicleNotification
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public string Model { get; set; } = default!;
    public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;
}