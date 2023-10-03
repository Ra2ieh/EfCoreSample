

namespace EfSample.Domain.Entities;
public class Comment
{
    public int CommentId { get; set; }
    public string CommentText { get; set; }=String.Empty;
    public int CourseId { get; set; }
    public string CommentBy { get; set; } = String.Empty;
    public int StarCount { get; set; } 
    public bool IsApproved { get; set; } 
    [NotMapped]
    public List<CommentsCategory> CommentsCategories { get; set; }
}
