namespace EfSample.Domain.Models;
public  class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public ICollection<CourseTeachers> CourseTeachers { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public Discount Discount { get; set; }
}
