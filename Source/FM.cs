using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MaterialSkin;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;

namespace PFT2
{

    public partial class FM : MaterialForm
    {
        string[] ver = new string[4];
        string[] Android = new string[4];
        string[] info = new string[4];
        string[] bugs = new string[4];
        string[] du16 = new string[4];
        string[] du32 = new string[4];
        string[] gapps = new string[4];
        string theme;
        int c = 10;
        public FM()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
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
            ver[0] = "9"; ver[1] = "11"; ver[2] = "12"; ver[3] = "15.1";
            Android[0] = "8.1"; Android[1] = "8.1"; Android[2] = "8.1"; Android[3] = "8.1";
            info[0] = "NO"; info[1] = "NO"; info[2] = "NO"; info[3] = "http://tinyurl.com/y85sl4m5";
            gapps[0] = "YES"; gapps[1] = "YES"; gapps[2] = "YES"; gapps[3] = "NO/YES";
            bugs[0] = "NO"; bugs[1] = "NO"; bugs[2] = "YES"; bugs[3] = "YES";
            du16[0] = "http://tinyurl.com/yco5cfxp"; du16[1] = "http://tinyurl.com/yco5cfxp"; du16[2] = "http://tinyurl.com/yco5cfxp"; du16[3] = "http://tinyurl.com/y8f6po87";
            du32[0] = "http://tinyurl.com/yco5cfxp"; du32[1] = "http://tinyurl.com/yco5cfxp"; du32[2] = "http://tinyurl.com/yco5cfxp"; du32[3] = "http://tinyurl.com/y8f6po87";
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            c = 0;
            materialLabel13.Text = materialRaisedButton1.Text;
            materialLabel7.Text = ver[c];
            materialLabel8.Text = Android[c];
            linkLabel3.Text = info[c];
            materialLabel15.Text = gapps[c];
            materialLabel10.Text = bugs[c];
            linkLabel1.Text = du16[c];
            linkLabel2.Text = du32[c];
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Zalexanninev15/PFT2#where-do-i-get-the-firmware-from-getting-root-and-twrp");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (c != 10) { Process.Start(du16[c]); }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (c != 10) { Process.Start(du32[c]); }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((c != 10) && (info[c] != "NO")) { Process.Start(info[c]); }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            c = 1;
            materialLabel13.Text = materialRaisedButton2.Text;
            materialLabel7.Text = ver[c];
            materialLabel8.Text = Android[c];
            linkLabel3.Text = info[c];
            materialLabel15.Text = gapps[c];
            materialLabel10.Text = bugs[c];
            linkLabel1.Text = du16[c];
            linkLabel2.Text = du32[c];
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            c = 2;
            materialLabel13.Text = materialRaisedButton3.Text;
            materialLabel7.Text = ver[c];
            materialLabel8.Text = Android[c];
            linkLabel3.Text = info[c];
            materialLabel15.Text = gapps[c];
            materialLabel10.Text = bugs[c];
            linkLabel1.Text = du16[c];
            linkLabel2.Text = du32[c];
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            c = 3;
            materialLabel13.Text = materialRaisedButton4.Text;
            materialLabel7.Text = ver[c];
            materialLabel8.Text = Android[c];
            linkLabel3.Text = info[c];
            materialLabel15.Text = gapps[c];
            materialLabel10.Text = bugs[c];
            linkLabel1.Text = du16[c];
            linkLabel2.Text = du32[c];
        }
    }
}
