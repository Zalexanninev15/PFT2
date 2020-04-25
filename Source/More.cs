using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFT2
{
    public partial class More : Form
    {
        public More()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { Properties.Settings.Default.ADB_Func = "on"; Properties.Settings.Default.Save(); }
            if (checkBox2.Checked == false) { Properties.Settings.Default.ADB_Func = "off"; Properties.Settings.Default.Save(); }
            if (checkBox3.Checked == true) { Properties.Settings.Default.FM = "on"; Properties.Settings.Default.Save(); }
            if (checkBox3.Checked == false) { Properties.Settings.Default.FM = "off"; Properties.Settings.Default.Save(); }
            if (checkBox5.Checked == true) { Properties.Settings.Default.IMGsys = "on"; Properties.Settings.Default.IMGVedro = "on"; Properties.Settings.Default.IMGAll = "on"; Properties.Settings.Default.Save(); }
            if (checkBox5.Checked == false) { Properties.Settings.Default.IMGsys = "off"; Properties.Settings.Default.IMGVedro = "off"; Properties.Settings.Default.IMGAll = "off";  Properties.Settings.Default.Save(); }
            if (checkBox1.Checked == true) { Properties.Settings.Default.IMGsys = "on"; Properties.Settings.Default.Save(); }
            if (checkBox1.Checked == false) { Properties.Settings.Default.IMGsys = "off"; Properties.Settings.Default.Save(); }
            if (checkBox4.Checked == true) { Properties.Settings.Default.IMGVedro = "on"; Properties.Settings.Default.Save(); }
            if (checkBox4.Checked == false) { Properties.Settings.Default.IMGVedro = "off"; Properties.Settings.Default.Save(); }
        }

        private void More_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IMGsys == "on") { checkBox1.Checked = true; }
            if (Properties.Settings.Default.ADB_Func == "on") { checkBox2.Checked = true; }
            if (Properties.Settings.Default.FM == "on") { checkBox3.Checked = true; }
            if (Properties.Settings.Default.IMGVedro == "on") { checkBox4.Checked = true; }
            if (Properties.Settings.Default.IMGAll == "on") { checkBox5.Checked = true; checkBox4.Checked = true; checkBox1.Checked = true; checkBox4.Enabled = false; checkBox1.Enabled = false; }
            if (Properties.Settings.Default.IMGAll == "off") { checkBox5.Checked = false; checkBox4.Checked = false; checkBox1.Checked = false; checkBox4.Enabled = true; checkBox1.Enabled = true; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { checkBox4.Checked = true; checkBox1.Checked = true; checkBox4.Enabled = false; checkBox1.Enabled = false; }
            if (checkBox5.Checked == false) { checkBox4.Checked = false; checkBox1.Checked = false; checkBox4.Enabled = true; checkBox1.Enabled = true; }
        }
    }
}
