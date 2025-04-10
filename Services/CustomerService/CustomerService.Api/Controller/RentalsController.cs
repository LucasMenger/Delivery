using CustomerService.Application.Interfaces;
using CustomerService.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Controller;

[ApiController]
[Route("locacoes")]
public class RentalsController(IRentalService rentalService) : ControllerBase
{
    private readonly IRentalService _rentalService = rentalService;

    // POST /locacoes
    [HttpPost]
    public async Task<IActionResult> RentVehicle([FromBody] CreateRentalDto request)
    {
        var response = await _rentalService.RentVehicleAsync(request);
        return StatusCode(Response.StatusCode, response);
    }

    // PUT /locacoes/{id}/devolver
    [HttpPut("{id}/devolver")]
    public async Task<IActionResult> ReturnVehicle(int id, [FromBody] DateTime dataDevolucao)
    {
        var response = await _rentalService.ReturnVehicleAsync(id, dataDevolucao);
        return StatusCode(Response.StatusCode, response);
    }

    // GET /locacoes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRentalById(int id)
    {
        var response = await _rentalService.GetRentalByIdAsync(id);
        return StatusCode(Response.StatusCode, response);
    }
}