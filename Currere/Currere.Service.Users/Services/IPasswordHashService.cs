namespace Currere.Service.Users.Services
{
    public interface IPasswordHashService
    {
        string Hash(string password, HashType type);
    }
}
