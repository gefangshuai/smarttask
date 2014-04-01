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
    public partial class Form2 : Form
    {
        
        private Form1 parent;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingUtils.addSetting(SettingUtils.INTERVAL, numericUpDown1.Value.ToString());
            SettingUtils.addSetting(SettingUtils.STARTED, checkBox1.Checked.ToString());
            parent.interval = Convert.ToInt32(numericUpDown1.Value) * 60;
            parent.setTip();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            KeyValueConfigurationElement startedElement = SettingUtils.getSetting(SettingUtils.STARTED);
            KeyValueConfigurationElement intervalElement = SettingUtils.getSetting(SettingUtils.INTERVAL);

            if (intervalElement != null)
            {
                numericUpDown1.Value = int.Parse(intervalElement.Value);
                
            }

            if (startedElement == null || startedElement.Value.Equals("False"))
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }
    }
}
