using SharedKernel.Models.Domain.Models;
using SharedKernel.Response;
using VehicleService.Domain.DTOs;
 
 namespace VehicleService.Application.Interfaces;
 
 public interface IVehicleService
 {
     Task<Response<Vehicle?>> CreateAsync(CreateVehicleDto request);
     Task<Response<Vehicle?>> UpdateAsync(UpdateVehiclePlateDto request);
     Task<Response<Vehicle?>> DeleteAsync(DeleteVehicleDto request);
     Task<Response<Vehicle?>> GetByIdAsync(GetByIdVehicleDto request);
     Task<PagedResponse<List<Vehicle>>> GetAllAsync(GetAllVehicleDto request);
 }