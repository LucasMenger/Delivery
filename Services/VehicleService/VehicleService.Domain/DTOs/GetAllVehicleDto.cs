namespace VehicleService.Domain.DTOs;

public class GetAllVehicleDto
{
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}