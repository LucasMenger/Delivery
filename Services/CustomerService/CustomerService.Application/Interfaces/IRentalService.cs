using CustomerService.Domain.DTOs;
using SharedKernel.Models.Domain.Models;
using SharedKernel.Response;

namespace CustomerService.Application.Interfaces;

public interface IRentalService
{
    Task<Response<Rental?>> RentVehicleAsync(CreateRentalDto request);
    Task<Response<decimal>> ReturnVehicleAsync(int rentalId, DateTime dataDevolucao);
    Task<Response<RentalResponseDto>> GetRentalByIdAsync(int id);

}