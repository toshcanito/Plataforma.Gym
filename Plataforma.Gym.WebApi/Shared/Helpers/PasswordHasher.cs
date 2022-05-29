using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Plataforma.Gym.WebApi.Shared.Helpers
{
    public static class PasswordHasher
    {
        public static string Hash(string password, out string salt)
        {
            salt = GenerateNewSalt();
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string passwordHashed = GeneratePasswordHash(password, salt);

            return passwordHashed;
        }

        public static bool Compare(string password, string hashedPassword, string salt)
        {
            var currentPassword = GeneratePasswordHash(password, salt);

            return currentPassword.Equals(hashedPassword);
        }

        private static string GeneratePasswordHash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }

        private static string GenerateNewSalt()
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = RandomNumberGenerator.Create())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
    }
}