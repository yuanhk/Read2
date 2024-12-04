using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindRead.util
{
    public static class FormSizeUtil
    {

        /// <summary>
        /// 设备数据函数
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public static void getIntPtr()
        {
            var g = Graphics.FromHwnd(IntPtr.Zero).GetHdc();

        }

        public static float getXMultiple()
        {
            IntPtr desktop = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
            var physicalScreenWidth = GetDeviceCaps(desktop, 118);//硬件显示器分辨率实际设置的宽
            return physicalScreenWidth / 2560F;
        }

        public static float getYMultiple()
        {
            IntPtr desktop = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
            var physicalScreenWidth = GetDeviceCaps(desktop, 117);//硬件显示器分辨率实际设置的宽
            return physicalScreenWidth / 1400F;
        }

        /// <summary>
        /// 根据显示器尺寸调整窗体尺寸
        /// </summary>
        /// <param name="form"></param>
        public static void AutoResize(this Form form) {
            float m1 = getXMultiple(), m2 = getYMultiple();
            form.Width = (int)(form.Width*m1);
            form.Height= (int)(form.Height * m2);
        }

    }
}
