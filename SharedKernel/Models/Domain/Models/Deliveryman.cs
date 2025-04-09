namespace SharedKernel.Models.Domain.Models;

public class Deliveryman
{
    public int Id { get; set; }
    public string Identifier { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Cnpj { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string CnhNumber { get; set; } = default!;
    public string CnhType { get; set; } = default!; // A, B ou A+B
    public string? CnhImagePath { get; set; } // caminho no disco/s3/etc

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}