using System.Text;

namespace PasswordGenerator.Code
{
    class GlobalData
    {
        public static GlobalData gd = new GlobalData();

        public string SETTING_FILE_NAME = "setting";                    //配置文件
        public string KEY_FILE_NAME = "key";                            //RSA密钥文件
        public Encoding DEFAULT_ENCODING = new UTF8Encoding(false);     //默认编码
        // Setting文件里面的标识
        public const string groupBox1_logo = "groupBox1",
                            groupBox2_logo = "groupBox2",
                            input_label1_logo = "input_label1",
                            info_label1_logo = "info_label1",
                            input_label2_logo = "input_label2",
                            info_label2_logo = "info_label2",
                            input_label3_logo = "input_label3",
                            info_label3_logo = "info_label3",
                            input_label4_logo = "input_label4",
                            info_label4_logo = "info_label4",
                            input_label5_logo = "input_label5",
                            info_label5_logo = "info_label5",
                            input_label6_logo = "input_label6",
                            info_label6_logo = "info_label6",
                            input_label7_logo = "input_label7",
                            info_label7_logo = "info_label7",
                            input_label8_logo = "input_label8",
                            info_label8_logo = "info_label8",
                            input_label9_logo = "input_label9",
                            info_label9_logo = "info_label9",
                            input_label10_logo = "input_label10",
                            info_label10_logo = "info_label10",
                            input_label11_logo = "input_label11",
                            info_label11_logo = "info_label11",
                            input_label12_logo = "input_label12",
                            info_label12_logo = "info_label12",
                            result_label1_logo = "result_label1",
                            result_label2_logo = "result_label2",
                            button1_logo = "button1",
                            button2_logo = "button2",
                            button3_logo = "button3";
        // UI界面字符串
        public string groupBox1_string,
                      groupBox2_string,
                      input_label1_string,
                      info_label1_string,
                      input_label2_string,
                      info_label2_string,
                      input_label3_string,
                      info_label3_string,
                      input_label4_string,
                      info_label4_string,
                      input_label5_string,
                      info_label5_string,
                      input_label6_string,
                      info_label6_string,
                      input_label7_string,
                      info_label7_string,
                      input_label8_string,
                      info_label8_string,
                      input_label9_string,
                      info_label9_string,
                      input_label10_string,
                      info_label10_string,
                      input_label11_string,
                      info_label11_string,
                      input_label12_string,
                      info_label12_string,
                      result_label1_string,
                      result_label2_string,
                      button1_string,
                      button2_string,
                      button3_string;
    }
}
