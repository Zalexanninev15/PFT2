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
            System.Diagnostics.Process.Start("https://4pda.ru/forum/index.php?s=&showtopic=952274&view=findpost&p=93484684");
        }
    }
}