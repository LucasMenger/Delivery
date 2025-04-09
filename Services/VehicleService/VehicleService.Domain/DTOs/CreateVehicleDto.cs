namespace VehicleService.Domain.DTOs;

public class CreateVehicleDto
{
    public string Identifier { get; set; } = default!;
    public int Year { get; set; }
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
}