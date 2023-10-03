namespace EfSample.Domain.Entities;

public  class CourseTag
{
    
    public int TagId { get; set; }
    public int CourseId { get; set; }
    public Tag Tag { get; set; }
    public Course Course { get; set; }
}
