using ArashiRead.cache;
using ArashiRead.config;
using ArashiRead.model;
using ArashiRead.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class MarkForm : ParentForm
    {
        MainForm mainForm;

        public MarkForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            RedrawFormControls(this, ConfigCache.currentColors);
            RedrawControlCMS(markMenu);
        }

        /// <summary>
        /// 窗体渲染完成后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkForm_Shown(object sender, EventArgs e)
        {
            ConfigCache.markers = ConfigCache.markers.OrderByDescending(x => x.lastReadTime).ToList();
            markDgv.DataSource = new BindingList<Book>(ConfigCache.markers);

        }

        private void 继续阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (markDgv.SelectedRows.Count == 0)
            {
                showError("未选中书签");
                return;
            }
            DataGridViewRow row = markDgv.SelectedRows[0];
            String url = row.Cells[7].Value.ToString();
            int rowNo = (int)row.Cells[5].Value;
            int chapterNo = (int)row.Cells[0].Value;
            int realLineNo = (int)row.Cells[6].Value;
            int totalRowCount = (int)row.Cells[8].Value;
            //继续阅读
            if (ReadCache.book != null && ReadCache.book.url.Equals(url))
            {
                ReadCache.book.totalRowCount = ReadCache.rows.Count;
                //判断总条数是否一致
                if (ReadCache.rows.Count == totalRowCount)
                {
                    ReadCache.book.rowNo = rowNo;
                    mainForm.showContent(0, null, null);
                }
                else
                {
                    mainForm.showContent(null, chapterNo, realLineNo);
                }
            }
            else
            {
                //打开书籍
                if (!CommonUtil.isExist(url))
                {
                    showError("该书籍已移动或已删除，无法打开");
                    return;
                }
                if (CommonUtil.FileIsBlank(url))
                {
                    showError("该书籍为空");
                    return;
                }
                mainForm.ansycOpenBook(url, rowNo, chapterNo, realLineNo);
            }
            this.Close();
        }

        private void 移除书签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (markDgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in markDgv.SelectedRows)
                {
                    markDgv.Rows.Remove(row);

                }
                List<Book> list = new List<Book>((BindingList<Book>)this.markDgv.DataSource);
                list = list.OrderByDescending(x => x.lastReadTime).ToList();
                ConfigCache.markers = list;
            }
            else
            {
                showError("未选中书签");
            }
        }

        /// <summary>
        /// 清除失效书签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        private void menu1_SelectChanged(object sender, AntdUI.MenuItem item)
        {
            List<Book> list = ConfigCache.markers;
            int j = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (!CommonUtil.isExist(list[i].url))
                {
                    j++;
                    list.RemoveAt(i);
                }
            }
            markDgv.DataSource = new BindingList<Book>(list);
            showSuccess("已清除失效书签" + j + "个");
        }


        private void markDgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                继续阅读ToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
