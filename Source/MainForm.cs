using System;
using System.Diagnostics;
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
        string theme, adbp, cport, emmcdl, fdump, temp, choose, edl;
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
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
            }
            if (theme == "1")
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green100, Accent.Yellow200, TextShade.WHITE);
                b_w.Checked = true;
            }
            materialSingleLineTextField10.Text = Properties.Settings.Default.ADB;
            materialSingleLineTextField9.Text = Properties.Settings.Default.EDL_Code;
            materialSingleLineTextField11.Text = Properties.Settings.Default.MBNFile;
            materialSingleLineTextField8.Text = Properties.Settings.Default.FDump;
            materialSingleLineTextField7.Text = Properties.Settings.Default.emmcdl;
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
                    catch { MessageBox.Show("COM port not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
                    if (c == 1)             // "/C cd " for simple bat files
                    {
                        if ((materialRadioButton3.Checked == true)) // Full Dump
                        {
                            if (fdump == "")
                            {
                                MessageBox.Show("Folder for Full Dump is missing!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            }
                            else
                            {
                                Process process = new Process();
                                process.StartInfo.FileName = "cmd.exe";
                                process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\scripts\\full_dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + fdump + " " + fdump + " " + fdump + " " + fdump;
                                process.Start();
                                process.WaitForExit();
                                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            }
                        }
                        if (materialRadioButton2.Checked == true) // Flash
                        {
                            if (choose == "1") { FDFminiFlash(); }
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\scripts\\flash.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + materialSingleLineTextField1.Text + " " + temp;
                            process.Start();
                            process.WaitForExit();
                            File.Delete(@temp);
                            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        }
                        if (materialRadioButton1.Checked == true) // Dump
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\scripts\\dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + materialSingleLineTextField1.Text + " " + temp;
                            process.Start();
                            process.WaitForExit();
                            if (choose == "1") { FDFminiDump(); }
                            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        if (materialRadioButton4.Checked == true) // Disable Google FRP
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\scripts\\dgfrp.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn;
                            process.Start();
                            //process.WaitForExit();
                             MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                    // else { MessageBox.Show("COM port not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
                }
                else { MessageBox.Show("Something is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
            }
            else { MessageBox.Show("emmcdl not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
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
                MessageBox.Show("COM port not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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
                    process.StartInfo.Arguments = "/C " + Application.StartupPath + "\\scripts\\edl.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + code;
                    process.Start();
                    process.WaitForExit();
                    materialLabel8.Text = "YES";
                }
                else { MessageBox.Show("Something is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); materialLabel8.Text = "NO"; }
            }
            else { MessageBox.Show("emmcdl not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
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
            else { MessageBox.Show("ADB not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); materialLabel8.Text = "NO"; }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked == true)  //DUMP (Save file)
            {
                saveFileDialog1.FileName = materialSingleLineTextField1.Text;
                if ((materialSingleLineTextField1.Text == "userdata") || (((Properties.Settings.Default.IMGsys == "on") && (materialSingleLineTextField1.Text == "system")) || ((Properties.Settings.Default.IMGVedro == "on") && (materialSingleLineTextField1.Text == "vendor")) || (Properties.Settings.Default.IMGAll == "on")))
                {
                    saveFileDialog1.Filter = "IMG|*.img";
                }
                else
                {
                    saveFileDialog1.Filter = "FDF|*.fdf";
                    choose = "1";
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                materialSingleLineTextField2.Text = saveFileDialog1.FileName;
                if (choose == "1") { temp = saveFileDialog1.FileName + ".temp"; }
                else { temp = saveFileDialog1.FileName; }
            }
            if (materialRadioButton2.Checked == true) //FLASH (Open file)
            {
                openFileDialog1.FileName = materialSingleLineTextField1.Text;
                if ((materialSingleLineTextField1.Text == "userdata") || (((Properties.Settings.Default.IMGsys == "on") && (materialSingleLineTextField1.Text == "system")) || ((Properties.Settings.Default.IMGVedro == "on") && (materialSingleLineTextField1.Text == "vendor")) || (Properties.Settings.Default.IMGAll == "on")))
                {
                    openFileDialog1.Filter = "IMG|*.img";
                }
                else
                {
                    openFileDialog1.Filter = "FDF|*.fdf";
                    choose = "1";
                }
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                materialSingleLineTextField2.Text = openFileDialog1.FileName;
                if (choose == "1") { temp = openFileDialog1.FileName + ".temp"; }
                else { temp = openFileDialog1.FileName; }
            }
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton3.Checked == true) { materialSingleLineTextField2.Clear(); materialSingleLineTextField2.Enabled = false; materialRaisedButton8.Enabled = false; materialSingleLineTextField1.Clear(); materialSingleLineTextField1.Enabled = false; materialRaisedButton9.Visible = true; materialRaisedButton7.Enabled = true; materialRaisedButton10.Visible = true; materialRaisedButton1.Visible = false; ; }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked == true) { materialRaisedButton1.Text = "Create Dump"; materialSingleLineTextField2.Enabled = true; materialRaisedButton8.Enabled = true; materialSingleLineTextField1.Enabled = true; materialRaisedButton9.Visible = false; materialRaisedButton7.Enabled = true; materialRaisedButton10.Visible = false; materialRaisedButton1.Visible = true; }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked == true) { materialRaisedButton1.Text = "Flash Dump"; materialSingleLineTextField2.Enabled = true; materialRaisedButton8.Enabled = true; materialSingleLineTextField1.Enabled = true; materialRaisedButton9.Visible = false; materialRaisedButton7.Enabled = true; materialRaisedButton10.Visible = false; materialRaisedButton1.Visible = true; }

        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            fdump = Properties.Settings.Default.FDump;
            Process.Start("explorer", fdump);
        }

        private void materialSingleLineTextField4_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "") { materialLabel7.Text = "NO"; }
            if (materialSingleLineTextField4.Text != "") { materialLabel7.Text = "YES"; materialLabel7.Text = "YES"; }
        }

        private void materialRaisedButton12_Click(object sender, EventArgs e)
        {
            f = new FM();
            f.Show();
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton4.Checked == true) { materialRaisedButton1.Text = "Disable Google FRP"; materialSingleLineTextField2.Clear(); materialSingleLineTextField2.Enabled = false; materialRaisedButton8.Enabled = false; materialSingleLineTextField1.Clear(); materialSingleLineTextField1.Enabled = false; materialRaisedButton9.Visible = false; materialRaisedButton7.Enabled = false; materialRaisedButton10.Visible = false; materialRaisedButton1.Visible = true; }
        }

        private void materialRaisedButton18_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField6.Clear();
            ADBCommander("get-state");
        }

        private void materialRaisedButton17_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField6.Clear();
            ADBCommander("reboot");
        }

        private void materialRaisedButton16_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField6.Clear();
            ADBCommander("reboot recovery");
        }

        private void materialRaisedButton14_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "APK|*.apk";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField5.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton15_Click(object sender, EventArgs e)
        {
            ADBCommander("install -r " + materialSingleLineTextField5.Text);
            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void materialRaisedButton13_Click(object sender, EventArgs e)
        {
            ADBCommander("shell pm uninstall -k --user 0 " + materialSingleLineTextField3.Text);
            MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "emmcdl file|emmcdl.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField7.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton21_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Flasher file|*.mbn";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField11.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton20_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "ADB file|adb.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField10.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton19_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    materialSingleLineTextField8.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void materialSingleLineTextField9_Enter(object sender, EventArgs e)
        {
            edl = materialSingleLineTextField9.Text;
            materialSingleLineTextField9.Clear();
        }

        private void materialRaisedButton22_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ADB = "";
            Properties.Settings.Default.EDL_Code = "0xFE";
            Properties.Settings.Default.MBNFile = "";
            Properties.Settings.Default.FDump = ""; ;
            Properties.Settings.Default.DarkMode = "";
            Properties.Settings.Default.emmcdl = "";
            Properties.Settings.Default.Save();

            materialSingleLineTextField7.Clear();
            materialSingleLineTextField9.Text = "0xFE";
            materialSingleLineTextField8.Clear();
            materialSingleLineTextField10.Clear();
            materialSingleLineTextField11.Clear();
            b_w.Checked = false;
        }

        private void materialRaisedButton23_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ADB = materialSingleLineTextField10.Text;
            Properties.Settings.Default.EDL_Code = materialSingleLineTextField9.Text;
            Properties.Settings.Default.MBNFile = materialSingleLineTextField11.Text;
            Properties.Settings.Default.FDump = materialSingleLineTextField8.Text;
            Properties.Settings.Default.emmcdl = materialSingleLineTextField7.Text;
            Properties.Settings.Default.Save();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            Process.Start("apps.txt");
        }

        private void b_w_CheckedChanged(object sender, EventArgs e)
        {
            if (b_w.Checked)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green100, Accent.Yellow200, TextShade.WHITE);
                Properties.Settings.Default.DarkMode = "1";
                Properties.Settings.Default.Save();
            }
            if (!b_w.Checked)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
                Properties.Settings.Default.DarkMode = "";
                Properties.Settings.Default.Save();
            }
        }

        private void materialSingleLineTextField9_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField9.Text == "more")
            {
                materialSingleLineTextField9.Text = edl;
                f = new More();
                f.Show();
            }
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

        public void FDFminiDump()
        {
            Process FDFmini = new Process();
            FDFmini.StartInfo.FileName = "cmd.exe";
            FDFmini.StartInfo.Arguments = "/C " + Application.StartupPath + "\\FDFmini.exe " + "-img" + " " + temp + " " + materialSingleLineTextField2.Text + " " + "-c";
            FDFmini.Start();
            FDFmini.WaitForExit();
            File.Delete(@temp);

        }

        public void FDFminiFlash()
        {
            Process FDFmini = new Process();
            FDFmini.StartInfo.FileName = "cmd.exe";
            FDFmini.StartInfo.Arguments = "/C " + Application.StartupPath + "\\FDFmini.exe " + "-fdf" + " " + materialSingleLineTextField2.Text + " " + temp + " " + "-u";
            FDFmini.Start();
            FDFmini.WaitForExit();
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
                if ((command == "get-state") || (command == "reboot") || (command == "reboot recovery")) { materialSingleLineTextField6.Text = process1.StandardOutput.ReadToEnd(); }
                string str = "adb";
                foreach (Process process2 in Process.GetProcesses())
                {
                    if (process2.ProcessName.ToLower().Contains(str.ToLower()))
                        process2.Kill();
                }
            }
            else { MessageBox.Show("ADB not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); }
        }
    }

}