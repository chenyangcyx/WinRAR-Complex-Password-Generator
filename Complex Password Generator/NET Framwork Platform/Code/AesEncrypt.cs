using System.IO;
using System.Security.Cryptography;

namespace PasswordGenerator.Code
{
    class AesEncrypt
    {
        public string GetAesEncrypt(string input_plain, string input_password)
        {
            GlobalData global = GlobalData.gd;
            string password = string.Empty;
            // 检查password长度
            if (input_password.Length > 32)         // (32,+~)
                password = input_password.Substring(0, 32);
            else if (input_password.Length > 24)       // (24,32]
            {
                password = input_password;
                while (input_password.Length < 32)
                    password += '7';
                password = password.Substring(0, 32);
            }
            else if (input_password.Length > 16)       // (16,24]
            {
                password = input_password;
                while (input_password.Length < 24)
                    password += '7';
                password = password.Substring(0, 24);
            }
            else                                    // (0,16]
            {
                password = input_password;
                while (input_password.Length < 16)
                    password += '7';
                password = password.Substring(0, 16);
            }

            // 定义初始密码和向量的byte数据
            byte[] aes_password = global.DEFAULT_ENCODING.GetBytes(password);
            byte[] aes_iv = global.DEFAULT_ENCODING.GetBytes(password.Substring(0, 16));

            // 开始AES加密
            byte[] encrypt_text;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aes_password;
                aesAlg.IV = aes_iv;
                aesAlg.BlockSize = 16 * 8;
                aesAlg.KeySize = aes_password.Length * 8;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            swEncrypt.Write(input_plain);
                        encrypt_text = msEncrypt.ToArray();
                    }
                }
            }
            return new Hash().GetBase64(global.DEFAULT_ENCODING.GetString(encrypt_text));
        }
    }
}
