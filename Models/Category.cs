using System.ComponentModel.DataAnnotations;

namespace BlazorForum.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required] public string CategoryName { get; set; } = string.Empty;
    public List<Thread> Threads { get; set; } = new();
}
