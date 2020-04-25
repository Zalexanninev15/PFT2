using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PFT2
{
    public partial class About : MaterialForm
    {
        public About()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Zalexanninev15/PFT2");
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://translate.google.ru/translate?sl=ru&tl=en&u=https%3A%2F%2F4pda.ru%2Fforum%2Findex.php%3Fshowtopic%3D952274%26st%3D1160%23entry93484684");
        }
    }
}