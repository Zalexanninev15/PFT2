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
            string pftf;
            using (Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
            {
                pftf = Convert.ToString(reg.GetValue("InfoVisible"));
            }
            if (pftf != "1")
            {
                DialogResult result = MessageBox.Show("By using this SOFTWARE, you agree that you are responsible for your further actions and their consequences. The author only supports the \"FT2\" project and answers questions that are directly related to the PTT 2 application itself. Of the devices, the author can only help with ZTE Blade V9 Vita!", "Agreement of use of the application", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    using (Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Zalexanninev15\PFT2"))
                    {
                        reg.SetValue("InfoVisible", "1");
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
