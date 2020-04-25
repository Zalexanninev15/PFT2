using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;

namespace PFT2
{
    public partial class ADB : MaterialForm
    {
        string adbp;
        public ADB()
        {
            InitializeComponent();
        }

        private void ADB_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Clear();
            ADBCommander("get-state");
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Clear();
            ADBCommander("reboot");
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Clear();
            ADBCommander("reboot recovery");
        }

        private void ADBCommander(string command)
        {
            adbp = Properties.Settings.Default.ADB;
            if (File.Exists(adbp))
            {
                Process process1 = new Process();
                process1.StartInfo.FileName = "cmd.exe";
                process1.StartInfo.Arguments = "/C " + @adbp + " " + command;
                process1.StartInfo.RedirectStandardOutput = true;
                process1.StartInfo.UseShellExecute = false;
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                process1.WaitForExit();
                if ((command == "get-state") || (command == "reboot") || (command == "reboot recovery")) { materialSingleLineTextField1.Text = process1.StandardOutput.ReadToEnd(); }
                string str = "adb";
                foreach (Process process2 in Process.GetProcesses())
                {
                    if (process2.ProcessName.ToLower().Contains(str.ToLower()))
                        process2.Kill();
                }
            }
            else { MessageBox.Show("ADB not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = materialSingleLineTextField1.Text;
            openFileDialog1.Filter = "APK|*.apk";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField2.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            ADBCommander("install -r " + materialSingleLineTextField2.Text);
            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            ADBCommander("shell pm uninstall -k --user 0 " + materialSingleLineTextField3.Text);
            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
