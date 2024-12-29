using Currere.Shared.Objects;
using Microsoft.EntityFrameworkCore;

namespace Currere.Service.Users.Services
{
    public class DefaultUsersService(UsersDatabaseContext context, IPasswordHashService service) : IUsersService
    {
        private readonly UsersDatabaseContext _context = context;
        private readonly IPasswordHashService _service = service;

        public async Task<User?> FindAsync(int identity)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserID == identity);
        }

        public async Task<User?> FindAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(
                user => user.EmailAddress == email && user.Password == _service.Hash(password, HashType.SHA256));
        }
        public async Task<User?> CreateAsync(User user)
        {
            user.Password = _service.Hash(user.Password, HashType.SHA256);

            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();

            return result == 0 ? null : user;
        }
    }
}
