using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator.Code
{
    class PasswordGenerate
    {
        string public_key, private_key;

        // 从文件中读取公钥、私钥
        private void ReadKeyContent()
        {
            string[] all_lines = File.ReadAllLines(GlobalData.gd.KEY_FILE_NAME, GlobalData.gd.DEFAULT_ENCODING);
            public_key = all_lines[0];
            private_key = all_lines[1];
        }

        // 获取16进制字符值对应的整型值
        private int GetIntValue(char ch)
        {
            return int.Parse("" + ch, System.Globalization.NumberStyles.HexNumber);
        }

        // 根据输入的两个值对字符串进行截取操作
        private string SubStringByValue(string str,int index1,int index2)
        {
            int length = str.Length;
            int index_length1 = index1 % length;
            int index_length2 = index2 % length;
            int start = index_length1 <= index_length2 ? index_length1 : index_length2;
            int end = index_length2 >= index_length1 ? index_length2 : index_length1;
            return str.Substring(start, end - start);
        }

        // 根据模式对str进行相应的hash操作
        private string GetHashByMode(string str,int mode)
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
            // 将输入内容全部转换成base64并进行sha-512 hash
            string[] all_input_base64_sha512 = new string[12];
            for (int i = 0; i < 12; i++)
                all_input_base64_sha512[i] = hash.GetSHA512(hash.GetBase64(all_input[i].Trim()));
            // 第一轮置换，字符串的自hash
            string[] deal1 = new string[12];
            for (int i = 0; i < 12; i++)
                deal1[i] = string.Copy(all_input_base64_sha512[i]);
            for(int i=0;i<12;i++)
            {
                char[] temp_str = all_input_base64_sha512[i].ToCharArray();
                foreach(char ch in temp_str)
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
            for(int i = 0; i < 12; i++)
            {
                char[] temp_str = deal1[i].ToCharArray();
                foreach(char ch in temp_str)
                {
                    int value = GetIntValue(ch);
                    while (value > 0)
                    {
                        deal2[i] = aes.GetAesEncrypt(deal2[i], deal2[i]);
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
            foreach(char ch in str_array4)
            {
                int value = GetIntValue(ch);
                string result = (value * 7 * 329 * 1117).ToString("x");
                stringBuilder4.Append(GetHashByMode(result,value));
            }
            string deal4 = stringBuilder4.ToString();
            // 第五轮，字符串的选择性加密
            StringBuilder stringBuilder5 = new StringBuilder();
            string[] temp5_deal1_1 = new string[12];
            string[] temp5_deal2_1 = new string[12];
            for(int i = 0; i < 12; i++)
            {
                temp5_deal1_1[i] = hash.GetSHA512(deal1[i]);
                temp5_deal2_1[i] = hash.GetSHA512(deal2[i]);
            }
            for(int i = 0; i < 12; i++)
            {
                int sum1 = 0;
                int sum2 = 0;

            }
            // 第六轮，字符串的迭代自hash

            // 第七轮，字符串的迭代自aes


            // 从文件中读取公钥，私钥
            ReadKeyContent();
        }
    }
}
