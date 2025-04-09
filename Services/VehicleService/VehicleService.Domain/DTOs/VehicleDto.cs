namespace VehicleService.Domain.DTOs;

public class VehicleDto
{
    public int Id { get; set; }
    public string Identifier { get; set; } = default!;
    public int Year { get; set; }
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}