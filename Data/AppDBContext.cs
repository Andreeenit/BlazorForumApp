using BlazorForum.Models;
using Microsoft.EntityFrameworkCore;
using Thread = BlazorForum.Models.Thread;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorForum.Data
{

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Thread> Threads { get; set; }

    }
}