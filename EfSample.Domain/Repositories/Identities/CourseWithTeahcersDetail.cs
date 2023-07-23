
namespace EfSample.Domain.Repositories.Identities;

public class CourseWithTeahcersDetail
{
    public CourseWithTeahcersDetail()
    {
        Teachers=new List<Teacher>();
    }
    public int CourseId { get; set; }
    public string Title { get; set; }=String.Empty;
    public List<Teacher> Teachers { get; set; }
}
