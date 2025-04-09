using DeliverymanService.Application.DTOs;
using DeliverymanService.Application.Interfaces;
using Shared.Data;
using SharedKernel.Models.Domain.Models;
using SharedKernel.Response;

namespace DeliverymanService.Api.Interface;

public class DeliverymanService(AppDbContext context)  : IDeliverymanService
    {
        public async Task<Response<Deliveryman?>> CreateAsync(DeliverymanDto request)
        {
            var deliveryman = new Deliveryman
            {
                Name = request.Name,
                Cnpj = request.Cnpj,
                BirthDate = request.BirthDate,
                CnhNumber = request.CnhNumber,
                CnhType = request.CnhType
            };
            if (!string.IsNullOrEmpty(request.ImageCnhBase64))
            {
                var bytes = Convert.FromBase64String(request.ImageCnhBase64);
                var imageName = $"{Guid.NewGuid()}.png";
                var path = Path.Combine("storage", "cnh", imageName);

                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                await File.WriteAllBytesAsync(path, bytes);

                deliveryman.CnhImagePath = path; // salvar caminho no banco
            }

            context.Deliverymen.Add(deliveryman);
            await context.SaveChangesAsync();

            return new Response<Deliveryman?>(null,200,"");
        }


        public async Task<Response<Deliveryman?>> UpdateAsync(UpdateDeliverymanCnhImageDto request)
        {
            var deliveryman = await context.Deliverymen.FindAsync(request.Id);
            if (deliveryman is null)
            {
                return new Response<Deliveryman?>(null, 404, "Entregador não encontrado.");
            }

            if (!string.IsNullOrEmpty(request.ImageCnhBase64))
            {
                try
                {
                    // Apaga a imagem antiga, se existir
                    if (!string.IsNullOrEmpty(deliveryman.CnhImagePath) && File.Exists(deliveryman.CnhImagePath))
                    {
                        File.Delete(deliveryman.CnhImagePath);
                    }

                    // Salva a nova imagem
                    var bytes = Convert.FromBase64String(request.ImageCnhBase64);
                    var imageName = $"{Guid.NewGuid()}.png";
                    var path = Path.Combine("storage", "cnh", imageName);

                    Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                    await File.WriteAllBytesAsync(path, bytes);

                    // Atualiza o caminho no banco
                    deliveryman.CnhImagePath = path;
                }
                catch (Exception ex)
                {
                    return new Response<Deliveryman?>(null, 500, $"Erro ao salvar imagem: {ex.Message}");
                }
            }

            await context.SaveChangesAsync();

            return new Response<Deliveryman?>(deliveryman, 200, "Imagem atualizada com sucesso.");

        }
    }