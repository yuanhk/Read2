using AntdUI;
using System;
using System.Windows.Forms;

namespace WindRead.util
{

    /// <summary>
    /// 针对form的工具类
    /// </summary>
    public static class FormUtil
    {
       

        /// <summary>
        /// 获取蒙版窗体
        /// </summary>
        /// <returns></returns>
        public static Form getMaskForm(this Form form)
        {
            //当前打开的窗体
            foreach (Form openForm in form.OwnedForms)
            {
                //蒙版窗体
                if ("LayeredFormMask".Equals(openForm.GetType().Name))
                {
                    return openForm;
                }
            };
            return null;
        }

        /// <summary>
        /// 获取抽屉窗体
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static Form getDrawerForm(this Form form)
        {
            Form maskForm = getMaskForm(form);
            if (maskForm != null && maskForm.OwnedForms.Length > 0)
            {
                return maskForm.OwnedForms[0];
            }
            return null;
        }

        /// <summary>
        /// 关闭蒙版窗口
        /// </summary>
        public static void closeDrawerForm(this Form form)
        {
            Form maskForm = getMaskForm(form);
            if (maskForm != null)
            {
                foreach (Form item in maskForm.OwnedForms)
                {
                    item.Close();
                }
                maskForm.Dispose();
                maskForm.Close();
            }
        }



        /// <summary>
        /// 显示提示
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        private static void showMsg(this Form form, String msg, TType type)
        {
            Form f = getDrawerForm(form);
            if (f == null)
            {
                f = form;
            }
            if (f != null)
            {
                AntdUI.Message.Config config = new AntdUI.Message.Config(f, msg, type);
                config.AutoClose = 2;
                config.open();
            }
        }

        /// <summary>
        /// 显示详情提示
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        public static void showInfo(this Form form, String msg)
        {
            showMsg(form, msg, TType.Info);
        }

        /// <summary>
        /// 显示成功提示
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        public static void showSuccess(this Form form, String msg)
        {
            showMsg(form, msg, TType.Success);
        }

        /// <summary>
        /// 显示错误提示
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        public static void showError(this Form form, String msg)
        {
            showMsg(form, msg, TType.Error);
        }
    }




}
