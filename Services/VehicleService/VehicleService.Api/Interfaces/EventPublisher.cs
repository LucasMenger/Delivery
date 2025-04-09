using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using VehicleService.Application.Interfaces;
using VehicleService.Domain.Models;

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