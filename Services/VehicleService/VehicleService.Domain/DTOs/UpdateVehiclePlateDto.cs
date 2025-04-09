namespace VehicleService.Domain.DTOs;

public class UpdateVehiclePlateDto
{
    public int Id { get; set; }
    public string NewLicensePlate { get; set; } = default!;
}