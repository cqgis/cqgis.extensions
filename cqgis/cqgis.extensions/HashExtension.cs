using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace cqgis.extensions
{
    public static class HashExtension
    {
        /// <summary>
        /// cqgis: 获取文件的md5值
        /// </summary>
        /// <param name="filename">文件的全名</param>
        /// <returns></returns>
        public static string GetMD5(this string filename)
        {
            var fullname = Path.GetFullPath(filename);
            if (!File.Exists(fullname))
                throw new FileNotFoundException(fullname);

            FileStream file = new FileStream(fullname, FileMode.Open);
            var md5 = MD5.Create();
            byte[] retVal = md5.ComputeHash(file);
            file.Dispose();

            StringBuilder sb = new StringBuilder();
            foreach (byte t in retVal)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();

        }

        /// <summary>
        /// cqgis: 从64位字符串解码
        /// </summary>
        /// <param name="base64string"></param>
        /// <returns></returns>
        public static byte[] Frombase64TobBytes(this string base64string)
        {
            return Convert.FromBase64String(base64string);
        }

        /// <summary>
        /// cqgis: 从64位字符串解密
        /// </summary>
        /// <param name="base64string"></param>
        /// <returns></returns>
        public static string Frombase64ToString(this string base64string)
        {
            return Encoding.UTF8.GetString(base64string.Frombase64TobBytes());
        }

        /// <summary>
        /// cqgis: 数组转64位字符串
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] datas)
        {
            string strPath = Convert.ToBase64String(datas, 0, datas.Length);
            return strPath;
        }


        /// <summary>
        /// cqgis: 字符串转成base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64String(this string str)
        {
            var encode = Encoding.UTF8;
            byte[] bytedata = encode.GetBytes(str);
            return bytedata.ToBase64String();
        }

    }
}
