using System;
using System.IO;
using System.Security.Cryptography;

namespace Com.Sunbin.Password.Crypt
{
    class Aes256
    {
        private const int Iterations = 1000;

        /// <summary>
        ///     加密函数
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="key">密码</param>
        /// <returns></returns>
        public string[] Encrypt(string text, string key)
        {
            var result = new string[3];

            //盐值
            var salt = new byte[16];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(salt);
            }

            result[0] = Convert.ToBase64String(salt);
            //Rfc2898DeriveBytes - 通过使用基于 HMACSHA1 的伪随机数生成器，实现基于密码的密钥派生功能 (PBKDF2 - 一种基于密码的密钥派生函数)
            //通过 密码 和 Salt 派生密钥
            var rfc = new Rfc2898DeriveBytes(key, salt, Iterations);

            //AesManaged - 高级加密标准(AES) 对称算法的管理类
            var aes = new AesManaged();

            /* 
             * AesManaged.BlockSize - 加密操作的块大小（单位：bit）
             * AesManaged.LegalBlockSizes - 对称算法支持的块大小（单位：bit）
             * AesManaged.KeySize - 对称算法的密钥大小（单位：bit）
             * AesManaged.LegalKeySizes - 对称算法支持的密钥大小（单位：bit）
             * AesManaged.Key - 对称算法的密钥
             * AesManaged.IV - 对称算法的密钥大小
             * Rfc2898DeriveBytes.GetBytes(int 需要生成的伪随机密钥字节数) - 生成密钥
            */
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = rfc.GetBytes(aes.KeySize/8);
            aes.IV = rfc.GetBytes(aes.BlockSize/8);
            result[1] = Convert.ToBase64String(aes.IV);


            // Create a encrytor to perform the stream transform.
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            // Create the streams used for encryption. 
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(text);
                    }
                    result[2] = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            return result;
        }


        public string Decrypt(string cipherText, string key, string salt, string iv)
        {
            string plainText = "";
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            //Rfc2898DeriveBytes - 通过使用基于 HMACSHA1 的伪随机数生成器，实现基于密码的密钥派生功能 (PBKDF2 - 一种基于密码的密钥派生函数)
            //通过 密码 和 Salt 派生密钥
            var rfc = new Rfc2898DeriveBytes(key, saltBytes, Iterations);

            using (var aes = new AesManaged())
            {
                aes.BlockSize = 128;
                aes.KeySize = 256;
                aes.Key = rfc.GetBytes(aes.KeySize/8);
                aes.IV = Convert.FromBase64String(iv);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Create the streams used for decryption. 
                using (var msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plainText;
        }
    }
}