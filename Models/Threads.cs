using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models;

public class Threads
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int UserId { get; set; }
    public IdentityUser? User { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

}

