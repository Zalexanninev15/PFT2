using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;

namespace PFT2
{
    public partial class MainForm : MaterialForm
    {
        string[] portal;
        string theme, adbp, cport, emmcdl, fdump;
        Form f;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            theme = Properties.Settings.Default.DarkMode;
            if (theme == "")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue800, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            }
            if (theme == "1")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green500, Primary.Green700, Primary.Green100, Accent.Yellow200, TextShade.WHITE);
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            emmcdl = Properties.Settings.Default.emmcdl;
            if (File.Exists(emmcdl))
            {
                fdump = Properties.Settings.Default.FDump;
                int c = 0;
                string mbn = Properties.Settings.Default.MBNFile;
                if ((materialSingleLineTextField4.Text != "") && (mbn != "") && ((materialRadioButton1.Checked == true) || (materialRadioButton2.Checked == true) || (materialRadioButton3.Checked == true) || (materialRadioButton4.Checked == true)))
                {
                    try
                    {
                        portal = SerialPort.GetPortNames();
                        if (portal.Length != 0)
                        {
                            for (int index = 0; index < portal.Length; ++index)
                                cport = portal[index].ToString();
                            materialSingleLineTextField4.Text = cport.Remove(0, 3);
                        }
                        c = 1;
                    }
                    catch { MessageBox.Show("COM port not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); }
                    if (c == 1)             // "/C cd " for simple bat files
                    {
                        if ((materialRadioButton3.Checked == true)) // FullDump
                        {
                            if (fdump == "")
                            {
                                MessageBox.Show("Folder for Full Dump is missing!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            }
                            else
                            {
                                string ex = Properties.Settings.Default.DumpEx;
                                Process process = new Process();
                                process.StartInfo.FileName = "cmd.exe";
                                process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\full_dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + fdump + " " + ex;
                                process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\full_dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + fdump + " " + ex;
                                process.Start();
                                //process.WaitForExit();
                            }
                        }
                        if (materialRadioButton2.Checked == true) // Flash
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\flasher.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + materialSingleLineTextField1.Text + " " + materialSingleLineTextField2.Text;
                            process.Start();
                            //process.WaitForExit();
                        }
                        if (materialRadioButton1.Checked == true) // Dump
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + materialSingleLineTextField1.Text + " " + materialSingleLineTextField2.Text;
                            process.Start();
                            //process.WaitForExit();
                        }
                        if (materialRadioButton4.Checked == true) // Disable Google FRP
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\dgfrp.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn;
                            process.Start();
                            //process.WaitForExit();
                        }
                    }
                    // else { MessageBox.Show("COM port not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); }
                }
                else { MessageBox.Show("Something is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); }
            }
            else { MessageBox.Show("emmcdl not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            portal = SerialPort.GetPortNames();
            if (portal.Length != 0)
            {
                for (int index = 0; index < portal.Length; ++index)
                    cport = portal[index].ToString();
                materialSingleLineTextField4.Text = cport.Remove(0, 3);
            }
            else
            {
                MessageBox.Show("COM port not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                materialLabel7.Text = "NO";
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            emmcdl = Properties.Settings.Default.emmcdl;
            if (File.Exists(emmcdl))
            {
                string code = Properties.Settings.Default.EDL_Code;
                if ((materialSingleLineTextField4.Text != "") && (code != ""))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\edl.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + code;
                    process.Start();
                    process.WaitForExit();
                    materialLabel8.Text = "YES";
                }
                else { MessageBox.Show("Something is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); materialLabel8.Text = "NO"; }
            }
            else { MessageBox.Show("emmcdl not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); } 
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            adbp = Properties.Settings.Default.ADB;
            if (File.Exists(adbp))
            {
                Process process1 = new Process();
                process1.StartInfo.FileName = "cmd.exe";
                process1.StartInfo.Arguments = "/C " + @adbp + " reboot edl";
                process1.Start();
                process1.WaitForExit();
                Thread.Sleep(8000);
                materialLabel8.Text = "YES";
                string str = "adb";
                foreach (Process process2 in Process.GetProcesses())
                {
                    if (process2.ProcessName.ToLower().Contains(str.ToLower()))
                        process2.Kill();
                }
            }
            else { MessageBox.Show("ADB not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign); materialLabel8.Text = "NO"; }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked == true) {  saveFileDialog1.FileName = materialSingleLineTextField1.Text; saveFileDialog1.Filter = "DumpIMG (*.img)|*.img|DumpBIN (*.bin)|*.bin|Dump (*.dump)| *.dump"; if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return; materialSingleLineTextField2.Text = saveFileDialog1.FileName; }
            if (materialRadioButton2.Checked == true) {  openFileDialog1.FileName = materialSingleLineTextField1.Text; openFileDialog1.Filter = "Files for Flash|*.dump;*.bin;*.img"; if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return; materialSingleLineTextField2.Text = openFileDialog1.FileName; }
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton3.Checked == true) { materialSingleLineTextField2.Clear();  materialSingleLineTextField2.Enabled = false; materialRaisedButton8.Enabled = false; materialSingleLineTextField1.Clear(); materialSingleLineTextField1.Enabled = false; materialRaisedButton9.Visible = true; materialRaisedButton7.Enabled = true; materialRaisedButton10.Visible = true; materialRaisedButton1.Visible = false; ; }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked == true) { materialSingleLineTextField2.Enabled = true; materialRaisedButton8.Enabled = true; materialSingleLineTextField1.Enabled = true; materialRaisedButton9.Visible = false; materialRaisedButton7.Enabled = true; materialRaisedButton10.Visible = false; materialRaisedButton1.Visible = true; }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked == true) { materialSingleLineTextField2.Enabled = true; materialRaisedButton8.Enabled = true; materialSingleLineTextField1.Enabled = true; materialRaisedButton9.Visible = false; materialRaisedButton7.Enabled = true; materialRaisedButton10.Visible = false; materialRaisedButton1.Visible = true; }

        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            fdump = Properties.Settings.Default.FDump;
            Process.Start("explorer", fdump);
        }

        private void materialSingleLineTextField4_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "") { materialLabel7.Text = "NO"; }
            if (materialSingleLineTextField4.Text != "") { materialLabel7.Text = "YES"; }
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton4.Checked == true) { materialSingleLineTextField2.Clear(); materialSingleLineTextField2.Enabled = false; materialRaisedButton8.Enabled = false; materialSingleLineTextField1.Clear(); materialSingleLineTextField1.Enabled = false; materialRaisedButton9.Visible = false; materialRaisedButton7.Enabled = false; materialRaisedButton10.Visible = false; materialRaisedButton1.Visible = true; }
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            f = new About();
            f.Show();
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            Process.Start("Partitions.txt");
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            f = new Settings();
            f.Show();
        }
    }
}
