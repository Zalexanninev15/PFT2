﻿using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using Microsoft.Win32;

namespace PFT2
{
    public partial class MainForm : MaterialForm
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);
        [DllImport("user32", CharSet = CharSet.Auto)]
#pragma warning disable CS0108
        internal extern static bool ReleaseCapture();
#pragma warning restore CS0108
        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
        }

        // =======================================================================================================================
        // =======================================================================================================================
        // =======================================================================================================================

        string[] portal;
        string theme, adbp, cport, emmcdl, fdump, temp, edl, mbn, code, IMG_All;
        int form2, choose;
        Form f;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                theme = Convert.ToString(reg.GetValue("Dark_Mode"));
                materialSingleLineTextField10.Text = Convert.ToString(reg.GetValue("ADB"));
                edl_code.Text = Convert.ToString(reg.GetValue("EDL_Code"));
                materialSingleLineTextField11.Text = Convert.ToString(reg.GetValue("MBN"));
                materialSingleLineTextField8.Text = Convert.ToString(reg.GetValue("FullDump_Folder"));
                materialSingleLineTextField7.Text = Convert.ToString(reg.GetValue("emmcdl"));
            }
            if (edl_code.Text == "")
            {
                edl_code.Text = "0xFE";
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
                {
                    reg.SetValue("EDL_Code", "0xFE");
                }
            }
            if ((theme == "") || (theme == "0"))
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
            try
            {
                string nver = "";
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Zalexanninev15/PFT2/master/UpdateData/last-ver.txt", @Application.StartupPath + @"\last_ver.txt");
                if (File.Exists(@Application.StartupPath + @"\last_ver.txt"))
                {
                    using (StreamReader str = new StreamReader(@Application.StartupPath + @"\last_ver.txt", Encoding.UTF8))
                    {
                        for (int i = 1; i == 1; i++)
                        {
                            nver = str.ReadLine();
                        }
                    }
                    File.Delete(@Application.StartupPath + @"\last_ver.txt");
                }
                if (Application.ProductVersion != nver)
                {
                    DialogResult result = MessageBox.Show("Want to go to version " + nver + "?", "New version detected!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        wc.DownloadFile("https://raw.githubusercontent.com/Zalexanninev15/PFT2/master/UpdateData/last-ver-url.txt", @Application.StartupPath + @"\last_ver_url.txt");
                        if (File.Exists(@Application.StartupPath + @"\last_ver_url.txt"))
                        {
                            using (StreamReader str = new StreamReader(@Application.StartupPath + @"\last_ver_url.txt", Encoding.UTF8))
                            {
                                for (int i = 1; i == 1; i++)
                                {
                                    nver = str.ReadLine();
                                }
                            }
                            Process.Start(nver);
                            File.Delete(@Application.StartupPath + @"\last_ver_url.txt");
                        }
                    }
                }
            }
            catch { }
        }

        void materialRaisedButton1_ClickAsync(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                emmcdl = Convert.ToString(reg.GetValue("emmcdl"));
                fdump = Convert.ToString(reg.GetValue("FullDump_Folder"));
                mbn = Convert.ToString(reg.GetValue("MBN"));
            }
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2\more"))
            {
               IMG_All = Convert.ToString(reg.GetValue("IMG_All"));
            }
            if (materialRadioButton3.Checked == true) // Full Dump
            {
                if (IMG_All == "on")
                {
                    choose = 0;
                }
                else
                {
                    choose = 1;
                }
            }
            Task.Run(() => flasher());
        }

        async void flasher()
        {
            if (File.Exists(emmcdl))
            {
                int c = 0;
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
                    catch { MessageBox.Show("COM port not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    if (c == 1)
                    {
                        try
                        {
                            if (materialRadioButton3.Checked == true) // Full Dump
                            {
                                if (fdump != "")
                                {
                                    if (choose == 1) // FDF
                                    {
                                        Process process = new Process();
                                        process.StartInfo.FileName = "cmd.exe";
                                        process.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\scripts\full_dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + fdump + " " + fdump + " " + fdump + " " + fdump;
                                        process.Start();
                                        process.WaitForExit();
                                        MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    if (choose == 0) // IMG
                                    {
                                        Process process = new Process();
                                        process.StartInfo.FileName = "cmd.exe";
                                        process.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\scripts\full_dumpIMG.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + fdump;
                                        process.Start();
                                        process.WaitForExit();
                                        MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Folder for Full Dump is missing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            if (materialRadioButton2.Checked == true) // Flash
                            {
                                if (choose == 1) { FDFminiFlash(); }
                                Process process = new Process();
                                process.StartInfo.FileName = "cmd.exe";
                                process.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\scripts\flash.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + materialSingleLineTextField1.Text + " " + temp;
                                process.Start();
                                process.WaitForExit();
                                if (choose == 1)
                                {
                                    try { File.Delete(temp); }
                                    catch { MessageBox.Show("It is not possible to interact with the device or with file for flash!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                }
                                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (materialRadioButton1.Checked == true) // Dump
                            {
                                Process process = new Process();
                                process.StartInfo.FileName = "cmd.exe";
                                process.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\scripts\dump.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn + " " + materialSingleLineTextField1.Text + " " + temp;
                                process.Start();
                                process.WaitForExit();
                                if (choose == 1) { FDFminiDump(); }
                                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (materialRadioButton4.Checked == true) // Disable Google FRP
                            {
                                Process process = new Process();
                                process.StartInfo.FileName = "cmd.exe";
                                process.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\scripts\dgfrp.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + mbn;
                                process.Start();
                                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch { MessageBox.Show("Unknown error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }
                else { MessageBox.Show("Something is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("emmcdl not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
                MessageBox.Show("COM port not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                materialLabel7.Text = "NO";
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                code = Convert.ToString(reg.GetValue("EDL_Code"));
                emmcdl = Convert.ToString(reg.GetValue("emmcdl"));
            }
            if (File.Exists(emmcdl))
            {
                if ((materialSingleLineTextField4.Text != "") && (code != ""))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\scripts\edl.bat " + emmcdl + " " + materialSingleLineTextField4.Text + " " + code;
                    process.Start();
                    process.WaitForExit();
                    materialLabel8.Text = "YES";
                }
                else { MessageBox.Show("Something is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); materialLabel8.Text = "NO"; }
            }
            else { MessageBox.Show("emmcdl not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                adbp = Convert.ToString(reg.GetValue("ADB"));
            }
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
            else { MessageBox.Show("ADB not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); materialLabel8.Text = "NO"; }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            string IMG_Vendor, IMG_System;
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2\More"))
            {
                IMG_System = Convert.ToString(reg.GetValue("IMG_System"));
                IMG_Vendor = Convert.ToString(reg.GetValue("IMG_Vendor"));
                IMG_All = Convert.ToString(reg.GetValue("IMG_All"));
            }
            if (materialRadioButton1.Checked == true)  // Dump (Save file)
            {
                saveFileDialog1.FileName = materialSingleLineTextField1.Text;
                if ((materialSingleLineTextField1.Text == "userdata") || (((IMG_System == "on") && (materialSingleLineTextField1.Text == "system")) || ((IMG_Vendor == "on") && (materialSingleLineTextField1.Text == "vendor")) || (IMG_All == "on")))
                {
                    saveFileDialog1.Filter = "IMG|*.img";
		           choose = 0;
                }
                else
                {
                    saveFileDialog1.Filter = "FDF|*.fdf";
                    choose = 1;
                }
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                materialSingleLineTextField2.Text = saveFileDialog1.FileName;
                if (choose == 1) { temp = saveFileDialog1.FileName + ".temp"; }
                else { temp = saveFileDialog1.FileName; }
            }
            if (materialRadioButton2.Checked == true) // Flash (Open file)
            {
                openFileDialog1.FileName = materialSingleLineTextField1.Text;
                if ((materialSingleLineTextField1.Text == "userdata") || (((IMG_System == "on") && (materialSingleLineTextField1.Text == "system")) || ((IMG_Vendor == "on") && (materialSingleLineTextField1.Text == "vendor")) || (IMG_All == "on")))
                {
                    openFileDialog1.Filter = "IMG|*.img";
		            choose = 0;
                }
                else
                {
                    openFileDialog1.Filter = "FDF|*.fdf";
                    choose = 1;
                }
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                      materialSingleLineTextField2.Text = openFileDialog1.FileName;
                if (choose == 1) { temp = openFileDialog1.FileName + ".temp"; }
                else { temp = openFileDialog1.FileName; }
            }
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton3.Checked == true) { materialSingleLineTextField2.Clear(); materialSingleLineTextField2.Enabled = false; materialRaisedButton8.Enabled = false; materialSingleLineTextField1.Clear(); materialSingleLineTextField1.Enabled = false; folder_full_dump.Visible = true; materialRaisedButton7.Enabled = true; create_full_dump.Visible = true; do_it.Visible = false; ; }
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton1.Checked == true) { do_it.Text = "Create Dump"; materialSingleLineTextField2.Enabled = true; materialRaisedButton8.Enabled = true; materialSingleLineTextField1.Enabled = true; folder_full_dump.Visible = false; materialRaisedButton7.Enabled = true; create_full_dump.Visible = false; do_it.Visible = true; }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton2.Checked == true) { do_it.Text = "Flash Dump"; materialSingleLineTextField2.Enabled = true; materialRaisedButton8.Enabled = true; materialSingleLineTextField1.Enabled = true; folder_full_dump.Visible = false; materialRaisedButton7.Enabled = true; create_full_dump.Visible = false; do_it.Visible = true; }

        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                fdump = Convert.ToString(reg.GetValue("FullDump_Folder"));
            }
            if (fdump != "")
            {
                Process.Start("explorer", fdump);
            }
            else
            {
                MessageBox.Show("Folder for Full Dump is missing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void materialSingleLineTextField4_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text == "") { materialLabel7.Text = "NO"; }
            if (materialSingleLineTextField4.Text != "") { materialLabel7.Text = "YES"; materialLabel7.Text = "YES"; }
        }

        private void materialRaisedButton12_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "FM")
                {
                    form2 = 1;
                }
                else { form2 = 0; }
            }
            if (form2 == 0)
            {
                f = new FirmwaresManager();
                f.Show();
            }
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (materialRadioButton4.Checked == true) { do_it.Text = "Disable Google FRP"; materialSingleLineTextField2.Clear(); materialSingleLineTextField2.Enabled = false; materialRaisedButton8.Enabled = false; materialSingleLineTextField1.Clear(); materialSingleLineTextField1.Enabled = false; folder_full_dump.Visible = false; materialRaisedButton7.Enabled = false; create_full_dump.Visible = false; do_it.Visible = true; }
        }

        private void materialRaisedButton18_Click(object sender, EventArgs e)
        {
			adb_device_status_text.Text = "...";
             Task.Run(() => ADBCommander("get-state"));
        }

        private void materialRaisedButton17_Click(object sender, EventArgs e)
        {
			adb_device_status_text.Text = "...";
             Task.Run(() => ADBCommander("reboot"));
        }

        private void materialRaisedButton16_Click(object sender, EventArgs e)
        {
            adb_device_status_text.Text = "...";
             Task.Run(() => ADBCommander("reboot recovery"));
        }

        private void materialRaisedButton14_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "APK|*.apk";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                adb_apk.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton15_Click(object sender, EventArgs e)
        {
            if (adb_install_apk_sd.Checked == true)
            {
                Task.Run(() => ADBCommander("install -r -s " + adb_apk.Text));
            }
            else
            {
                Task.Run(() => ADBCommander("install -r " + adb_apk.Text));
            }
        }

        private void materialRaisedButton13_Click(object sender, EventArgs e)
        {
            Task.Run(() => ADBCommander("shell pm uninstall -k --user 0 " + adb_package.Text));
        }

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "emmcdl|emmcdl.exe";
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
            openFileDialog1.Filter = "ADB|adb.exe";
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
            edl = edl_code.Text;
            edl_code.Clear();
        }

        private void materialRaisedButton22_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                reg.SetValue("Dark_Mode", "0");
                reg.SetValue("ADB", "");
                reg.SetValue("EDL_Code", "0xFE");
                reg.SetValue("MBN", "");
                reg.SetValue("FullDump_Folder", "");
                reg.SetValue("emmcdl", "");
            }
            materialSingleLineTextField7.Clear();
            edl_code.Text = "0xFE";
            materialSingleLineTextField8.Clear();
            materialSingleLineTextField10.Clear();
            materialSingleLineTextField11.Clear();
            b_w.Checked = false;
        }

        private void materialRaisedButton23_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                reg.SetValue("ADB", materialSingleLineTextField10.Text);
                reg.SetValue("EDL_Code", edl_code.Text);
                reg.SetValue("MBN", materialSingleLineTextField11.Text);
                reg.SetValue("FullDump_Folder", materialSingleLineTextField8.Text);
                reg.SetValue("emmcdl", materialSingleLineTextField7.Text);
            }
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Apps.txt");
            }
            catch { MessageBox.Show("The file with apps is not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void materialSingleLineTextField9_Leave(object sender, EventArgs e)
        {
            edl_code.Text = edl;
        }

        private void b_w_CheckedChanged(object sender, EventArgs e)
        {
            if (b_w.Checked)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green100, Accent.Yellow200, TextShade.WHITE);
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
                {
                    reg.SetValue("Dark_Mode", "1");
                }
            }
            if (!b_w.Checked)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue500, Accent.Blue200, TextShade.WHITE);
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
                {
                    reg.SetValue("Dark_Mode", "0");
                }
            }
        }

        private void materialSingleLineTextField9_TextChanged(object sender, EventArgs e)
        {
            if (edl_code.Text == "more")
            {
                edl_code.Text = edl;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "More")
                    {
                        form2 = 1;
                    }
                    else { form2 = 0; }
                }
                if (form2 == 0)
                {
                    f = new More();
                    f.Show();
                }
            }
            if (edl_code.Text == "con")
            {
                string GUI;
                using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2\More"))
                {
                    GUI = Convert.ToString(reg.GetValue("GUI"));
                }
                if (GUI == "on")
                {
                    edl_code.Text = edl;
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f.Name == "FDFminiConverter")
                        {
                            form2 = 1;
                        }
                        else { form2 = 0; }
                    }
                    if (form2 == 0)
                    {
                        f = new FDFminiConverter();
                        f.Show();
                    }
                }
            }
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "About")
                {
                    form2 = 1;
                }
                else { form2 = 0; }
            }
            if (form2 == 0)
            {
                f = new About();
                f.Show();
            }
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Partitions.txt");
            }
            catch { MessageBox.Show("The file with partitions is not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void FDFminiDump()
        {
            Process FDFmini = new Process();
            FDFmini.StartInfo.FileName = "cmd.exe";
            FDFmini.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\FDFmini.exe " + "-img" + " " + temp + " " + materialSingleLineTextField2.Text + " " + "-c";
            FDFmini.Start();
            FDFmini.WaitForExit();
            File.Delete(temp);

        }

        public void FDFminiFlash()
        {
            Process FDFmini = new Process();
            FDFmini.StartInfo.FileName = "cmd.exe";
            FDFmini.StartInfo.Arguments = "/C " + @Application.StartupPath + @"\FDFmini.exe " + "-fdf" + " " + materialSingleLineTextField2.Text + " " + temp + " " + "-u";
            FDFmini.Start();
            FDFmini.WaitForExit();
        }

        async void ADBCommander(string command)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                adbp = Convert.ToString(reg.GetValue("ADB"));
            }
            if (File.Exists(adbp))
            {
                MessageBox.Show("Work is underway...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process process1 = new Process();
                process1.StartInfo.FileName = "cmd.exe";
                process1.StartInfo.Arguments = "/C " + @adbp + " " + command;
                process1.StartInfo.RedirectStandardOutput = true;
                process1.StartInfo.UseShellExecute = false;
                process1.StartInfo.CreateNoWindow = true;
                process1.Start();
                process1.WaitForExit();
                if ((command == "get-state") || (command == "reboot") || (command == "reboot recovery"))
                    adb_device_status_text.Text = process1.StandardOutput.ReadToEnd();
                string str = "adb";
                foreach (Process process2 in Process.GetProcesses())
                {
                    if (process2.ProcessName.ToLower().Contains(str.ToLower()))
                        process2.Kill();
                }
                if ((command != "get-state") && (command != "reboot") && (command != "reboot recovery"))
                {
                    MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else { MessageBox.Show("ADB not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
