using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator.Code
{
    class Hash
    {
        public string GetBase64(string str)
        {
            byte[] buffer = new UTF8Encoding(false).GetBytes(str);
            return Convert.ToBase64String(buffer).ToLower();
        }

        public string GetMD5(string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = new UTF8Encoding(false).GetBytes(str);
                byte[] result_buffer = md5.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result_buffer.Length; i++)
                    sb.Append(result_buffer[i].ToString("x2"));
                return sb.ToString();
            }
        }

        public string GetSHA1(string str)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] buffer = new UTF8Encoding(false).GetBytes(str);
                byte[] result_buffer = sha1.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result_buffer.Length; i++)
                    sb.Append(result_buffer[i].ToString("x2"));
                return sb.ToString();
            }
        }

        public string GetSHA256(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] buffer = new UTF8Encoding(false).GetBytes(str);
                byte[] result_buffer = sha256.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result_buffer.Length; i++)
                    sb.Append(result_buffer[i].ToString("x2"));
                return sb.ToString();
            }
        }

        public string GetSHA384(string str)
        {
            using (SHA384 sha384 = SHA384.Create())
            {
                byte[] buffer = new UTF8Encoding(false).GetBytes(str);
                byte[] result_buffer = sha384.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result_buffer.Length; i++)
                    sb.Append(result_buffer[i].ToString("x2"));
                return sb.ToString();
            }
        }

        public string GetSHA512(string str)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] buffer = new UTF8Encoding(false).GetBytes(str);
                byte[] result_buffer = sha512.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result_buffer.Length; i++)
                    sb.Append(result_buffer[i].ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
