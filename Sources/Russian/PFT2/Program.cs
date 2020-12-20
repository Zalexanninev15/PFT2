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
            DialogResult result = MessageBox.Show("Используя это ПРОГРАММНОЕ ОБЕСПЕЧЕНИЕ, вы соглашаетесь с тем, что несете ответственность за свои дальнейшие действия и их последствия. Автор поддерживает только проект PFT2 и отвечает на вопросы, которые связаны с самим приложением PFT2. Из устройств, автор может помочь только с ZTE Blade V9 Vita!", "Условия использования", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
