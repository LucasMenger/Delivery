namespace DeliverymanService.Application.DTOs;

public class DeliverymanDto
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public DateTime BirthDate { get; set; }
    public string CnhNumber { get; set; }
    public string CnhType { get; set; }
    public string ImageCnhBase64 { get; set; } = default!;
}