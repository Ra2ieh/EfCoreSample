namespace EfSample.Domain.Models;
public class Teacher
{
    public Teacher()
    {
        LastName = "****";
    }
    public int TeacherId { get; set; }
    public string FirstName { get; set; }=String.Empty;
    public string LastName { get; set; }= String.Empty; 
}
