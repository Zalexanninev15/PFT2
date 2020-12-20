using MaterialSkin.Controls;
using MaterialSkin.Animations;
using System;
using System.Windows.Forms;
using MaterialSkin;
using System.Diagnostics;

namespace PFT2
{

    public partial class FirmwaresManager : MaterialForm
    {
        string[] ver = new string[4];
        string[] Android = new string[4];
        string[] info = new string[4];
        string[] bugs = new string[4];
        string[] du16 = new string[4];
        string[] gapps = new string[4];
        int c = 10;
        public FirmwaresManager()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            ver[0] = "9"; ver[1] = "11"; ver[2] = "12"; ver[3] = "15.1";
            Android[0] = "8.1"; Android[1] = "8.1"; Android[2] = "8.1"; Android[3] = "8.1";
            info[0] = "NO"; info[1] = "NO"; info[2] = "NO"; info[3] = "http://tinyurl.com/y85sl4m5";
            gapps[0] = "YES"; gapps[1] = "YES"; gapps[2] = "YES"; gapps[3] = "NO/YES";
            bugs[0] = "NO"; bugs[1] = "NO"; bugs[2] = "YES"; bugs[3] = "YES";
            du16[0] = "http://tinyurl.com/y4three7"; du16[1] = "http://tinyurl.com/yxuuseax"; du16[2] = "http://tinyurl.com/y6byyone"; du16[3] = "http://tinyurl.com/y8f6po87";
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
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Zalexanninev15/PFT2#where-do-i-get-the-firmware-from-getting-root-and-twrp");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (c != 10)
                Process.Start(du16[c]); 
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((c != 10) && (info[c] != "NO"))
                Process.Start(info[c]);
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
        }
    }
}
