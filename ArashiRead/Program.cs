using ArashiRead.config;
using ArashiRead.util;
using System;
using System.Windows.Forms;

namespace ArashiRead
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
            //加载配置
            ConfigUtil.Init();
            if (ConfigCache.display == null || ConfigCache.display.fontSize == 0)
            {
                MessageBox.Show("配置加载失败");
            }
            //Application.Run(new SettingForm(new MainForm()));
            Application.Run(new MainForm());
        }
    }
}
