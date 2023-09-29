namespace EfSample.Domain.Entities;

public class Discount
{
    public int DiscountId { get; set; }
    [Precision(14,2)]
    [Required]
    public decimal NewPrice { get; set; }
    [Unicode]
    [MaxLength(50)]
    public string Title { get; set; }=String.Empty;
    public int CourseId { get; set; }
    public Course Course { get; set; }

}
