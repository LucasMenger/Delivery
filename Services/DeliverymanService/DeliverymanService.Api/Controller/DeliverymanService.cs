using DeliverymanService.Application.DTOs;
using DeliverymanService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliverymanService.Api.Controller;

public class DeliverymanService : ControllerBase
{
    [ApiController]
    [Route("entregadores")]
    public class DeliverymanController(IDeliverymanService service) : ControllerBase
    {
        /// <summary>
        /// Cadastrar novo entregador
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DeliverymanDto request)
        {
            var result = await service.CreateAsync(request);
            if (Response.StatusCode == 200)
                return Ok(result);

            return StatusCode(Response.StatusCode, result);
        }

        /// <summary>
        /// Enviar/atualizar imagem da CNH do entregador
        /// </summary>
        [HttpPost("{id}/cnh")]
        public async Task<IActionResult> UpdateCnhAsync(int id, [FromBody] UpdateDeliverymanCnhImageDto request)
        {
            request.Id = id;
            var result = await service.UpdateAsync(request);
            if (Response.StatusCode == 200)
                return Ok(result);

            return StatusCode(Response.StatusCode, result);
        }
    }
}