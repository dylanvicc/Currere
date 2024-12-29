using Currere.Shared.Objects;
using Microsoft.EntityFrameworkCore;

namespace Currere.Service.Posts.Services
{
    public class DefaultPostsService(PostsDatabaseContext context) : IPostsService
    {
        private readonly PostsDatabaseContext _context = context;

        public async Task<Post?> CreateAsync(Post post)
        {
            _context.Posts.Add(post);
            var result = await _context.SaveChangesAsync();

            return result == 0 ? null : post;
        }

        public async Task<Post[]> FindAsync()
        {
            return await _context.Posts.ToArrayAsync();
        }

        public async Task<Post?> FindAsync(int identity)
        {
            return await _context.Posts.FindAsync(identity);
        }
    }
}
