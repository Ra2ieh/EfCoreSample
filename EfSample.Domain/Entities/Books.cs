

namespace EfSample.Domain.Entities;

public class Books: Product
{
    public int PageSize { get; set; }
    [MaxLength(50)]
    public string Author { get; set; }
}
