using ArashiRead.bean;
using ArashiRead.cache;
using ArashiRead.config;
using ArashiRead.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class FullTextSreachForm : ParentForm
    {
        MainForm mainForm;

        public FullTextSreachForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            RedrawFormControls(this, ConfigCache.currentColors);
            RedrawControlCMS(FullTextSreachMenu);
            this.sreachBox.Location = new Point(this.sreachBox.Location.X, 0);
            this.sreachBox.BorderWidth = 0;
        }

        private void FullTextSreachForm_Shown(object sender, EventArgs e)
        {
            if (CommonUtil.notBlank(ReadCache.sreachTerm))
            {
                sreachBox.Text = ReadCache.sreachTerm;
            }
            if (ReadCache.searchResults.Count > 0)
            {
                fullSearchDgv.DataSource = new BindingList<ContentRow>(ReadCache.searchResults);
                sreachBox.SuffixText = "查询结果 : " + ReadCache.searchResults.Count;
                if (ReadCache.lastSelectIndex >= 0 && ReadCache.lastSelectIndex < ReadCache.searchResults.Count)
                {
                    this.fullSearchDgv.CurrentCell = this.fullSearchDgv.Rows[ReadCache.lastSelectIndex].Cells[1];
                }
            }

        }

        private void sreachBox_Enter(object sender, EventArgs e)
        {
            if (sreachBox.Text.Equals("请输入搜索文本"))
            {
                sreachBox.Text = "";
            }
        }

        private void sreachBox_Leave(object sender, EventArgs e)
        {
            if (sreachBox.Text.Equals(""))
            {
                sreachBox.Text = "请输入搜索文本";
            }
            else if (!sreachBox.Text.Equals("请输入搜索文本") && !sreachBox.Text.Equals(ReadCache.sreachTerm))
            {
                ReadCache.sreachTerm = sreachBox.Text;
                sreach();
            }
        }

        private void sreachBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && CommonUtil.notBlank(sreachBox.Text)
                && !sreachBox.Text.Equals("请输入搜索文本")
                )
            {
                ReadCache.sreachTerm = sreachBox.Text;
                sreach();
            }
        }

        /// <summary>
        /// 全文查找
        /// </summary>
        public void sreach()
        {
            List<ContentRow> rows = ReadCache.rows;
            if (rows.Count == 0)
            {
                showError("没有正在阅读的书籍");
                return;
            }
            ReadCache.searchResults.Clear();
            String str = ReadCache.sreachTerm;
            List<ContentRow> find = rows.FindAll(x => x.row.Contains(str)).ToList();
            if (find.Count == 0)
            {
                showInfo("指定文本全文未找到");
                sreachBox.SuffixText = "查询结果 : 0";
            }
            else
            {
                showSuccess("全文查找成功，共找到" + find.Count + "条结果");
                sreachBox.SuffixText = "查询结果 : " + find.Count;
                ReadCache.searchResults = find;
            }
            fullSearchDgv.DataSource = new BindingList<ContentRow>(ReadCache.searchResults);
        }

        private void 阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fullSearchDgv.CurrentRow == null)
            {
                showError("未选中结果行");
                return;
            }
            int index = fullSearchDgv.CurrentRow.Index;
            if (index >= 0)
            {
                ReadCache.lastSelectIndex = index;
                int rowNo = (int)fullSearchDgv.Rows[index].Cells[3].Value;
                ReadCache.book.rowNo = rowNo;
                mainForm.showContent(0, null, null);
                mainForm.highlight(ReadCache.sreachTerm);
                this.Close();
            }
            else
            {
                showError("未选中查询结果");
            }
        }

        private void fullSearchDgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            阅读ToolStripMenuItem_Click(sender, e);
        }
    }
}
