using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace SmartTask
{
    public partial class Form1 : Form
    {
        public int interval = 60;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (interval <= 60)
            {
                label2.Text = (interval--) + " 秒";
            }
            else
            {
                label2.Text =(interval / 60).ToString() +" 分 " +(interval % 60).ToString() + " 秒";
                interval--;
            }
            if (interval == 0)
            {
                MessageBox.Show("您改休息了！");
                timer1.Stop();
                interval = Convert.ToInt32(SettingUtils.getSetting(SettingUtils.INTERVAL)) * 60;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setTip();
        }

        public void setTip()
        {
            label4.Text = "当前休息间隔为：" + SettingUtils.getSetting(SettingUtils.INTERVAL).Value + " 分钟";
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            label2.Text = interval.ToString() + " 秒";
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            interval = Convert.ToInt32(SettingUtils.getSetting(SettingUtils.INTERVAL).Value) * 60;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }
    }
}
