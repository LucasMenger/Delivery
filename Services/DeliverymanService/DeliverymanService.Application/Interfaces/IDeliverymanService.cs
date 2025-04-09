using DeliverymanService.Application.DTOs;

namespace DeliverymanService.Application.Interfaces;

public interface IDeliverymanService
{
    Task<Guid> CreateAsync(DeliverymanDto dto);
    Task UpdateCnhImageAsync(int id, int image);
    Task<List<DeliverymanDto>> GetAllAsync();
}