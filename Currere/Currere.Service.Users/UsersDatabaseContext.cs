using Currere.Shared.Objects;
using Microsoft.EntityFrameworkCore;

namespace Currere.Service.Users
{
    public class UsersDatabaseContext(DbContextOptions<UsersDatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
