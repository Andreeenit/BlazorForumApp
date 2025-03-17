using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models;

public class Comment
{
    public int Id { get; set; }
    [Required] public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    [Required] public int ForumThreadID { get; set; }
    public Thread? ForumThread { get; set; }
    [Required] public string? UserId { get; set; }
    [ForeignKey("UserId")] public IdentityUser? User { get; set; }
    public List<Comment>? Replies { get; set; }

}
