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
    public class PrimaryScreen
    {
        /// <summary>
        /// 设备数据函数
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public static double GetScreenScalingFactor()
        {
            var g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            var physicalScreenHeight = GetDeviceCaps(desktop, 117);//硬件显示器分辨率实际设置的高
            var physicalScreenWidth = GetDeviceCaps(desktop, 118);//硬件显示器分辨率实际设置的宽
            var screenScalingFactor = (double)physicalScreenHeight / Screen.PrimaryScreen.Bounds.Height;//将实际的高除以抓取的换算过的高就等于缩放率，同理当需要获取实际宽高时，直接获取函数结果即可
            return screenScalingFactor;
        }
    }
}
