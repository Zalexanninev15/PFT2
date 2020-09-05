using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;

namespace PFT2
{
    public partial class About : MaterialForm
    {
        Form f;

        public About()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zalexanninev15.github.io/PFT2");
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            f = new License();
            f.Show();
        }
    }
}