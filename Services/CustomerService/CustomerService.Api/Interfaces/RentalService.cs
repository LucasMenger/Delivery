using CustomerService.Application.Interfaces;
using CustomerService.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using SharedKernel.Models.Domain.Models;
using SharedKernel.Response;

namespace CustomerService.Api.Interfaces;

public class RentalService(AppDbContext _context) : IRentalService
{
    public async Task<Response<Rental?>> RentVehicleAsync(CreateRentalDto request)
    {
        var deliveryman = await _context.Deliverymen
            .FirstOrDefaultAsync(x => x.Id == request.EntregadorId);

        if (deliveryman is null)
            return Response<Rental?>.Fail("Entregador não encontrado.");

        if (deliveryman.CnhType != "A" && deliveryman.CnhType != "A+B")
            return Response<Rental?>.Fail("Entregador não possui CNH tipo A ou A+B.");

        var vehicle = await _context.Vehicles
            .FirstOrDefaultAsync(x => x.Id == request.MotoId);

        if (vehicle is null)
            return Response<Rental?>.Fail("Veículo não encontrado.");

        var rentalPlan = await _context.RentalPlans
            .FirstOrDefaultAsync(x => x.Days == request.Plano);

        if (rentalPlan is null)
            return Response<Rental?>.Fail("Plano de locação inválido.");

        var startDate = DateTime.UtcNow.Date.AddDays(1); 
        var rental = new Rental
        {
            DeliverymanId = deliveryman.Id,
            VehicleId = vehicle.Id,
            RentalPlanId = rentalPlan.Id,
            StartDate = startDate,
            ExpectedEndDate = request.DataPrevisaoTermino,
            EndDate = request.DataTermino
        };

        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();

        return new Response<Rental?>(rental);
    }

    public async Task<Response<decimal>> ReturnVehicleAsync(int rentalId, DateTime dataDevolucao)
    {
        var rental = await _context.Rentals
            .Include(x => x.RentalPlan)
            .FirstOrDefaultAsync(x => x.Id == rentalId);

        if (rental is null)
            return Response<decimal>.Fail("Locação não encontrada.");

        rental.EndDate = dataDevolucao;
        await _context.SaveChangesAsync();

        var totalValue = 0m;
        var daysUsed = (dataDevolucao.Date - rental.StartDate.Date).Days + 1;
        var expectedDays = rental.RentalPlan.Days;

        if (dataDevolucao < rental.ExpectedEndDate)
        {
            // Devolveu antes do prazo
            var daysRemaining = expectedDays - daysUsed;
            var baseCost = daysUsed * rental.RentalPlan.DailyPrice;
            var penalty = daysRemaining * rental.RentalPlan.DailyPrice * (rental.RentalPlan.PenaltyPercentage / 100m);
            totalValue = baseCost + penalty;
        }
        else if (dataDevolucao > rental.ExpectedEndDate)
        {
            // Devolveu depois do prazo
            var extraDays = (dataDevolucao.Date - rental.ExpectedEndDate.Date).Days;
            var baseCost = expectedDays * rental.RentalPlan.DailyPrice;
            var extraCost = extraDays * 50m;
            totalValue = baseCost + extraCost;
        }
        else
        {
            // Devolveu exatamente no prazo
            totalValue = expectedDays * rental.RentalPlan.DailyPrice;
        }

        return new Response<decimal>(totalValue);
    }

    public async Task<Response<RentalResponseDto>> GetRentalByIdAsync(int id)
    {
        var rental = await _context.Rentals
            .Where(r => r.Id == id)
            .Select(r => new RentalResponseDto
            {
                Id = r.Id,
                StartDate = r.StartDate,
                ExpectedEndDate = r.ExpectedEndDate,
                EndDate = r.EndDate,
                CreatedAt = r.CreatedAt,
                PlanDays = r.RentalPlan.Days,
                PlanPrice = r.RentalPlan.DailyPrice,
                PenaltyPercentage = r.RentalPlan.PenaltyPercentage,
                DeliverymanId = r.DeliverymanId,
                VehicleId = r.VehicleId
            })
            .FirstOrDefaultAsync();

        if (rental is null)
            return Response<RentalResponseDto>.Fail("Locação não encontrada.");

        return new Response<RentalResponseDto>(rental);
    }
}