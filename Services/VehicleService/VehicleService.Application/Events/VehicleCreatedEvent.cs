namespace VehicleService.Application.Events;

public class VehicleCreatedEvent
{
    public Guid VehicleId { get; set; }
    public int Year { get; set; }
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
}