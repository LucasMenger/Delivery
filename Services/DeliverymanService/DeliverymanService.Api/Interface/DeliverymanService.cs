using DeliverymanService.Application.DTOs;
using DeliverymanService.Application.Interfaces;
using DeliverymanService.Domain.Entities;

namespace DeliverymanService.Api.Interface;

public class DeliverymanService : IDeliverymanService
    {
        public Task<Guid> CreateAsync(DeliverymanDto dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCnhImageAsync(int id, int image)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeliverymanDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }