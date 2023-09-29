

namespace EfSample.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string FirstName{ get; set; }
    public string UserName{ get; set; }
    public string LastName{ get; set; }
    public int Age{ get; set; }
    public int UserShipAge{ get; set; }
    public UserType UserType { get; set; }

}
