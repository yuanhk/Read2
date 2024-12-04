using ArashiRead.constant;
using System;

namespace ArashiRead.config
{
    /// <summary>
    /// 显示配置
    /// </summary>
    public class DisplayConfig
    {
        //书籍文件夹地址
        public String bookFolderPath { get; set; }
        /// <summary>
        /// 扫描章节规则 0:宽松 1：严格单章节 2：严格双章节
        /// </summary>
        public Int32 chapterScanRule { get; set; }

        /// <summary>
        /// 章节关键字
        /// </summary>
        public String chapterKey { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public float fontSize { get; set; }

        /// <summary>
        /// 字体是否加粗
        /// </summary>
        public bool fontBold { get; set; }

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
        /// 字体样式
        /// </summary>
        public String fontFamily { get; set; }

        /// <summary>
        /// 自动隐藏
        /// </summary>
        public Boolean autoHide { get; set; }

        /// <summary>
        /// 主窗口宽度
        /// </summary>
        public int mainFormWeight { get; set; }

        /// <summary>
        /// 主窗口高度
        /// </summary>
        public int mainFormHeight { get; set; }

        /// <summary>
        /// 设置尺寸
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void setSize(int w, int h)
        {
            if (w >= Constants.MainFormWidthMin && h >= Constants.MainFormHeightMin)
            {
                mainFormWeight = w; mainFormHeight = h;
            }
        }
    }
}
