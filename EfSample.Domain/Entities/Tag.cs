namespace EfSample.Domain.Entities;
public class Tag
{
    public int TagId { get; set; }
    public string Title{ get; set; }=String.Empty;
    public ICollection<Course> Courses { get; set; }  
}
