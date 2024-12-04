using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class RichTextBoxEx : RichTextBox
    {
        private const int WM_SETFOCUS = 0x7;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        public bool bReadOnly = true;

        protected override void WndProc(ref Message m)
        {
            
           if (bReadOnly)
           {
             if (m.Msg == WM_SETFOCUS || m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP || m.Msg == WM_LBUTTONDOWN || m.Msg == WM_LBUTTONUP || m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_RBUTTONDBLCLK)
             {
                 return;
             }
           }
            base.WndProc(ref m);
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

      
        public void SetReadMode()
        {
            ReadOnly = true;
            bReadOnly = true;
        }

        public void SetEditMode()
        {
            ReadOnly = false;
            bReadOnly = false;
            Focus();
        }

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (bReadOnly)
        //        HideCaret(Handle);
        //}
    }
}
