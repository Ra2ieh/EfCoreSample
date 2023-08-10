
namespace EfSample.Domain.Repositories.Identities;

public class CourseWithTeachersDetail
{
    public CourseWithTeachersDetail()
    {
        Teachers=new List<Teacher>();
    }
    public int CourseId { get; set; }
    public string Title { get; set; }=String.Empty;
    public List<Teacher> Teachers { get; set; }
}
