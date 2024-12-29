using Currere.Shared.Objects;

namespace Currere.Service.Posts.Services
{
    public interface IPostsService
    {
        Task<Post?> CreateAsync(Post post);

        Task<Post[]> FindAsync();

        Task<Post?> FindAsync(int identity);

        Task<bool> DeleteAsync(int identity);
    }
}
