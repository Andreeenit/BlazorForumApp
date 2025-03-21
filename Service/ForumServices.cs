using Microsoft.EntityFrameworkCore;
using BlazorForum.Models;
using BlazorForum.Data;
using Thread = BlazorForum.Models.Thread;
using BlazorForum.Service;

public class ForumServices : IForumServices

{
    private readonly AppDBContext _context;
    public ForumServices(AppDBContext context)
    {
        _context = context;
    }
    public async Task<List<Comment>> GetCommentsAsync(int threadId, string userId)
    {
        return await _context.Comments
        .Where(c => c.ThreadID == threadId)
        .Include(c => c.UserId == userId)
        .Include(c => c.Reply != null)
        .ToListAsync();


    }
    //Får alla Categories.
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    //Får en Category baserat på dess Id.
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.Threads)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
    }

    //Får alla threads till en specifik category.
    public async Task<List<Thread>> GetThreadsByCategoryAsync(int categoryId)
    {
        return await _context.Threads
            .Where(t => t.CategoryId == categoryId)
            .Include(t => t.Comments)
            .ToListAsync();
    }
    //Får upp en specifik thread(genom Id)
    public async Task<Thread?> GetThreadByIdAsync(int id)
    {
        return await _context.Threads
        .Include(t => t.Comments)
        .FirstOrDefaultAsync(t => t.Id == id);
    }

    //Skapar en thread.
    public async Task<bool> CreateThreadAsync(Thread thread)
    {
        thread.CreatedDate = DateTime.UtcNow;
        _context.Threads.Add(thread);
        await _context.SaveChangesAsync();
        return true;
    }
    //Updatera en thread(Om skapad av samma User.)
    public async Task<bool> UpdateThreadAsync(Thread thread, string userId)
    {
        var existingThread = await _context.Threads.FindAsync(thread.Id);
        if
        (existingThread != null || existingThread?.UserId != userId)
            return false;

        existingThread.Title = thread.Title;
        existingThread.Content = thread.Content;

        await _context.SaveChangesAsync();
        return true;
    }
    //Delete Thread (Om skapad av samma User.)
    public async Task<bool> DeleteThreadAsync(int threadId, string userId)
    {
        var thread = await _context.Threads.FindAsync(threadId);
        if
        (thread == null || thread.UserId != userId)
            return false;

        _context.Threads.Remove(thread);
        await _context.SaveChangesAsync();
        return true;
    }

    //Skapar en Comment,(Då blir den Comment som får en reply, en ParentComment.)
    public async Task<bool> CreateCommentAsync(Comment comment)
    {
        if (comment.ParentCommentId.HasValue)
        {
            var parentComment = await _context.Comments.FindAsync(comment.ParentCommentId);
            if (parentComment == null) return false;
        }

        comment.CreatedDate = DateTime.UtcNow;
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return true;
    }

    //Updatera en Comment(Om skapad av samma User.)
    public async Task<bool> UpdateCommentAsync(Comment comment, string userId)
    {
        var existingComment = await _context.Comments.FindAsync(comment.Id);
        if
        (existingComment != null || existingComment?.UserId != userId)
            return false;

        existingComment.Content = comment.Content;
        await _context.SaveChangesAsync();
        return true;
    }

    //Delete Comment(Om skapad av samma User.)
    public async Task<bool> DeleteCommentAsync(int commentId, string userId)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        if
        (comment == null || comment.UserId != userId)
            return false;

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }

    //Får replies till den specifika "parentcomment" och vilken User som skrev den.
    public async Task<List<Comment>> GetRepliesAsync(int parentCommentId)
    {
        return await _context.Comments
        .Where(c => c.ParentCommentId == parentCommentId)
        .Include(c => c.User)
        .ToListAsync();
    }

}
