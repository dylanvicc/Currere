using System.Text;
using System.Security.Cryptography;

namespace Currere.Service.Users.Services
{
    public class DefaultPasswordHashService : IPasswordHashService
    {
        public string Hash(string password, HashType type)
        {
            switch (type)
            {
                case HashType.SHA256:
                    var buffer = SHA256.HashData(Encoding.UTF8.GetBytes(password));
                    var builder = new StringBuilder(buffer.Length * 2);

                    foreach (byte value in buffer)
                    {
                        builder.Append(value.ToString("X2"));
                    }

                    return builder.ToString();

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Specified an unsupported hash type.");
            }
        }
    }
}
