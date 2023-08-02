namespace EfSample.Domain.Models;

public  class CourseTag
{
    public int CourseTagId { get; set; }
    public int TagId { get; set; }
    public int CourseId { get; set; }
    public Tag Tag { get; set; }
    public Course Course { get; set; }
}
