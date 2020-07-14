using PasswordGenerator.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET_Framwork_Platform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            // 初始化UI的界面
            InitializeComponent();

            // 读取UI设置
            InputSetting inputSetting = new InputSetting();
            inputSetting.ReadSettingFromFile();

            // 设置UI文字
            SetUIString();
        }

        //设置UI文字
        public void SetUIString()
        {
            GlobalData global = GlobalData.gd;
            groupBox1.Text = global.groupBox1_string;
            groupBox2.Text = global.groupBox2_string;
            input_label1.Text = global.input_label1_string;
            info_label1.Text = global.info_label1_string;
            input_label2.Text = global.input_label2_string;
            info_label2.Text = global.info_label2_string;
            input_label3.Text = global.input_label3_string;
            info_label3.Text = global.info_label3_string;
            input_label4.Text = global.input_label4_string;
            info_label4.Text = global.info_label4_string;
            input_label5.Text = global.input_label5_string;
            info_label5.Text = global.info_label5_string;
            input_label6.Text = global.input_label6_string;
            info_label6.Text = global.info_label6_string;
            input_label7.Text = global.input_label7_string;
            info_label7.Text = global.info_label7_string;
            input_label8.Text = global.input_label8_string;
            info_label8.Text = global.info_label8_string;
            input_label9.Text = global.input_label9_string;
            info_label9.Text = global.info_label9_string;
            input_label10.Text = global.input_label10_string;
            info_label10.Text = global.info_label10_string;
            input_label11.Text = global.input_label11_string;
            info_label11.Text = global.info_label11_string;
            input_label12.Text = global.input_label12_string;
            info_label12.Text = global.info_label12_string;
            result_label1.Text = global.result_label1_string;
            result_label2.Text = global.result_label2_string;
            button1.Text = global.button1_string;
            button2.Text = global.button2_string;
            button3.Text = global.button3_string;
        }

        // 清空
        private void button3_Click(object sender, EventArgs e)
        {
            // 清空输入
            input_text1.Clear();
            input_text2.Clear();
            input_text3.Clear();
            input_text4.Clear();
            input_text5.Clear();
            input_text6.Clear();
            input_text7.Clear();
            input_text8.Clear();
            input_text9.Clear();
            input_text10.Clear();
            input_text11.Clear();
            input_text12.Clear();
            result_textBox1.Clear();
            result_textBox2.Clear();
            // 重设焦点
            input_text1.Focus();
        }

        // 复制文本
        private void button2_Click(object sender, EventArgs e)
        {
            if (result_textBox2.Text.Length!=0)
                Clipboard.SetText(result_textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
