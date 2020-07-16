using System;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Diagnostics;

namespace PFT2
{
    public partial class FDFminiGUI : MaterialForm
    {
 
        public FDFminiGUI()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            if ((materialSingleLineTextField1.Text != "") && (materialSingleLineTextField2.Text != ""))
            {
                string par = "";
                if (materialCheckBox1.Checked == true) { par = "-img " + @materialSingleLineTextField1.Text + " " + @materialSingleLineTextField2.Text + " -c"; }
                if (materialCheckBox2.Checked == true) { par = "-fdf " + @materialSingleLineTextField1.Text + " " + @materialSingleLineTextField2.Text + " -u"; }
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"FDFmini.exe",
                        Arguments = @par,
                        CreateNoWindow = false
                    }
                };
                process.Start();
            }
            if ((materialSingleLineTextField1.Text == "") || (materialSingleLineTextField2.Text == ""))
            {
                MessageBox.Show("Fill in one of the fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void materialCheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = ""; materialSingleLineTextField2.Text = "";
            if (materialCheckBox1.Checked == true) { materialSingleLineTextField1.Enabled = true; materialSingleLineTextField2.Enabled = true; materialRaisedButton7.Enabled = true; materialRaisedButton1.Enabled = true; }
            if (materialCheckBox1.Checked == false) { materialSingleLineTextField1.Enabled = false; materialSingleLineTextField2.Enabled = false; materialRaisedButton7.Enabled = false; materialRaisedButton1.Enabled = false; }
        }

        private void materialCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = ""; materialSingleLineTextField2.Text = "";
            if (materialCheckBox2.Checked == true) { materialSingleLineTextField1.Enabled = true; materialSingleLineTextField2.Enabled = true; materialRaisedButton7.Enabled = true; materialRaisedButton1.Enabled = true; }
            if (materialCheckBox2.Checked == false) { materialSingleLineTextField1.Enabled = false; materialSingleLineTextField2.Enabled = false; materialRaisedButton7.Enabled = false; materialRaisedButton1.Enabled = false; }
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (materialCheckBox1.Checked == true) { openFileDialog1.Filter = "IMG|*.img"; }
            if (materialCheckBox2.Checked == true) { openFileDialog1.Filter = "FDF|*.fdf"; }
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField1.Text = openFileDialog1.FileName;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (materialCheckBox2.Checked == true) { saveFileDialog1.Filter = "IMG|*.img"; }
            if (materialCheckBox1.Checked == true) { saveFileDialog1.Filter = "FDF|*.fdf"; }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            materialSingleLineTextField2.Text = saveFileDialog1.FileName;
        }
    }
}