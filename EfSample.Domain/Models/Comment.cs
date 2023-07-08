namespace EfSample.Domain.Models;
public class Comment
{
    public int CommentId { get; set; }
    public string CommentText { get; set; }=String.Empty;
    public Course Course { get; set; }
    public string CommentBy { get; set; } = String.Empty;
    public int StarCount { get; set; } 
    public bool IsApproved { get; set; } 
}
