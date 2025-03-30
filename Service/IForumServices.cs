using BlazorForum.Models;
using Thread = BlazorForum.Models.Thread;

namespace BlazorForum.Service
{

    public interface IForumServices
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Thread>> GetThreadsByCategoryAsync(int categoryId);
        Task<Thread?> GetThreadByIdAsync(int id);
        Task<bool> CreateThreadAsync(Thread thread);
        Task<bool> UpdateThreadAsync(Thread thread, string userId);
        Task<bool> DeleteThreadAsync(int threadId, string userId);

        Task<List<Comment>> GetCommentsAsync(int threadId, string userId);
        Task<List<Comment>> GetRepliesAsync(int parentCommentId);
        Task<bool> CreateCommentAsync(Comment comment);
        Task<bool> UpdateCommentAsync(Comment comment, string userId);
        Task<bool> DeleteCommentAsync(int commentId, string userId);
    }
}