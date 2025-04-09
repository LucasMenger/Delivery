using DeliverymanService.Application.DTOs;
using SharedKernel.Models.Domain.Models;
using SharedKernel.Response;

namespace DeliverymanService.Application.Interfaces;

public interface IDeliverymanService
{
    Task<Response<Deliveryman?>> CreateAsync (DeliverymanDto request);
    Task <Response<Deliveryman?>> UpdateAsync(UpdateDeliverymanCnhImageDto request);
}