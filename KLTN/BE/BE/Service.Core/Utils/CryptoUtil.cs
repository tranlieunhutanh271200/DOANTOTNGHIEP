using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Service.Core.Utils
{
    public static class CryptoUtil
    {
        public static class MD5
        {
            public static void Hash(string plainText, out string salt, out string hashed)
            {
                var bytes = new byte[128 / 8];
                var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(bytes);

                salt = Convert.ToBase64String(bytes);


                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: plainText,
                    salt: Convert.FromBase64String(salt),
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
            }
            public static bool CompareHash(string plainText, string salt, string hashed)
            {
                if (string.IsNullOrEmpty(plainText))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(salt))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(hashed))
                {
                    return false;
                }
                var tempHashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: plainText,
                    salt: Convert.FromBase64String(salt),
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                return string.Equals(tempHashed, hashed);
            }
        }
    }
}
