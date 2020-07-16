using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator.Code
{
    class PasswordGenerate
    {
        string public_key;

        // 从文件中读取公钥、私钥
        private void ReadKeyContent()
        {
            StreamReader sr = new StreamReader(GlobalData.gd.KEY_FILE_NAME, GlobalData.gd.DEFAULT_ENCODING);
            public_key = sr.ReadLine();
            sr.Close();
        }

        // 获取16进制字符值对应的整型值
        private int GetIntValue(char ch)
        {
            return int.Parse("" + ch, System.Globalization.NumberStyles.HexNumber);
        }

        // 根据模式对str进行相应的hash操作
        private string GetHashByMode(string str, int mode)
        {
            Hash hash = new Hash();
            switch (mode % 5)
            {
                case 0:
                    return hash.GetMD5(str);
                case 1:
                    return hash.GetSHA1(str);
                case 2:
                    return hash.GetSHA256(str);
                case 3:
                    return hash.GetSHA384(str);
                case 4:
                    return hash.GetSHA512(str);
            }
            return hash.GetSHA512(str);
        }

        public void Generate(string[] all_input, TextBox textBox1, TextBox textBox2)
        {
            Hash hash = new Hash();
            AesEncrypt aes = new AesEncrypt();
            RSAEncrypt rsa = new RSAEncrypt();
            // 将输入内容全部转换成base64并进行sha-512 hash
            string[] all_input_base64_sha512 = new string[12];
            for (int i = 0; i < 12; i++)
                all_input_base64_sha512[i] = hash.GetSHA512(hash.GetBase64(all_input[i]));
            // 第一轮置换，字符串的自hash
            string[] deal1 = new string[12];
            for (int i = 0; i < 12; i++)
                deal1[i] = string.Copy(all_input_base64_sha512[i]);
            for (int i = 0; i < 12; i++)
            {
                char[] temp_str = all_input_base64_sha512[i].ToCharArray();
                foreach (char ch in temp_str)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal1[i] = GetHashByMode(deal1[i], value * value);
                        value--;
                    }
                }
            }
            // 第二轮置换，字符串的自aes
            string[] deal2 = new string[12];
            for (int i = 0; i < 12; i++)
                deal2[i] = string.Copy(deal1[i]);
            for (int i = 0; i < 12; i++)
            {
                char[] temp_str = deal1[i].ToCharArray();
                foreach (char ch in temp_str)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal2[i] = GetHashByMode(aes.GetAesEncrypt(deal2[i], deal2[i]), value * value);
                        value--;
                    }
                }
            }
            // 第三轮，字符串的拼接
            StringBuilder stringBuilder3 = new StringBuilder();
            foreach (string str in deal2)
                stringBuilder3.Append(str);
            string deal3 = stringBuilder3.ToString();
            // 第四轮，字符串的重新编码
            StringBuilder stringBuilder4 = new StringBuilder();
            char[] str_array4 = deal3.ToCharArray();
            foreach (char ch in str_array4)
            {
                int value = GetIntValue(ch);
                string result = (value * 7 * 329 * 1117).ToString("x");
                stringBuilder4.Append(GetHashByMode(result, value * value));
            }
            string deal4 = stringBuilder4.ToString();
            // 第五轮，字符串的选择加密
            string[] temp5_deal1_1 = new string[12];
            string[] temp5_deal2_1 = new string[12];
            for (int i = 0; i < 12; i++)
            {
                temp5_deal1_1[i] = hash.GetSHA512(deal1[i]);
                temp5_deal2_1[i] = hash.GetSHA512(deal2[i]);
            }
            string deal5 = string.Copy(deal4);
            for (int i = 0; i < 12; i++)
            {
                char[] array5_1 = temp5_deal1_1[i].ToCharArray();
                char[] array5_2 = temp5_deal2_1[i].ToCharArray();
                foreach (char ch in array5_1)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal5 = GetHashByMode(aes.GetAesEncrypt(deal5, temp5_deal2_1[i]), value * value);
                        value--;
                    }
                }
                foreach (char ch in array5_2)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal5 = GetHashByMode(aes.GetAesEncrypt(deal5, temp5_deal1_1[i]), value * value);
                        value--;
                    }
                }
            }
            // 第六轮，字符串的迭代自hash
            StringBuilder stringBuilder6 = new StringBuilder();
            string split6 = deal5 + deal5;
            char[] count6 = deal5.ToCharArray();
            for (int i = 0; i < count6.Length; i++)
            {
                int value = GetIntValue(count6[i]);
                stringBuilder6.Append(GetHashByMode(split6.Substring(i, value), value * value));
            }
            string deal6 = stringBuilder6.ToString();
            // 第七轮，字符串的迭代自aes
            StringBuilder stringBuilder7 = new StringBuilder();
            string split7 = deal6 + deal6;
            char[] count7 = deal6.ToCharArray();
            for (int i = 0; i < count7.Length; i++)
            {
                int value = GetIntValue(count7[i]);
                stringBuilder7.Append(aes.GetAesEncrypt(split7.Substring(i, value), deal1[value % 12]));
            }
            string deal7_pre = stringBuilder7.ToString();
            string deal7 = hash.GetMD5(deal7_pre) + hash.GetSHA1(deal7_pre) + hash.GetSHA256(deal7_pre) + hash.GetSHA384(deal7_pre) + hash.GetSHA512(deal7_pre);
            // 显示处理的密钥
            ReadKeyContent();
            string rsa_result = rsa.GetRSAEncrypt(public_key, deal7);
            textBox1.Text = "-------plain text-------\r\n" + deal7 + "\r\n\r\n-------rsa result-------\r\n" + rsa_result;
            textBox2.Text = rsa_result.Substring(rsa_result.Length / 2, 127);
        }
    }
}
