namespace EfSample.Domain.Entities;
[Keyless]
[Table(name:"MyCourses",Schema ="view")]
public class MyCourses
{
    public int UserId { get; set; }
    [MaxLength(20)]
    public string UserName { get; set; }
    public int CourseId { get; set; }
    [MaxLength(100)]
    [Unicode]
    public string CourseTitle { get; set; }
}
