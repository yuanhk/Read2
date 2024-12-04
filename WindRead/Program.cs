using System;
using System.Drawing;
using System.Windows.Forms;
using WindRead.cache;
using WindRead.form;
using WindRead.util;

namespace WindRead
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //获取配置
            ConfigUtil.Init();
            ThemeUtil.AntdUIInit(ConfigCache.theme);

           
           MainForm mainForm = new MainForm();
           mainForm.RedrawFormControls(ConfigCache.theme);

            Application.Run(mainForm);
        }
    }
}
