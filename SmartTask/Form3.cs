using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTask
{
    public partial class Form3 : Form
    {
        private Form1 parent;
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 form1)
        {
            this.parent = form1;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            parent.interval = Convert.ToInt32(SettingUtils.getSetting(SettingUtils.INTERVAL).Value) * 60;
            parent.stopLabel();
        }

    }
}
