using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator.Code
{
    class PasswordGenerate
    {
        string key;

        // 从文件中读取公钥、私钥
        private void ReadKeyContent()
        {
            StreamReader sr = new StreamReader(GlobalData.gd.KEY_FILE_NAME, GlobalData.gd.DEFAULT_ENCODING);
            key = sr.ReadToEnd().Trim();
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
            // 将输入内容全部转换成base64并进行sha-512 hash
            string[] all_input_base64_sha512 = new string[12];
            for (int i = 0; i < 12; i++)
                all_input_base64_sha512[i] = hash.GetSHA512(hash.GetBase64(all_input[i]));
            // 第一轮置换，字符串的随机自hash
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
            // 第二轮置换，字符串的循环自hash
            string[] deal2 = new string[12];
            for (int i = 0; i < 12; i++)
                deal2[i] = string.Copy(deal1[i]);
            for (int i = 0; i < 12; i++)
            {
                char[] temp_str = deal2[i].ToCharArray();
                foreach (char ch in temp_str)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal2[i] = hash.GetMD5(deal2[i]);
                        deal2[i] = hash.GetSHA1(deal2[i]);
                        deal2[i] = hash.GetSHA256(deal2[i]);
                        deal2[i] = hash.GetSHA384(deal2[i]);
                        deal2[i] = hash.GetSHA512(deal2[i]);
                        value--;
                    }
                }
            }
            // 第三轮，字符串与key的拼接
            StringBuilder stringBuilder3 = new StringBuilder();
            foreach (string str in deal2)
                stringBuilder3.Append(str);
            ReadKeyContent();
            stringBuilder3.Append(hash.GetSHA512(key));
            string deal3 = stringBuilder3.ToString();
            // 第四轮，字符串的重新编码
            StringBuilder stringBuilder4 = new StringBuilder();
            char[] str_array4 = deal3.ToCharArray();
            foreach (char ch in str_array4)
            {
                int value = GetIntValue(ch);
                string result_4 = (value * 7 * 329 * 1117).ToString("x");
                stringBuilder4.Append(GetHashByMode(result_4, value * value));
            }
            string deal4 = stringBuilder4.ToString();
            // 第五轮，字符串的选择hash
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
                        deal5 = GetHashByMode(deal5, value * value);
                        value--;
                    }
                }
                foreach (char ch in array5_2)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal5 = GetHashByMode(deal5, value * value);
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
            // 第七轮，字符串的迭代自随机hash
            string deal7 = string.Copy(deal6);
            char[] deal7_array = deal7.ToCharArray();
            foreach (char ch in deal7_array)
            {
                int value = GetIntValue(ch);
                while (value > 0)
                {
                    deal7 = hash.GetSHA512(deal7 + key);
                    value--;
                }
            }
            string result = hash.GetMD5(deal7) + hash.GetSHA1(deal7) + hash.GetSHA256(deal7) + hash.GetSHA384(deal7) + hash.GetSHA512(deal7);
            // 显示处理的密钥
            textBox1.Text = "-------plain text-------\r\n" + deal7 + "\r\n\r\n-------hash result-------\r\n" + result;
            StringBuilder result_password_builder = new StringBuilder();
            result_password_builder.Append(result.Substring(2, 20));
            result_password_builder.Append(result.Substring(7, 70));
            result_password_builder.Append(result.Substring(22, 20));
            result_password_builder.Append(result.Substring(77, 17));
            textBox2.Text = result_password_builder.ToString();
        }
    }
}
