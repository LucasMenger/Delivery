using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleService.Application.Interfaces;
using VehicleService.Domain.DTOs;

namespace VehicleService.Api.Controller;

[ApiController]
[Route("motos")]
public class VehiclesController(IVehicleService vehicleService) : ControllerBase
{
    private readonly IVehicleService _vehicleService = vehicleService;
    
    // POST /motos
    [HttpPost("motos")]
    public async Task<IActionResult> CreateMoto([FromBody] CreateVehicleDto request)
    {
        var response = await _vehicleService.CreateAsync(request);
        return StatusCode(Response.StatusCode, response);
    }

    // GET /motos
    [HttpGet("motos")]
    public async Task<IActionResult> GetAllMotos([FromQuery] GetAllVehicleDto request)
    {
        var response = await _vehicleService.GetAllAsync(request);
        return StatusCode(Response.StatusCode, response);
    }

    // PUT /motos/{id}/placa
    [HttpPut("motos/{id}/placa")]
    public async Task<IActionResult> UpdatePlaca(int id, [FromBody] string novaPlaca)
    {
        var request = new UpdateVehiclePlateDto
        {
            Id = id,
            NewLicensePlate = novaPlaca
        };

        var response = await _vehicleService.UpdateAsync(request);
        return StatusCode(Response.StatusCode, response);
    }

    // GET /motos/{id}
    [HttpGet("motos/{id}")]
    public async Task<IActionResult> GetMotoById(int id)
    {
        var request = new GetByIdVehicleDto { Id = id };
        var response = await _vehicleService.GetByIdAsync(request);
        return StatusCode(Response.StatusCode, response);
    }

    // DELETE /motos/{id}
    [HttpDelete("motos/{id}")]
    public async Task<IActionResult> DeleteMoto(int id)
    {
        var request = new DeleteVehicleDto { Id = id };
        var response = await _vehicleService.DeleteAsync(request);
        return StatusCode(Response.StatusCode, response);
    }
}
