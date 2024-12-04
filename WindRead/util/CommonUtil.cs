using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.constants;

namespace WindRead.util
{
    /// <summary>
    /// 通用工具类
    /// </summary>
    public class CommonUtil : NativeWindow
    {



        public static Keys toKeys(String s)
        {
            Keys k;
            Enum.TryParse<Keys>(s, out k);
            return k;
        }


        /// <summary>
        /// 书籍为空
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool FileIsBlank(String url)
        {
            return !isExist(url) || new FileInfo(url).Length == 0;
        }

        //判断文件是否存在
        public static bool isExist(String url)
        {
            return url != null && url.Length > 0 && File.Exists(url);
        }

        //相除且进一
        public static int divideCeiling(Object a, Object b)
        {
            if (a != null && b != null)
            {
                decimal num1; //定义两个数字类型
                decimal num2;
                if (Decimal.TryParse(a.ToString(), out num1) && Decimal.TryParse(b.ToString(), out num2))
                {
                    return (int)Math.Ceiling(num1 / num2);
                }

            }
            return -1;
        }

        //转为字符串
        public static string toString(Object obj)
        {
            if (obj == null) return "";
            return obj.ToString();
        }

        //转为字符串
        public static string toString(Object obj, String defaultStr)
        {
            if (obj == null) return defaultStr;
            return obj.ToString();
        }

        //判断字符串为空
        public static bool isBlank(String str)
        {
            return str == null || str.Length == 0;
        }

        //判断字符串不为空
        public static bool notBlank(String str)
        {
            return str != null && str.Length > 0;
        }

        //首字母大写
        public String ToTitleCase(String str)
        {
            if (str != null && str.Length > 0)
            {
                char[] cs = str.ToCharArray();
                cs[0] = Char.ToUpper(cs[0]);
                return cs.ToString();
            }
            return str;
        }

        public static String toRateStr(decimal d)
        {

            decimal s = Math.Round(d * 100, 2);
            if (s >= 100)
            {
                return "100%";
            }
            return Math.Round(d * 100, 2) + "%";
        }



        //储存大小格式转换
        public static string FormatSize(long bytes)
        {
            string[] Suffix = { "Byte", "KB", "MB", "GB", "TB" };
            int i = 0;
            double dblSByte = bytes;
            if (bytes > 1024)
                for (i = 0; (bytes / 1024) > 0; i++, bytes /= 1024)
                    dblSByte = bytes / 1024.0;
            return String.Format("{0:0.#}{1}", dblSByte, Suffix[i]);
        }

        //日志记录
        public static void saveLog(String errorMsg)
        {
            String path = Constants.configPath + "/ErrorLog.log";
            DateTime dt = DateTime.Now;
            string str = dt.ToString("yyyy-MM-dd HH:mm:ss");
            if (!File.Exists(path))
            {
                string createText = str + " | 创建日志文件" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            string appendText = str + " | " + errorMsg + Environment.NewLine;
            File.AppendAllText(path, appendText);
            File.ReadAllText(path);
        }

        //px转pt
        public static float toPt(int px)
        {
            float[] pts = { 5, 5.5f, 6.5f, 7, 7.5f, 8, 9, 10, 10.5f, 11, 12, 13, 13.5f, 14, 14.5f };
            return px >= 6 && px <= 20 ? pts[px - 6] : -1;
        }

        //pt转px
        public static int toPx(double pt)
        {

            Double[] items = { 5, 5.5, 6.5, 7, 7.5, 8, 9, 10, 10.5, 11, 12, 13, 13.5, 14, 14.5 };
            List<double> pts = items.ToList<double>();
            return pts.IndexOf(pt) == -1 ? -1 : pts.IndexOf(pt) + 6;
        }


        public static int toInt(Object obj)
        {
            return toInt(toString(obj), 0);
        }

        public static int toInt(String s, int i)
        {
            int intStrNum = 0;
            if (int.TryParse(s, out intStrNum))
            {
                return intStrNum;
            }
            return i;
        }


        //隐藏listView 水平滚动条
        public static void setAssignHandle(IntPtr Handle)
        {
            new CommonUtil().AssignHandle(Handle);
        }


        /// <summary>
        /// 打开路径并定位文件...对于@"h:\Bleacher Report - Hardaway with the safe call ??.mp4"这样的，explorer.exe /select,d:xxx不认，用API整它
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        [DllImport("shell32.dll", ExactSpelling = true)]
        private static extern void ILFree(IntPtr pidlList);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IntPtr ILCreateFromPathW(string pszPath);

        [DllImport("shell32.dll", ExactSpelling = true)]
        private static extern int SHOpenFolderAndSelectItems(IntPtr pidlList, uint cild, IntPtr children, uint dwFlags);

        public static void ExplorerFile(string filePath)
        {
            if (!File.Exists(filePath) && !Directory.Exists(filePath))
                return;

            if (Directory.Exists(filePath))
                Process.Start(@"explorer.exe", "/select,\"" + filePath + "\"");
            else
            {
                IntPtr pidlList = ILCreateFromPathW(filePath);
                if (pidlList != IntPtr.Zero)
                {
                    try
                    {
                        Marshal.ThrowExceptionForHR(SHOpenFolderAndSelectItems(pidlList, 0, IntPtr.Zero, 0));
                    }
                    finally
                    {
                        ILFree(pidlList);
                    }
                }
            }
        }

    }
}
