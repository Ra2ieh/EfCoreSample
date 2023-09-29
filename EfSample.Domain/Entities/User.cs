

namespace EfSample.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    private string _firstName;
    //1-backingField
    public string FirstName
    {
        get { return _firstName; } 
        set { _firstName = value; }
    }
    //2-backingField
    private string _userNameField;
    [BackingField("_userNameField")]
    public string UserName
    {
        get { return _userNameField; }
        set { _userNameField = value; }
    }
    private string _lastNameField;
    public string LastName
    {
        get { return _lastNameField; }
        set { _lastNameField = value; } 
    }
    public int Age{ get; set; }
    public int UserShipAge{ get; set; }
    public UserType UserType { get; set; }

}
