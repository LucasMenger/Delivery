using CustomerService.Domain.Entities;

namespace VehicleService.Domain.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Identifier { get; set; } = default!;
    public int Year { get; set; }
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}