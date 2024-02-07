using ForumApp.Core.Models;
using ForumApp.Core.Services.Contracts;
using ForumApp.DataBase.Data;
using ForumApp.DataBase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Core.Services
{
    public class Service : IService
    {
        private readonly PostDbContext context;

        public Service(PostDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(Post model)
        {
            await context.Posts.AddAsync(model);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await context.Posts
                .FirstOrDefaultAsync(p => p.Id == id);

            context.Posts.Remove(post!);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(PostViewModel model, int id)
        {
            var post = await context.Posts
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Content = model.Content;
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPostsAsync()
        {
            return await context.Posts
                .AsNoTracking()
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToListAsync();
        }
    }
}
