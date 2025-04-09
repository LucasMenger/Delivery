using VehicleService.Domain.Models;

namespace VehicleService.Application.Interfaces;

public interface IEventPublisher
{
    Task PublishMotoCadastradaAsync(Vehicle moto);
}
