using System;
using BlazorForum.Models;
using Microsoft.EntityFrameworkCore;
using Thread = BlazorForum.Models.Thread;

namespace BlazorForum.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
     : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Thread> Threads { get; set; }

}
