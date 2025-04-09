using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using VehicleService.Application.Interfaces;
using VehicleService.Domain.DTOs;
using VehicleService.Domain.Models;
using VehicleService.Domain.Response;

namespace VehicleService.Api.Interfaces;

public class VehicleService(AppDbContext context, IEventPublisher eventPublisher) : IVehicleService
{
    private readonly IEventPublisher _eventPublisher = eventPublisher;

    public async Task<Response<Vehicle?>> CreateAsync(CreateVehicleDto request)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Identifier) ||
                request.Year == 0 ||
                string.IsNullOrWhiteSpace(request.Model) ||
                string.IsNullOrWhiteSpace(request.LicensePlate))
            {
                return new Response<Vehicle?>(null, 400, "Todos os campos são obrigatórios.");
            }

            var exists = await context.Vehicles.AnyAsync(x => x.LicensePlate == request.LicensePlate);
            if (exists)
            {
                return new Response<Vehicle?>(null, 400, "Placa já cadastrada.");
            }

            var vehicle = new Vehicle
            {
                Identifier = request.Identifier,
                Year = request.Year,
                Model = request.Model,
                LicensePlate = request.LicensePlate,
                CreatedAt = DateTime.UtcNow
            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            // Disparar evento (mensageria)
            await _eventPublisher.PublishMotoCadastradaAsync(vehicle);

            return new Response<Vehicle?>(vehicle, 201, "Moto cadastrada com sucesso.");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Erro ao cadastrar moto.");
        }
    }
    
    public async Task<Response<Vehicle?>> UpdateAsync(UpdateVehiclePlateDto request)
    {
        try
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 400, "Dados inválidos");

            vehicle.LicensePlate = request.NewLicensePlate;
            
            await context.AddAsync(vehicle);
            await context.SaveChangesAsync();

            return new Response<Vehicle?>(null, 200, "Placa modificada com sucesso");
        }
        catch 
        {
            return new Response<Vehicle?>(null, 500, "Error");
        }
    }

    public async Task<Response<Vehicle?>> DeleteAsync(DeleteVehicleDto request)
    {
        try
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (vehicle is null)
                return new Response<Vehicle?>(null, 400, "Dados inválidos");

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
            
            return new Response<Vehicle?>(null, 200, "");
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Error");
        }
    }

    public async Task<Response<Vehicle?>> GetByIdAsync(GetByIdVehicleDto request)
    {
        try
        {
            var vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id == request.Id);

            return vehicle is null
                ? new Response<Vehicle?>(null, 400, "Moto não encontrada")
                : new Response<Vehicle?>(vehicle);
        }
        catch
        {
            return new Response<Vehicle?>(null, 500, "Request mal formada");
        }
    }

    public async Task<PagedResponse<List<Vehicle>>> GetAllAsync(GetAllVehicleDto request)
    {
        try
        {
            var query = context
                .Vehicles
                .AsNoTracking()
                .OrderBy(x => x.Id);

            var vehicle = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var cout = await query.CountAsync();

            return new PagedResponse<List<Vehicle>>(vehicle, cout, request.PageNumber, request.PageSize);

        }
        catch
        {
            return new PagedResponse<List<Vehicle>>(null, 400, "Dados inválidos");
        }
    }
}