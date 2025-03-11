using System;
using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    public int ForumThreadID { get; set; }
    public Thread? ForumThread { get; set; }
    public string? UserId { get; set; }
    public IdentityUser? User { get; set; }
    public List<Comment>? Replies { get; set; }

}
