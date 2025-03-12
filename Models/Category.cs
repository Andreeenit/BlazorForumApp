using System;
using System.Collections.Generic;

namespace BlazorForum.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<Thread> Thread { get; set; } = new();
}
