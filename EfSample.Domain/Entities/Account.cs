

namespace EfSample.Domain.Entities;

public class Account
{
    public int AccountId { get; set; }
    public string AccountType { get; set; }
    public Teacher User { get; set; }
}
