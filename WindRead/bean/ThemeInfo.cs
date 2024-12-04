using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindRead.bean
{
    public class ThemeInfo
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
        /// 字体颜色
        /// </summary>
        public Color ForeColor { get; set; }

        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackColor { get; set; } 

        /// <summary>
        /// 悬浮色
        /// </summary>
        public Color HoverColor { get; set; }

        /// <summary>
        /// 边框色
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// 选中色
        /// </summary>
        public Color CheckedColor { get; set; } 


        /// <summary>
        /// 显示配置转颜色配置
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        public ThemeConf toThemeConf()
        {
            ThemeConf conf = new ThemeConf();
            conf.Name = Name;
            conf.Index = Index;
            conf.BackColor = AntdUI.Style.ToHex(BackColor);
            conf.ForeColor = AntdUI.Style.ToHex(ForeColor);
            conf.HoverColor = AntdUI.Style.ToHex(HoverColor);
            conf.CheckedColor = AntdUI.Style.ToHex(CheckedColor);
            conf.BorderColor = AntdUI.Style.ToHex(BorderColor);
            return conf;
        }
    }
}
