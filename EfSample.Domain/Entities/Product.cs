

namespace EfSample.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    [MaxLength(50)]
    public string ProductName { get; set; }
    [Precision(14, 2)]
    [Required]
    public decimal Amount { get; set; }

}
