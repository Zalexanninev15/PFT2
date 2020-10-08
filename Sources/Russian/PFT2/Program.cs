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
                DialogResult result = MessageBox.Show("Используя данное ПО вы соглашаетесь, что сами несёте ответственность за свои дальнейшие действия и их последствия. Автор лишь поддерживает проект \"PFT2\" и отвечает на вопросы, которые непосредственно связаны с самим приложением PFT2. Из устройств, автор может помочь лишь с ZTE Blade V9 Vita!", "Соглашение об использовании приложения", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
