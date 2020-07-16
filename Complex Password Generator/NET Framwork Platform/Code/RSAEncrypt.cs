using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator.Code
{
    class RSAEncrypt
    {
        // RSA加密
        public string GetRSAEncrypt(string xmlPublicKey, string content)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
            return Convert.ToBase64String(encryptedData);
        }
    }
}
