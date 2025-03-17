using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models;

public class Thread
{

    public int Id { get; set; }
    [Required][MaxLength(200)] public string Title { get; set; } = string.Empty;
    [Required] public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    [Required] public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public string? UserId { get; set; }
    [ForeignKey("UserId")] public IdentityUser? User { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

}

