using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace PFT2
{
    public partial class More : MaterialForm
    {
        string theme;

        public More()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { Properties.Settings.Default.IMGsys = "on"; Properties.Settings.Default.IMGVedro = "on"; Properties.Settings.Default.IMGAll = "on"; Properties.Settings.Default.Save(); }
            if (checkBox5.Checked == false) { Properties.Settings.Default.IMGsys = "off"; Properties.Settings.Default.IMGVedro = "off"; Properties.Settings.Default.IMGAll = "off";  Properties.Settings.Default.Save(); }
            if (checkBox1.Checked == true) { Properties.Settings.Default.IMGsys = "on"; Properties.Settings.Default.Save(); }
            if (checkBox1.Checked == false) { Properties.Settings.Default.IMGsys = "off"; Properties.Settings.Default.Save(); }
            if (checkBox4.Checked == true) { Properties.Settings.Default.IMGVedro = "on"; Properties.Settings.Default.Save(); }
            if (checkBox4.Checked == false) { Properties.Settings.Default.IMGVedro = "off"; Properties.Settings.Default.Save(); }
            if (materialCheckBox1.Checked == true) { Properties.Settings.Default.GUI = "on"; Properties.Settings.Default.Save(); }
            if (materialCheckBox1.Checked == false) { Properties.Settings.Default.GUI = "off"; Properties.Settings.Default.Save(); }
        }

        private void More_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            theme = Properties.Settings.Default.DarkMode;
            if (theme == "")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            }
            if (theme == "1")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green100, Accent.Yellow200, TextShade.WHITE);
            }
            if (Properties.Settings.Default.IMGAll == "on") { checkBox5.Checked = true; checkBox4.Checked = true; checkBox1.Checked = true; checkBox4.Enabled = false; checkBox1.Enabled = false; }
            if (Properties.Settings.Default.IMGAll == "off") { checkBox5.Checked = false; checkBox4.Checked = false; checkBox1.Checked = false; checkBox4.Enabled = true; checkBox1.Enabled = true; }
            if (Properties.Settings.Default.IMGsys == "on") { checkBox1.Checked = true; }
            if (Properties.Settings.Default.IMGVedro == "on") { checkBox4.Checked = true; }
            if (Properties.Settings.Default.GUI == "on") { materialCheckBox1.Checked = true; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { checkBox4.Checked = true; checkBox1.Checked = true; checkBox4.Enabled = false; checkBox1.Enabled = false; }
            if (checkBox5.Checked == false) { checkBox4.Checked = false; checkBox1.Checked = false; checkBox4.Enabled = true; checkBox1.Enabled = true; }
        }
    }
}
