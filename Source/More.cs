using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using System;

namespace PFT2
{
    public partial class More : MaterialForm
    {

        public More()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2\More"))
            {
                if (checkBox5.Checked == true)
                {
                    reg.SetValue("IMG_System", "on");
                    reg.SetValue("IMG_Vendor", "on");
                    reg.SetValue("IMG_All", "on");
                }
                if (checkBox5.Checked == false)
                {
                    reg.SetValue("IMG_System", "off");
                    reg.SetValue("IMG_Vendor", "off");
                    reg.SetValue("IMG_All", "off");
                }
                if (checkBox1.Checked == true)
                    reg.SetValue("IMG_System", "on");
                if (checkBox1.Checked == false)
                    reg.SetValue("IMG_System", "off");
                if (checkBox4.Checked == true)
                    reg.SetValue("IMG_Vendor", "on");
                if (checkBox4.Checked == false)
                    reg.SetValue("IMG_Vendor", "off");
                if (materialCheckBox1.Checked == true)
                    reg.SetValue("GUI", "on");
                if (materialCheckBox1.Checked == false)
                    reg.SetValue("GUI", "off");
            }
        }

        private void More_Load(object sender, EventArgs e)
        {
            string IMG_Vendor, IMG_System, IMG_All, GUI;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            using (RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2\More"))
            {
                IMG_System = Convert.ToString(reg.GetValue("IMG_System"));
                IMG_Vendor = Convert.ToString(reg.GetValue("IMG_Vendor"));
                IMG_All = Convert.ToString(reg.GetValue("IMG_All"));
                GUI = Convert.ToString(reg.GetValue("GUI"));
            }
            if (IMG_All == "")
                IMG_All = "off"; 
            if (IMG_All == "on") { checkBox5.Checked = true; checkBox4.Checked = true; checkBox1.Checked = true; checkBox4.Enabled = false; checkBox1.Enabled = false; }
            if (IMG_All == "off") { checkBox5.Checked = false; checkBox4.Checked = false; checkBox1.Checked = false; checkBox4.Enabled = true; checkBox1.Enabled = true; }
            if (IMG_System == "on")
                checkBox1.Checked = true;
            if (IMG_Vendor == "on")
                checkBox4.Checked = true; 
            if (GUI == "on")
                materialCheckBox1.Checked = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { checkBox4.Checked = true; checkBox1.Checked = true; checkBox4.Enabled = false; checkBox1.Enabled = false; }
            if (checkBox5.Checked == false) { checkBox4.Checked = false; checkBox1.Checked = false; checkBox4.Enabled = true; checkBox1.Enabled = true; }
        }
    }
}
