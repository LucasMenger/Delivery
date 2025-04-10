namespace CustomerService.Domain.DTOs;

public class CreateRentalDto
{
    public int EntregadorId { get; set; }
    public int MotoId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public DateTime DataPrevisaoTermino { get; set; }
    public int Plano { get; set; } // Dias do plano: 7, 15, etc.
}