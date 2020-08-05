using System;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PFT2
{
    public partial class License : MaterialForm
    {
        public License()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.ControlBox = false;
        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}