using System;

namespace ArashiRead.config
{
    /// <summary>
    /// 颜色配置
    /// </summary>
    public class ColorConfig
    {
        /// <summary>
        /// 名称
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// 下标
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public String backColor { get; set; }

        /// <summary>
        /// 前景色
        /// </summary>
        public String foreColor { get; set; }
        /// <summary>
        /// 消息颜色
        /// </summary>
        public String promptColor { get; set; }
        /// <summary>
        /// 选中颜色
        /// </summary>
        public String selectionColor { get; set; }
        /// <summary>
        /// 其他颜色
        /// </summary>
        public String otherColor { get; set; }

        /// <summary>
        /// 显示配置转颜色配置
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        public static ColorConfig toColorConfig(DisplayConfig display)
        {
            ColorConfig colorConfig = new ColorConfig();
            colorConfig.backColor = display.backColor;
            colorConfig.foreColor = display.foreColor;
            colorConfig.selectionColor = display.selectionColor;
            colorConfig.otherColor = display.otherColor;
            colorConfig.promptColor = display.promptColor;
            return colorConfig; ;
        }
    }
}
