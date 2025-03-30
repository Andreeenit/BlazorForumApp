using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models
{

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int? ParentCommentId { get; set; }

        [ForeignKey("ParentCommentID")]
        public Comment? ParentComment { get; set; }

        [Required]
        public int ThreadID { get; set; }

        [ForeignKey("ThreadID")]
        public Thread? Thread { get; set; }

        [Required]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        public List<Comment>? Reply { get; set; } = new List<Comment>();

    }
}