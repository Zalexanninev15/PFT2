using System;
using System.Windows.Forms;

namespace PFT2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DialogResult result = MessageBox.Show("By using this SOFTWARE, you agree that you are responsible for your further actions and their consequences. The author only support the PFT2 project and answers questions directly related to the PFT2 application itself. From devices, the author can only help with the ZTE Blade V9 Vita!", "Terms of use", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
