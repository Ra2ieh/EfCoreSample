

namespace EfSample.Domain.Entities;

public class CourseIncludingDiscount
{
    public int CourseId { get; set; }
    public string CourseTitle { get; set; }
    public decimal NewPrice { get; set; }
    public int DiscountId { get; set; }
}
