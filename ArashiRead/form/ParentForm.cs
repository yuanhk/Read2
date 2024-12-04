using AntdUI;
using ArashiRead.bean;
using ArashiRead.config;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class ParentForm : AntdUI.Window
    {
        public ParentForm()
        {
            //取消线程间调用的错误捕获
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            loadingPanel.BorderWidth = 0;
        }

        System.Timers.Timer messageTimer;

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 重绘右键菜单
        /// </summary>
        /// <param name="cms"></param>
        public void RedrawControlCMS(System.Windows.Forms.ContextMenuStrip cms)
        {
            cms.RenderMode = ToolStripRenderMode.Professional;
            cms.Renderer = new ToolStripProfessionalRenderer(new MqxsColorTable());

            foreach (ToolStripMenuItem item in cms.Items)
            {
                item.BackColor = ConfigCache.currentColors.backColor;
                item.ForeColor = ConfigCache.currentColors.foreColor;
            }
        }

        /// <summary>
        /// 重绘右键菜单颜色
        /// </summary>
        public class MqxsColorTable : ProfessionalColorTable
        {

            public override Color MenuBorder
            {
                get { return ConfigCache.currentColors.otherColor; }
            }

            public override Color MenuItemBorder
            {
                get { return ConfigCache.currentColors.otherColor; }
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
                get { return ConfigCache.currentColors.backColor; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return ConfigCache.currentColors.backColor; }
            }
        }

        /// <summary>
        /// 控件重绘
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="colors"></param>
        public void RedrawControl(Control control, Colors colors)
        {
            //颜色为空或加载中控件不进行重绘
            if (colors == null || (control.Tag != null && control.Tag.ToString().Contains("loading")))
            {
                return;
            }
            Color backColor = colors.backColor, foreColor = colors.foreColor,
               msgColor = colors.promptColor, otherColor = colors.otherColor,
               selectionColor = colors.selectionColor;

            //此处设置对antdUi不一定生效,大概是它的控件重写了颜色的字段
            //控件前景色
            control.ForeColor = foreColor;
            //控件背景色
            if (control is TextBoxBase || control is DataGridView || control is System.Windows.Forms.ScrollBar)
            {
                control.BackColor = backColor;
            }
            else
            {
                control.BackColor = Color.Transparent;
            }

            //包含子控件
            if (control.Controls.Count > 0)
            {
                RedrawControls(control.Controls, colors);
            }
            //富文本框
            if (control is RichTextBox)
            {
                RichTextBox box = (RichTextBox)control;
                box.BackColor = backColor;
                box.Font = new Font(ConfigCache.display.fontFamily, ConfigCache.display.fontSize, box.Font.Style);

            }
            //系统面板
            else if (control is System.Windows.Forms.Panel)
            {
                System.Windows.Forms.Panel p = (System.Windows.Forms.Panel)control;
                //判断是否为分割线
                if (p.Width == 1)
                {
                    p.BackColor = otherColor;
                }
                else if (p.Height == 1)
                {
                    p.BackColor = foreColor;
                }
            }
            //表格
            else if (control is DataGridView)
            {
                DataGridView dgv = control as DataGridView;
                dgv.BackgroundColor = backColor;
                dgv.RowHeadersVisible = false;
                dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
                dgv.AutoGenerateColumns = false;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
                dgv.DefaultCellStyle.BackColor = backColor;
                dgv.DefaultCellStyle.ForeColor = foreColor;
                dgv.BorderStyle = BorderStyle.None;
            }
            //菜单栏
            else if (control is AntdUI.Menu)
            {
                AntdUI.Menu m = control as AntdUI.Menu;
                m.ForeActive = msgColor;
                m.ForeColor = foreColor;
            }
            //进度条
            else if (control is Progress)
            {
                Progress p = control as Progress;
                if (p.Shape.Equals(TShape.Round))
                {
                    p.BackColor = foreColor;
                }
                p.Fill = msgColor;
            }
            //输入框
            else if (control is Input)
            {
                Input i = control as Input;
                i.BorderWidth = 1;
                i.Radius = 2;
                i.BorderColor = foreColor;
                i.BorderActive = foreColor;
                i.BorderHover = foreColor;
                i.SelectionColor = selectionColor;
                i.BackColor = backColor;
                i.ForeColor = foreColor;
            }
            //下拉选择框
            else if (control is Select)
            {
                Select i = control as Select;
                i.BorderWidth = 1;
                i.Radius = 2;
                i.BorderColor = foreColor;
                i.BorderActive = foreColor;
                i.BorderHover = foreColor;
                i.SelectionColor = selectionColor;
                i.BackColor = backColor;
                i.ForeColor = foreColor;
            }
            //标签
            else if (control is Tag)
            {
                Tag i = control as Tag;
                i.BorderWidth = 0;
                i.BackColor = backColor;
                i.ForeColor = foreColor;
            }
            //按钮
            else if (control is AntdUI.Button)
            {
                AntdUI.Button i = control as AntdUI.Button;
                i.DefaultBack = backColor;
                i.BorderWidth = 1;
                i.Padding = new Padding(0);
                i.Margin = new Padding(0);
                i.BackActive = backColor;
                i.ForeColor = foreColor;
                i.DefaultBorderColor = foreColor;
            }
            //选项卡
            else if (control is Tabs)
            {
                Tabs t = control as Tabs;
                t.Fill = foreColor;
                t.FillHover = msgColor;

                if (t.TabPages.Count > 0)
                {
                    foreach (TabPage item in t.TabPages)
                    {
                        RedrawControls(item.Controls, colors);
                    }
                }
            }
            //拖动滑块
            else if (control is Slider)
            {
                Slider s = control as Slider;
                s.Fill = foreColor;
                s.FillHover = msgColor;
                s.FillActive = msgColor;
            }
            //开关按钮
            else if (control is Switch)
            {
                Switch s = control as Switch;
                s.Fill = foreColor;
                s.FillHover = msgColor;
            }
            //标签
            else if (control is AntdUI.Label)
            {
                AntdUI.Label s = control as AntdUI.Label;
                s.BackColor = backColor;
                s.ForeColor = foreColor;
            }


        }

        /// <summary>
        /// 控件集合重绘
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="colors"></param>
        public void RedrawControls(Control.ControlCollection controls, Colors colors)
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
        /// 窗体下所有控件重绘
        /// </summary>
        /// <param name="form"></param>
        public void RedrawFormControls(Form form, Colors colors)
        {
            if (colors == null)
            {
                return;
            }
            //窗体颜色设置
            form.BackColor = colors.backColor;
            form.ForeColor = colors.foreColor;

            partitionTop.BackColor = colors.foreColor;
            windowBar1.ForeColor = colors.foreColor;
            RedrawControls(form.Controls, colors);
        }



        public void showInfo(String str)
        {
            showMessage(str, TType.Info);
        }

        public void showSuccess(String str)
        {
            showMessage(str, TType.Success);
        }

        public void showError(String str)
        {
            showMessage(str, TType.Error);
        }

        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="str"></param>
        public void showMessage(String str, TType type)
        {
            //计算宽度
            double width = (str.Length + 5) * (tips.Font.Size + 1.5);
            if (width > this.Width * 0.618)
            {
                width = this.Width * 0.618;
            }

            //计算展示位置
            tips.Width = (int)width;
            int x = (int)(this.Width - width) / 2;
            tips.Location = new System.Drawing.Point(x, 15);
            tips.Icon = type;
            tips.Text = str;
            tips.BringToFront();
            tips.Show();
            if (messageTimer != null) messageTimer.Dispose();//重新通知时销毁之前的通知任务
            messageTimer = new System.Timers.Timer(1500);
            messageTimer.Elapsed += new System.Timers.ElapsedEventHandler(cleanMessage);//到达时间的时候执行事件；
            messageTimer.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            messageTimer.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }

        /// <summary>
        /// 清除消息通知
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void cleanMessage(object source, System.Timers.ElapsedEventArgs e)
        {
            tips.Text = "";
            tips.Hide();
        }




        /// <summary>
        /// 异步执行并打开加载页
        /// </summary>
        /// <param name="sleep"></param>
        /// <param name="workFunc"></param>
        public void asyncWork(Action workFunc)
        {
            loadingProgress.Fill = ConfigCache.currentColors.promptColor;
            loadingProgress.ForeColor = ConfigCache.currentColors.promptColor;
            loadingPanel.Visible = true;
            loadingPanel.Dock = DockStyle.Fill;
            loadingPanel.BringToFront();
            //control.Visible = false;
            Task.Factory.StartNew(() =>
            {
                // Thread.Sleep(sleepTime);
                this.Invoke((EventHandler)delegate
                {
                    workFunc();
                    //control.Visible = true;
                });
                loadingPanel.Visible = false;
            });
        }

        private void ParentForm_Shown(object sender, EventArgs e)
        {
            //解决窗体打开时闪烁问题
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

       

        //<summary>
        //解决窗体打开时闪烁问题
        //</summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
                return;
            base.WndProc(ref m);
        }


        //[DllImport("user32", EntryPoint = "HideCaret")]
        ////禁止焦点
        //public static extern bool HideCaret(IntPtr hWnd);
    }
}
