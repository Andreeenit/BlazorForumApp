using BlazorForum.Models;
using Microsoft.EntityFrameworkCore;
using Thread = BlazorForum.Models.Thread;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorForum.Data;

public class AppDBContext : IdentityDbContext<ApplicationUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
     : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Thread> Threads { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }


}
