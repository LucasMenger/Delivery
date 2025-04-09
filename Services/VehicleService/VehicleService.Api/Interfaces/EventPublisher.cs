
using SharedKernel.Models.Domain.Models;
using VehicleService.Application.Interfaces;

namespace VehicleService.Api.Interfaces;

public class EventPublisher : IEventPublisher
{
    public Task PublishMotoCadastradaAsync(Vehicle moto)
    {
        // Aqui você implementaria o publish no RabbitMQ, Kafka, etc.
        Console.WriteLine($"Evento publicado: Moto {moto.Identifier} cadastrada.");
        return Task.CompletedTask;
    }
}