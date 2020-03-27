using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;

namespace PFT2
{
    public partial class Settings : MaterialForm
    {
        string theme;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            theme = Properties.Settings.Default.DarkMode;
            if (theme == "1")
            {
                b_w.Checked = true;
            }
            materialSingleLineTextField1.Text = Properties.Settings.Default.ADB;
            materialSingleLineTextField2.Text = Properties.Settings.Default.EDL_Code;
            materialSingleLineTextField3.Text = Properties.Settings.Default.MBNFile;
            materialSingleLineTextField4.Text = Properties.Settings.Default.FDump; 
            materialSingleLineTextField5.Text = Properties.Settings.Default.emmcdl;
            if (Properties.Settings.Default.DumpEx == "bin") { materialRadioButton2.Checked = true; }
            if (Properties.Settings.Default.DumpEx == "img") { materialRadioButton1.Checked = true; }
            if (Properties.Settings.Default.DumpEx == "dump") { materialRadioButton3.Checked = true; }

        }
        private void B_w_CheckedChanged(object sender, EventArgs e)
        {
            if (b_w.Checked)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green700, Primary.Green100, Accent.Yellow200, TextShade.WHITE);
                Properties.Settings.Default.DarkMode = "1";
                Properties.Settings.Default.Save();
            }
            if (!b_w.Checked)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
                Properties.Settings.Default.DarkMode = "";
                Properties.Settings.Default.Save();
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) //APPLY
        {
            Properties.Settings.Default.ADB = materialSingleLineTextField1.Text;
            Properties.Settings.Default.EDL_Code = materialSingleLineTextField2.Text;
            Properties.Settings.Default.MBNFile = materialSingleLineTextField3.Text;
            Properties.Settings.Default.FDump = materialSingleLineTextField4.Text;
            Properties.Settings.Default.emmcdl = materialSingleLineTextField5.Text;
            Properties.Settings.Default.Save();
            if (materialRadioButton2.Checked == true) { Properties.Settings.Default.DumpEx = "bin"; Properties.Settings.Default.Save(); }
            if (materialRadioButton1.Checked == true) { Properties.Settings.Default.DumpEx = "img"; Properties.Settings.Default.Save(); }
            if (materialRadioButton3.Checked == true) { Properties.Settings.Default.DumpEx = "dump"; Properties.Settings.Default.Save(); }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) //RESET
        {
            Properties.Settings.Default.ADB = "";
            Properties.Settings.Default.EDL_Code = "0xFE";
            Properties.Settings.Default.MBNFile = "";
            Properties.Settings.Default.FDump = "";
            Properties.Settings.Default.DumpEx = "dump";
            Properties.Settings.Default.DarkMode = "";
            Properties.Settings.Default.emmcdl = "";
            Properties.Settings.Default.Save();

            materialSingleLineTextField1.Clear();
            materialSingleLineTextField2.Text = "0xFE";
            materialSingleLineTextField3.Clear();
            materialSingleLineTextField4.Clear();
            materialSingleLineTextField5.Clear();
            materialRadioButton3.Checked = true;
            b_w.Checked = false;
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Flasher file|*.mbn"; 
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return; 
            materialSingleLineTextField3.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "ADB file|adb.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField1.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    materialSingleLineTextField4.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "emmcdl file|emmcdl.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField5.Text = openFileDialog1.FileName;
        }
    }
}
