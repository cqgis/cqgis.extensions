using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace cqgis.extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class PasswordExtension
    {
        /// <summary>
        /// cqgis: DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDes(this string encryptString, string encryptKey)
        {
            try
            {
                // 盐值 
                string saltValue = (encryptKey + "12345678").Substring(0, 8);
                // 密码值 
                const string pwdValue = "pwdValue";
                byte[] data = Encoding.UTF8.GetBytes(encryptString);
                byte[] salt = Encoding.UTF8.GetBytes(saltValue);
                var aes = Aes.Create();
                var rfc = new Rfc2898DeriveBytes(pwdValue, salt);
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;
                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);
                ICryptoTransform encryptTransform = aes.CreateEncryptor();
                var encryptStream = new MemoryStream();
                var encryptor = new CryptoStream
                    (encryptStream, encryptTransform, CryptoStreamMode.Write);
                encryptor.Write(data, 0, data.Length);
                encryptor.Flush();
                encryptor.Dispose();

                string encryptedString = Convert.ToBase64String(encryptStream.ToArray());
                return encryptedString;
            }
            catch
            {
                return encryptString;
            }
        }
        /// <summary>
        /// cqgis: DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDes(this string decryptString, string decryptKey)
        {
            try
            {
                string saltValue = (decryptKey + "12345678").Substring(0, 8);
                const string pwdValue = "pwdValue";
                byte[] encryptBytes = Convert.FromBase64String(decryptString);
                byte[] salt = Encoding.UTF8.GetBytes(saltValue);
                var aes = Aes.Create();
                var rfc = new Rfc2898DeriveBytes(pwdValue, salt);
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;
                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);
                ICryptoTransform decryptTransform = aes.CreateDecryptor();
                var decryptStream = new MemoryStream();
                var decryptor = new CryptoStream(
                    decryptStream, decryptTransform, CryptoStreamMode.Write);
                decryptor.Write(encryptBytes, 0, encryptBytes.Length);
                decryptor.Flush();
                decryptor.Dispose();
            
                byte[] decryptBytes = decryptStream.ToArray();
                string decryptedString = Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
                return decryptedString;
            }
            catch
            {
                return decryptString;
            }
        }

        /// <summary>
        /// cqgis: 返回MD5 hash值
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MD5(this string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var md5 = System.Security.Cryptography.MD5.Create();
            
            var result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(s.Trim())));
            return result;
        }
    }
}