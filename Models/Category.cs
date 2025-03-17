using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required] public string CategoryName { get; set; } = string.Empty;
    public List<Thread> Threads { get; set; } = new();
}
