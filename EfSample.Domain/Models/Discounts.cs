
namespace EfSample.Domain.Models;

public class Discount
{
    public int DiscountId { get; set; }
    public decimal NewPrice { get; set; }
    public string Title { get; set; }=String.Empty;
    public int CourseId { get; set; }
    public Course Course { get; set; }

}
