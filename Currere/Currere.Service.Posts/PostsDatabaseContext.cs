using Currere.Shared.Objects;
using Microsoft.EntityFrameworkCore;

namespace Currere.Service.Posts
{
    public class PostsDatabaseContext(DbContextOptions<PostsDatabaseContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts { get; set; }
    }
}
