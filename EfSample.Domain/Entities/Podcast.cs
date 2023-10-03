

namespace EfSample.Domain.Entities;

public class Podcast: Product
{
    [MaxLength(50)]
    public string Narrator { get; set; }
    public int Time { get; set; }
}
