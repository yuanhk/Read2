using ArashiRead.config;
using ArashiRead.util;
using System.Drawing;

namespace ArashiRead.bean
{
    /// <summary>
    /// 颜色
    /// </summary>
    public class Colors
    {

        /// <summary>
        /// 背景色
        /// </summary>
        public Color backColor { get; set; }

        /// <summary>
        /// 前景色
        /// </summary>
        public Color foreColor { get; set; }
        /// <summary>
        /// 消息颜色
        /// </summary>
        public Color promptColor { get; set; }
        /// <summary>
        /// 选中颜色
        /// </summary>
        public Color selectionColor { get; set; }
        /// <summary>
        /// 其他颜色
        /// </summary>
        public Color otherColor { get; set; }

        public static Colors toColors(ColorConfig config)
        {
            Colors colors = new Colors();
            colors.backColor = ColorUtil.toColor(config.backColor);
            colors.foreColor = ColorUtil.toColor(config.foreColor);
            colors.promptColor = ColorUtil.toColor(config.promptColor);
            colors.otherColor = ColorUtil.toColor(config.otherColor);
            colors.selectionColor = ColorUtil.toColor(config.selectionColor);
            return colors;
        }
    }
}
