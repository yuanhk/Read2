using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindRead.bean
{
    public class ThemeConf
    {

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 下标
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public String BackColor { get; set; }

        /// <summary>
        /// 前景色
        /// </summary>
        public String ForeColor { get; set; }
        /// <summary>
        /// 悬浮颜色
        /// </summary>
        public String HoverColor { get; set; }
        /// <summary>
        /// 选中颜色
        /// </summary>
        public String CheckedColor { get; set; }
        /// <summary>
        /// 边框颜色
        /// </summary>
        public String BorderColor { get; set; }

        /// <summary>
        /// 显示配置转颜色配置
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        public  ThemeInfo toThemeInfo()
        {
            ThemeInfo info = new ThemeInfo();
            info.Name = Name;
            info.Index = Index;
            info.BackColor= AntdUI.Style.ToColor(BackColor);
            info.ForeColor = AntdUI.Style.ToColor(ForeColor);
            info.HoverColor = AntdUI.Style.ToColor(HoverColor);
            info.CheckedColor = AntdUI.Style.ToColor(CheckedColor);
            info.BorderColor = AntdUI.Style.ToColor(BorderColor);
            return info; 
        }
    }

}

