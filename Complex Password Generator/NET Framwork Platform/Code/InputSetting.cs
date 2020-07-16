using System.IO;

namespace PasswordGenerator.Code
{
    class InputSetting
    {
        public void ReadSettingFromFile()
        {
            //读入文件
            StreamReader sr = new StreamReader(GlobalData.gd.SETTING_FILE_NAME, GlobalData.gd.DEFAULT_ENCODING);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                SetSettingString(line);
            }
            sr.Close();
        }

        public void SetSettingString(string line)
        {
            if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.groupBox1_logo) == 0)
                GlobalData.gd.groupBox1_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.groupBox2_logo) == 0)
                GlobalData.gd.groupBox2_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label1_logo) == 0)
                GlobalData.gd.input_label1_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label2_logo) == 0)
                GlobalData.gd.input_label2_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label3_logo) == 0)
                GlobalData.gd.input_label3_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label4_logo) == 0)
                GlobalData.gd.input_label4_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label5_logo) == 0)
                GlobalData.gd.input_label5_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label6_logo) == 0)
                GlobalData.gd.input_label6_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label7_logo) == 0)
                GlobalData.gd.input_label7_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label8_logo) == 0)
                GlobalData.gd.input_label8_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label9_logo) == 0)
                GlobalData.gd.input_label9_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label10_logo) == 0)
                GlobalData.gd.input_label10_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label11_logo) == 0)
                GlobalData.gd.input_label11_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.input_label12_logo) == 0)
                GlobalData.gd.input_label12_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label1_logo) == 0)
                GlobalData.gd.info_label1_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label2_logo) == 0)
                GlobalData.gd.info_label2_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label3_logo) == 0)
                GlobalData.gd.info_label3_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label4_logo) == 0)
                GlobalData.gd.info_label4_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label5_logo) == 0)
                GlobalData.gd.info_label5_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label6_logo) == 0)
                GlobalData.gd.info_label6_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label7_logo) == 0)
                GlobalData.gd.info_label7_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label8_logo) == 0)
                GlobalData.gd.info_label8_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label9_logo) == 0)
                GlobalData.gd.info_label9_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label10_logo) == 0)
                GlobalData.gd.info_label10_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label11_logo) == 0)
                GlobalData.gd.info_label11_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.info_label12_logo) == 0)
                GlobalData.gd.info_label12_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.result_label1_logo) == 0)
                GlobalData.gd.result_label1_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.result_label2_logo) == 0)
                GlobalData.gd.result_label2_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.button1_logo) == 0)
                GlobalData.gd.button1_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.button2_logo) == 0)
                GlobalData.gd.button2_string = line.Substring(line.IndexOf("=") + 1);
            else if (line.Contains("=") && line.Substring(0, line.IndexOf("=")).CompareTo(GlobalData.button3_logo) == 0)
                GlobalData.gd.button3_string = line.Substring(line.IndexOf("=") + 1);
        }
    }
}
