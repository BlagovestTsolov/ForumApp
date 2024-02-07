using ForumApp.Core.Models;
using ForumApp.DataBase.Data.Models;

namespace ForumApp.Core.Services.Contracts
{
    public interface IService
    {
        Task<IEnumerable<PostViewModel>> GetAllPostsAsync();

        Task EditAsync(PostViewModel model, int id);

        Task AddAsync(Post model);

        Task DeleteAsync(int id);
    }
}
