using System;
using System.Drawing;
using System.Globalization;

namespace ArashiRead.util
{
    /// <summary>
    /// 颜色工具类
    /// </summary>
    public class ColorUtil
    {
        public static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            if (red < 0) red = 0;

            if (red > 255) red = 255;

            if (green < 0) green = 0;

            if (green > 255) green = 255;

            if (blue < 0) blue = 0;

            if (blue > 255) blue = 255;

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }


        /// <summary>
        /// 字符串(xx,xx,xx)转颜色
        /// </summary>
        /// <param name="colorStr"></param>
        /// <returns></returns>
        public static Color toColor(String colorStr)
        {
            if (CommonUtil.notBlank(colorStr))
            {
                String[] s = colorStr.Split(',');
                if (s.Length == 3)
                {
                    return Color.FromArgb(Int32.Parse(s[0]), Int32.Parse(s[1]), Int32.Parse(s[2]));
                }
            }
            return Color.Transparent;
        }

        public static String toColorStr(Color color)
        {
            return color.R + "," + color.G + "," + color.B;
        }

        #region [颜色：16进制转成RGB]
        /// <summary>
        /// [颜色：16进制转成RGB]
        /// </summary>
        /// <param name="strColor">设置16进制颜色 [返回RGB]</param>
        /// <returns></returns>
        public static Color colorHx16toRGB(string strHxColor, Color color)
        {
            try
            {
                if (CommonUtil.notBlank(strHxColor))
                {
                    //转换颜色
                    return Color.FromArgb(
                                    Int32.Parse(strHxColor.Substring(1, 2), NumberStyles.AllowHexSpecifier),
                                    Int32.Parse(strHxColor.Substring(3, 2), NumberStyles.AllowHexSpecifier),
                                    Int32.Parse(strHxColor.Substring(5, 2), NumberStyles.AllowHexSpecifier)
                                    );
                }
            }
            catch (Exception e)
            {
                CommonUtil.saveLog("转换颜色异常：" + e.Message);
            }
            return color;
        }
        #endregion

        #region [颜色：RGB转成16进制]
        /// <summary>
        /// [颜色：RGB转成16进制]
        /// </summary>
        /// <param name="R">红 int</param>
        /// <param name="G">绿 int</param>
        /// <param name="B">蓝 int</param>
        /// <returns></returns>
        public static string colorRGBtoHx16(Color color)
        {
            if (color.IsEmpty)
                return "#000000";
            return ColorTranslator.ToHtml(color);
        }


        #endregion

        #region
        /// <summary>
        /// [颜色：RGB转成16进制]
        /// </summary>
        /// <param name="color">颜色</param>
        /// <returns>十六进制值，如果参数为空，默认返回#000000</returns>
        public static string ToHexColor(Color color)
        {
            if (color.IsEmpty)
                return "#000000";
            string R = Convert.ToString(color.R, 16);
            if (R == "0")
                R = "00";
            string G = Convert.ToString(color.G, 16);
            if (G == "0")
                G = "00";
            string B = Convert.ToString(color.B, 16);
            if (B == "0")
                B = "00";
            string HexColor = "#" + R + G + B;
            return HexColor.ToUpper();
        }
        #endregion

    }
}
