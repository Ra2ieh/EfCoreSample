namespace EfSample.Domain.Entities;
[Index(nameof(LastName))]
public class Teacher
{
    public Teacher()
    {
        LastName = "****";
    }
    public int TeacherId { get; set; }
    [Column(TypeName ="nvarchar(50)")]
    public string FirstName { get; set; }=String.Empty;
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; }= String.Empty;
    public List<Zone> Zones { get; }
    public Account Account { get; set; }
    public List<Address> Address { get; set; }
    public List<Phone> Phones { get; set; }
    public Profile Profile { get; set; }
}
