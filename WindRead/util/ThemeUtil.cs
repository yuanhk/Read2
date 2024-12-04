using AntdUI;
using AntdUI.Theme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.bean;
using WindRead.cache;
using WindRead.Resources;

namespace WindRead.util
{
    public static class ThemeUtil
    {

       


        /// <summary>
        /// 设备数据函数
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public static void getIntPtr() {
            var g = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
            
        }

        public static float getXMultiple() {
            IntPtr desktop = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
            var physicalScreenWidth = GetDeviceCaps(desktop, 118);//硬件显示器分辨率实际设置的宽
            return physicalScreenWidth / 1366F;
        }

        public static float getYMultiple()
        {
            IntPtr desktop = Graphics.FromHwnd(IntPtr.Zero).GetHdc();
            var physicalScreenWidth = GetDeviceCaps(desktop, 117);//硬件显示器分辨率实际设置的宽
            return physicalScreenWidth / 768F;
        }

        public static void AutoSize() {
            MessageBox.Show(getXMultiple() + "");
            MessageBox.Show(getYMultiple() + "");
        }

        /// <summary>
        /// AntdUI初始化
        /// </summary>
        public static void AntdUIInit(ThemeInfo colors) {
            //关闭动画
          //  AntdUI.Config.Animation = false;
            //窗口内弹出提示框
            AntdUI.Config.ShowInWindow = true;
            //文本呈现的质量
            AntdUI.Config.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            //默认字体
            AntdUI.Config.Font = new Font("Microsoft YaHei UI Light", 10);
            //获取DPI 1 = 100 %、1.25 = 125 %，以此类推
          
            //主题
            IColor<Color> color = new AntdUI.Theme.Light();
            color.Primary = colors.BackColor;
            color.PrimaryColor = colors.ForeColor;
            color.PrimaryBg = colors.BackColor;
            color.PrimaryActive = colors.HoverColor;
            color.PrimaryHover = colors.HoverColor;

            //字体颜色
            color.TextBase = colors.ForeColor;
            color.Text = colors.ForeColor;
            color.TextSecondary = colors.ForeColor;
            color.TextTertiary = colors.ForeColor;
            color.TextQuaternary = colors.ForeColor;

            //背景色
            color.BgBase = colors.BackColor;
            color.BgContainer = colors.BackColor;
            color.BgElevated = colors.HoverColor;
            color.BgLayout = colors.BackColor;


            //悬浮色
            color.HoverBg = colors.HoverColor;
            color.HoverColor = colors.HoverColor;
            color.Fill = colors.HoverColor;
            color.FillSecondary = colors.HoverColor;

            //边框色
            color.BorderColor = colors.BorderColor;
            color.DefaultBorder = colors.BorderColor;


            AntdUI.Style.LoadCustom(color);
        }


        /// <summary>
        /// 窗体下所有控件重绘
        /// </summary>
        /// <param name="form"></param>
        public static void RedrawFormControls(this Form form, ThemeInfo colors)
        {
            if (colors == null)
            {
                return;
            }
            //窗体颜色设置
            form.BackColor = colors.BackColor;
            form.ForeColor = colors.ForeColor;
            RedrawControls(form.Controls, colors);
        }


        /// <summary>
        /// 重绘控件集合
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="colors"></param>
        public static void RedrawControls(Control.ControlCollection controls, ThemeInfo colors)
        {
            if (colors != null && controls.Count > 0)
            {
                //遍历所有控件设置颜色
                foreach (Control control in controls)
                {
                    RedrawControl(control, colors);
                }
            }
        }


        /// <summary>
        /// 重绘控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="colors"></param>

        public static void RedrawControl(this Control control, ThemeInfo colors) {
            //颜色为空或加载中控件不进行重绘
            if (colors == null || (control.Tag != null && control.Tag.ToString().Contains("loading")))
            {
                return;
            }
            //包含子控件
            if (control.Controls.Count > 0)
            {
                RedrawControls(control.Controls, colors);
            }
            //此处设置对antdUi不一定生效,大概是它的控件重写了颜色的字段
            //控件前景色
            control.ForeColor = colors.ForeColor;
            //控件背景色
            if (control is TextBoxBase || control is DataGridView || control is System.Windows.Forms.ScrollBar)
            {
                control.BackColor = colors.BackColor;
            }
            else
            {
                control.BackColor = Color.Transparent;
            }
            //拖动滑块
            if (control is Slider)
            {
                Slider s = control as Slider;
                s.Fill = colors.BorderColor;
                s.FillHover = colors.CheckedColor;
                s.FillActive = colors.CheckedColor;
            } else if (control is Divider) {
                Divider d = control as Divider;
                d.ColorSplit = colors.BorderColor;
            } //按钮
            else if (control is AntdUI.Button)
            {
                AntdUI.Button i = control as AntdUI.Button;
                i.DefaultBack = colors.BackColor;
                // i.BorderWidth = 0;
                i.Padding = new Padding(0);
                i.Margin = new Padding(0);
                i.BackActive = colors.BackColor;
                i.ForeColor = colors.ForeColor;
                i.DefaultBorderColor = colors.ForeColor;

            }
            else if (control is TabControl) {
                TabControl tab = control as TabControl;
                foreach (TabPage item in tab.TabPages)
                {
                    item.BackColor = colors.BackColor;
                    item.ForeColor = colors.ForeColor;
                }
            } else if (control is Select) {
                Select select = control as Select;
                select.BorderActive = colors.BorderColor;
            }
            //标签
            else if (control is AntdUI.Label)
            {
                AntdUI.Label s = control as AntdUI.Label;
                s.ForeColor = colors.ForeColor;
            }
            //表格
            else if (control is DataGridView)
            {
                DataGridView dgv = control as DataGridView;
                dgv.BackgroundColor = colors.BackColor;
                dgv.RowHeadersVisible = false;
                dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
                dgv.AutoGenerateColumns = false;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dgv.DefaultCellStyle.BackColor = colors.BackColor;
                dgv.DefaultCellStyle.ForeColor = colors.ForeColor;
                dgv.BorderStyle = BorderStyle.None;
            }

        }


        /// <summary>
        /// 重绘右键菜单
        /// </summary>
        /// <param name="cms"></param>
        public static void RedrawControlCMS( this System.Windows.Forms.ContextMenuStrip cms)
        {
            cms.RenderMode = ToolStripRenderMode.Professional;
            cms.Renderer = new ToolStripProfessionalRenderer(new MqxsColorTable());

            foreach (ToolStripMenuItem item in cms.Items)
            {
                item.BackColor = ConfigCache.theme.BackColor;
                item.ForeColor = ConfigCache.theme.ForeColor;
            }
        }

        /// <summary>
        /// 重绘右键菜单颜色
        /// </summary>
        public class MqxsColorTable : ProfessionalColorTable
        {

            public override Color MenuBorder
            {
                get { return ConfigCache.theme.BorderColor; }
            }

            public override Color MenuItemBorder
            {
                get { return ConfigCache.theme.BorderColor; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return Color.Transparent; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return Color.Transparent; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return Color.Transparent; }
            }
            public override System.Drawing.Color MenuItemSelected
            {
                get { return ConfigCache.theme.BackColor; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return ConfigCache.theme.BackColor; }
            }
        }

    }
}
