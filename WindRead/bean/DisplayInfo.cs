using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindRead.constants;

namespace WindRead.bean
{
    /// <summary>
    /// 显示配置
    /// </summary>
    public class DisplayInfo
    {

        //书籍文件夹地址
        public String BookFolderPath { get; set; }
        /// <summary>
        /// 扫描章节规则 0:宽松 1：严格单章节 2：严格双章节
        /// </summary>
        public int ChapterScanRule { get; set; } = 1;

        /// <summary>
        /// 章节关键字
        /// </summary>
        public String ChapterKey { get; set; } = "章";

        /// <summary>
        /// 字体大小
        /// </summary>
        public float FontSize { get; set; } = 10.5f;

        /// <summary>
        /// 字体是否加粗
        /// </summary>
        public bool FontBold { get; set; } = false;

        /// <summary>
        /// 字体样式
        /// </summary>
        public String FontFamily { get; set; } = "Microsoft YaHei UI Light";

        /// <summary>
        /// 自动隐藏
        /// </summary>
        public Boolean AutoHide { get; set; } = false;

        /// <summary>
        /// 主窗口宽度
        /// </summary>
        public int Weight { get; set; } = Constants.MainFormWidthMin;

        /// <summary>
        /// 主窗口高度
        /// </summary>
        public int Height { get; set; } = Constants.MainFormWidthMin;


    }
}
