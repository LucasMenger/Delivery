namespace DeliverymanService.Application.DTOs;

public class DeliverymanDto
{
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string CnhNumber { get; set; } = string.Empty;
    public string CnhType { get; set; } =  string.Empty;
    public string ImageCnhBase64 { get; set; } = default!;
}