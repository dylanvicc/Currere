using Currere.Shared.Objects;

namespace Currere.Service.Users.Services
{
    public interface IUsersService
    {
        Task<User?> FindAsync(int identity);

        Task<User?> FindAsync(string email, string password);

        Task<User?> FindAsync(string email);

        Task<User?> CreateAsync(User user);
    }
}
