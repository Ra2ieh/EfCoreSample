

namespace EfSample.Domain.Entities;

public class Account
{
    public int AccountId { get; set; }
    [MaxLength(20)]
    public string AccountType { get; set; }
    public Teacher Teacher { get; set; }
}
