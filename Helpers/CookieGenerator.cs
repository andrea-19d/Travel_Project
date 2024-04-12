using System;
using System.Security.Cryptography;
using System.Text;

namespace Helpers
{
    public class CookieGenerator
    {
        private static readonly byte[] Salt = GenerateRandomBytes(32); // Generate a random 32-byte salt

        // Generate a random key for encryption and decryption
        private static readonly byte[] Key = GenerateRandomBytes(32);

        public static string Create(string value)
        {
            return EncryptStringAes(value, Key);
        }

        public static string Validate(string value)
        {
            return DecryptStringAes(value, Key);
        }

        private static string EncryptStringAes(string plainText, byte[] key)
        {
            using (var aesAlg = new AesManaged())
            {
                aesAlg.Key = key;
                aesAlg.IV = new byte[aesAlg.BlockSize / 8]; // Use a random IV for each encryption

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private static string DecryptStringAes(string cipherText, byte[] key)
        {
            using (var aesAlg = new AesManaged())
            {
                aesAlg.Key = key;
                aesAlg.IV = new byte[aesAlg.BlockSize / 8]; // Use a random IV for each encryption

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static byte[] GenerateRandomBytes(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }
    }
}
