using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindRead.bean;

namespace WindRead.constants
{
    /// <summary>
    /// 常量类
    /// </summary>
    public class Constants
    {
        public static String resourcesPath = "WindRead.Properties.Resources";

        public static String systemConfigName = "config";

        public static Dictionary<String, Object> keyValues = new Dictionary<String, Object>();

        //系统设置文件名称
        public static String configName = "/configuration.xml";
        //写入XML文件时需要过滤的字段
        public static String[] filterField = new String[] { "chapters" };

        //测试时打开
        //public static String configPath = @"D:\test\read\config";
        public static String configPath = System.IO.Directory.GetCurrentDirectory() + "\\config";

        public static String defaultTxtEncoding = "gb2312";

        public static String chapterScanRule = "^第?[一二两三四五六七八九十零千百0123456789]{1,8}[章篇集节卷回部]{1,1}([ -:：；;]+.{0,30}|$)";


        public static int MainFormWidthMin = 800;
        public static int MainFormHeightMin = 494;

        public static int MainFormWidthMedium = 1100;
        public static int MainFormHeightMedium = 680;

        public static int MainFormWidthMax = 1400;
        public static int MainFormHeightMax = 865;


        



    }
}
