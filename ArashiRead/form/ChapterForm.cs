using ArashiRead.cache;
using ArashiRead.config;
using ArashiRead.model;
using ArashiRead.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class ChapterForm : ParentForm
    {
        MainForm mainForm;

        public ChapterForm(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            RedrawFormControls(this, ConfigCache.currentColors);
            RedrawControlCMS(chapterMenu);
            this.filterBox.Location = new Point(this.filterBox.Location.X, 0);
            this.filterBox.BorderWidth = 0;
        }

        public static Boolean filterChecked = true;   //是否开启过滤功能


        private void ChapterForm_Shown(object sender, EventArgs e)
        {
            Book b = ReadCache.book;
            if (b != null && b.chapters.Count > 0)
            {
                catalogDgv.DataSource = new BindingList<Chapter>(b.chapters);
                //选中指定单元格（滚动条自动跳转）
                this.catalogDgv.CurrentCell = this.catalogDgv.Rows[b.lastReadChapteNo].Cells[0];
            }
        }

        /// <summary>
        /// 双击跳转指定章节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catalogDgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                read();
            }

        }

        /// <summary>
        /// 开始阅读
        /// </summary>
        private void read()
        {
            if (catalogDgv.CurrentRow == null)
            {
                showError("未选中章节");
                return;
            }
            int index = catalogDgv.CurrentRow.Index;
            int chapterNo = (int)catalogDgv.Rows[index].Cells[0].Value;
            mainForm.showContent(null, chapterNo, 0);
            this.Close();
        }


        private void input1_SuffixClick(object sender, MouseEventArgs e)
        {
            filter();
        }


        /// <summary>
        /// 根据输入的关键字筛选目录 
        /// </summary>
        public void filter()
        {
            if (ReadCache.book == null)
            {
                showError("没有正在阅读的书籍");
                return;
            }
            List<Chapter> chapters = ReadCache.book.chapters;
            String filterStr = filterBox.Text;
            if (CommonUtil.notBlank(filterStr) && chapters != null)
            {
                List<Chapter> filterList = new List<Chapter>();
                foreach (Chapter c in chapters)
                {
                    if (CommonUtil.notBlank(c.ChapterName) && c.ChapterName.Contains(filterStr))
                    {
                        filterList.Add(c);
                    }
                }
                catalogDgv.DataSource = new BindingList<Chapter>(filterList);
                return;
            }
            catalogDgv.DataSource = new BindingList<Chapter>(chapters);
        }

        private void catalogDgv_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void filterBox_Enter(object sender, EventArgs e)
        {
            if (filterBox.Text.Equals("请输入章节名"))
            {
                filterBox.Text = "";
            }
        }

        private void filterBox_Leave(object sender, EventArgs e)
        {
            if (filterBox.Text.Equals(""))
            {
                filterBox.Text = "请输入章节名";
            }
        }

        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            if (CommonUtil.notBlank(filterBox.Text) && !filterBox.Text.Equals("请输入章节名"))
            {
                filter();
            }
        }

        private void 阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            read();
        }
    }
}
