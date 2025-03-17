using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorForum.Models;
using BlazorForum.Data;
using System;
using Thread = BlazorForum.Models.Thread;

public class ForumService
{
    private readonly AppDBContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ForumService(AppDBContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    // Get all categories
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    // Get threads by category
    public async Task<List<Thread>> GetThreadsByCategoryAsync(int categoryId)
    {
        return await _context.Threads
            .Where(t => t.CategoryId == categoryId)
            .Include(t => t.User)
            .ToListAsync();
    }

    // Create a new thread
    public async Task<Thread?> CreateThreadAsync(string title, string content, int categoryId)
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user == null)
        {
            return null;
        }

        var currentUser = await _userManager.GetUserAsync(user);
        if (currentUser == null)
        {
            return null;
        }

        var newThread = new Thread
        {
            Title = title,
            Content = content,
            CategoryId = categoryId,
            UserId = currentUser.Id,
            CreatedDate = DateTime.UtcNow
        };

        _context.Threads.Add(newThread);
        await _context.SaveChangesAsync();

        return newThread;
    }


    // Delete thread (only if the user owns it or is an admin)
    public async Task<bool> DeleteThreadAsync(int threadId, string userId, bool isAdmin)
    {
        var thread = await _context.Threads.FindAsync(threadId);
        if (thread == null || (!isAdmin && thread.UserId != userId)) return false;

        _context.Threads.Remove(thread);
        await _context.SaveChangesAsync();
        return true;
    }
}
