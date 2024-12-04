using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.cache;

namespace WindRead.form
{
    public partial class ParentForm : AntdUI.BorderlessForm
    {
        public ParentForm()
        {
            InitializeComponent();

            loadingPanel.BorderWidth = 0;
            loadingPanel.BackColor = ConfigCache.theme.BackColor;
            loadingPanel.Width = this.Width;
            loadingPanel.Height = this.Height;
            loadingProgress.Back = Color.Transparent;
            loadingProgress.BackColor = Color.Transparent;
            loadingProgress.Fill = ConfigCache.theme.CheckedColor;
            loadingProgress.ForeColor = ConfigCache.theme.CheckedColor;
        }

        private void parentForm_Shown(object sender, EventArgs e)
        {
            // 解决窗体打开时闪烁问题
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        /// <summary>
        /// 异步执行并打开加载页
        /// </summary>
        /// <param name="sleep"></param>
        /// <param name="workFunc"></param>
        public void asyncWork(Action workFunc)
        {

            loadingPanel.Visible = true;
            //loadingPanel.Dock = DockStyle.Fill;
            loadingPanel.BringToFront();
            Task.Factory.StartNew(() =>
            {
                this.Invoke((EventHandler)delegate
                {
                    workFunc();
                });
                loadingPanel.Visible = false;
            });
        }


        public void hideLoading() {
            foreach (Control item in Controls)
            {
                item.Visible = !item.Name.Contains("loading");
            }
        }

        public void showLoading() {
            foreach (Control item in Controls)
            {
                item.Visible =item.Name.Contains("loading");
            }
        }


       //<summary>
       //解决窗体打开时闪烁问题
       //</summary>
       protected override CreateParams CreateParams
       {
           get
           {
               const int CS_NOCLOSE = 0x200;
               CreateParams cp = base.CreateParams;
               cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
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


        [DllImport("user32", EntryPoint = "HideCaret")]
        //禁止焦点
        public static extern bool HideCaret(IntPtr hWnd);

    }
}

