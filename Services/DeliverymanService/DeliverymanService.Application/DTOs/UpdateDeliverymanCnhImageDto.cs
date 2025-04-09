namespace DeliverymanService.Application.DTOs;

public class UpdateDeliverymanCnhImageDto
{
    public int Id { get; set; } 
    public string ImageCnhBase64 { get; set; } = default!;
}