﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Com.Sunbin.Password.Aes256
{
    class Aes256
    {

        #region AES加密

        /// <summary>
        ///     加密数据
        /// </summary>
        /// <param name="input">加密前的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string AESEncrypt(string input)
        {
            //盐值
            string saltValue = "saltValue";
            //密码值
            string pwdValue = "pwdValue";

            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] salt = Encoding.UTF8.GetBytes(saltValue);

            //AesManaged - 高级加密标准(AES) 对称算法的管理类
            var aes = new AesManaged();

            //Rfc2898DeriveBytes - 通过使用基于 HMACSHA1 的伪随机数生成器，实现基于密码的密钥派生功能 (PBKDF2 - 一种基于密码的密钥派生函数)
            //通过 密码 和 Salt 派生密钥
            var rfc = new Rfc2898DeriveBytes(pwdValue, salt);

            /* 
             * AesManaged.BlockSize - 加密操作的块大小（单位：bit）
             * AesManaged.LegalBlockSizes - 对称算法支持的块大小（单位：bit）
             * AesManaged.KeySize - 对称算法的密钥大小（单位：bit）
             * AesManaged.LegalKeySizes - 对称算法支持的密钥大小（单位：bit）
             * AesManaged.Key - 对称算法的密钥
             * AesManaged.IV - 对称算法的密钥大小
             * Rfc2898DeriveBytes.GetBytes(int 需要生成的伪随机密钥字节数) - 生成密钥
            */

            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            aes.Key = rfc.GetBytes(aes.KeySize / 8);
            aes.IV = rfc.GetBytes(aes.BlockSize / 8);

            //用当前的 Key 属性和初始化向量 IV 创建对称加密器对象
            ICryptoTransform encryptTransform = aes.CreateEncryptor();

            //加密后的输出流
            var encryptStream = new MemoryStream();

            //将加密后的目标流（encryptStream）与加密转换（encryptTransform）相连接
            var encryptor = new CryptoStream
                (encryptStream, encryptTransform, CryptoStreamMode.Write);

            //将一个字节序列写入当前 CryptoStream （完成加密的过程）
            encryptor.Write(data, 0, data.Length);
            encryptor.Close();

            // 将加密后所得到的流转换成字节数组，再用Base64编码将其转换为字符串
            string encryptedString = Convert.ToBase64String(encryptStream.ToArray());

            return encryptedString;
        }

        #endregion

        #region AES解密

        /// <summary>
        ///     解密数据
        /// </summary>
        /// <param name="input">加密后的字符串</param>
        /// <returns>加密前的字符串</returns>
        public static string AESDecrypt(string input)
        {
            //盐值（与加密时设置的值一致）
            string saltValue = "saltValue";
            //密码值（与加密时设置的值一致）
            string pwdValue = "pwdValue";

            byte[] encryptBytes = Convert.FromBase64String(input);
            byte[] salt = Encoding.UTF8.GetBytes(saltValue);

            var aes = new AesManaged();

            var rfc =
                new Rfc2898DeriveBytes(pwdValue, salt);

            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            aes.Key = rfc.GetBytes(aes.KeySize / 8);
            aes.IV = rfc.GetBytes(aes.BlockSize / 8);

            //用当前的 Key 属性和初始化向量 IV 创建对称解密器对象
            ICryptoTransform decryptTransform = aes.CreateDecryptor();

            //解密后的输出流
            var decryptStream = new MemoryStream();

            //将解密后的目标流（decryptStream）与解密转换（decryptTransform）相连接
            var decryptor = new CryptoStream(
                decryptStream, decryptTransform, CryptoStreamMode.Write);

            //将一个字节序列写入当前 CryptoStream （完成解密的过程）
            decryptor.Write(encryptBytes, 0, encryptBytes.Length);
            decryptor.Close();

            //将解密后所得到的流转换为字符串
            byte[] decryptBytes = decryptStream.ToArray();
            string decryptedString = Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);

            return decryptedString;
        }

        #endregion
    }
}
