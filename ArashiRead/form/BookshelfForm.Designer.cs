using System.Drawing;
using System.Windows.Forms;

namespace ArashiRead.form
{
    partial class BookshelfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tag1 = new AntdUI.Tag();
            this.menu1 = new AntdUI.Menu();
            this.table = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastReadChapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxPageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nowPageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastReadChapteNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chapterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制路径ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.取消全选ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.继续阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowBar1.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.chapterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.Controls.Add(this.menu1);
            this.windowBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.windowBar1.MinimumSize = new System.Drawing.Size(513, 26);
            this.windowBar1.Size = new System.Drawing.Size(648, 26);
            this.windowBar1.Text = " 书 架";
            // 
            // tag1
            // 
            this.tag1.BackColor = System.Drawing.Color.Transparent;
            this.tag1.BorderWidth = 0F;
            this.tag1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.tag1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.tag1.Location = new System.Drawing.Point(4, 6);
            this.tag1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tag1.Name = "tag1";
            this.tag1.Size = new System.Drawing.Size(75, 20);
            this.tag1.TabIndex = 4;
            this.tag1.Text = "书架";
            this.tag1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menu1
            // 
            this.menu1.BackActive = System.Drawing.Color.Transparent;
            this.menu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menu1.ForeActive = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.menu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            menuItem1.Text = "导入书籍";
            menuItem2.Text = "检索书籍";
            menuItem3.Text = "清理无效书籍";
            this.menu1.Items.AddRange(new AntdUI.MenuItem[] {
            menuItem1,
            menuItem2,
            menuItem3});
            this.menu1.Location = new System.Drawing.Point(313, 4);
            this.menu1.Mode = AntdUI.TMenuMode.Horizontal;
            this.menu1.Name = "menu1";
            this.menu1.Radius = 1;
            this.menu1.Size = new System.Drawing.Size(245, 20);
            this.menu1.TabIndex = 5;
            this.menu1.Text = "menu1";
            this.menu1.SelectChanged += new AntdUI.Menu.SelectEventHandler(this.menu1_SelectChanged);
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AllowUserToResizeColumns = false;
            this.table.AllowUserToResizeRows = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.ColumnHeadersVisible = false;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.lastReadChapter,
            this.time,
            this.percentStr,
            this.bSize,
            this.Percent,
            this.MaxPageNum,
            this.nowPageNum,
            this.Url,
            this.lastReadChapteNo});
            this.table.ContextMenuStrip = this.chapterMenu;
            this.table.Location = new System.Drawing.Point(12, 39);
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.table.RowTemplate.Height = 23;
            this.table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table.Size = new System.Drawing.Size(628, 354);
            this.table.TabIndex = 95;
            this.table.DoubleClick += new System.EventHandler(this.table_DoubleClick);
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.FillWeight = 4.5F;
            this.name.HeaderText = "书名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // lastReadChapter
            // 
            this.lastReadChapter.DataPropertyName = "lastReadChapter";
            dataGridViewCellStyle2.NullValue = "-";
            this.lastReadChapter.DefaultCellStyle = dataGridViewCellStyle2;
            this.lastReadChapter.FillWeight = 4F;
            this.lastReadChapter.HeaderText = "章节或预览";
            this.lastReadChapter.Name = "lastReadChapter";
            this.lastReadChapter.ReadOnly = true;
            // 
            // time
            // 
            this.time.DataPropertyName = "LastReadTime";
            this.time.FillWeight = 3F;
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // percentStr
            // 
            this.percentStr.DataPropertyName = "readRate";
            this.percentStr.FillWeight = 1.5F;
            this.percentStr.HeaderText = "阅读进度(显示)";
            this.percentStr.Name = "percentStr";
            this.percentStr.ReadOnly = true;
            // 
            // bSize
            // 
            this.bSize.DataPropertyName = "Size";
            this.bSize.FillWeight = 1.5F;
            this.bSize.HeaderText = "书籍大小";
            this.bSize.Name = "bSize";
            this.bSize.ReadOnly = true;
            // 
            // Percent
            // 
            this.Percent.DataPropertyName = "ReadPercent";
            this.Percent.FillWeight = 1F;
            this.Percent.HeaderText = "进度";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            this.Percent.Visible = false;
            // 
            // MaxPageNum
            // 
            this.MaxPageNum.DataPropertyName = "rowNo";
            this.MaxPageNum.FillWeight = 1F;
            this.MaxPageNum.HeaderText = "阅读行号";
            this.MaxPageNum.Name = "MaxPageNum";
            this.MaxPageNum.ReadOnly = true;
            this.MaxPageNum.Visible = false;
            // 
            // nowPageNum
            // 
            this.nowPageNum.DataPropertyName = "realLineNo";
            this.nowPageNum.FillWeight = 1F;
            this.nowPageNum.HeaderText = "真实行号";
            this.nowPageNum.Name = "nowPageNum";
            this.nowPageNum.ReadOnly = true;
            this.nowPageNum.Visible = false;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.FillWeight = 1F;
            this.Url.HeaderText = "文件路径";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Visible = false;
            // 
            // lastReadChapteNo
            // 
            this.lastReadChapteNo.DataPropertyName = "lastReadChapteNo";
            this.lastReadChapteNo.HeaderText = "lastReadChapteNo";
            this.lastReadChapteNo.Name = "lastReadChapteNo";
            this.lastReadChapteNo.ReadOnly = true;
            this.lastReadChapteNo.Visible = false;
            // 
            // chapterMenu
            // 
            this.chapterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.阅读ToolStripMenuItem,
            this.移除ToolStripMenuItem,
            this.全选ToolStripMenuItem,
            this.复制路径ToolStripMenuItem1,
            this.取消全选ToolStripMenuItem1});
            this.chapterMenu.Name = "chapterMenu";
            this.chapterMenu.Size = new System.Drawing.Size(181, 136);
            // 
            // 阅读ToolStripMenuItem
            // 
            this.阅读ToolStripMenuItem.Name = "阅读ToolStripMenuItem";
            this.阅读ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.阅读ToolStripMenuItem.Text = "阅读";
            this.阅读ToolStripMenuItem.Click += new System.EventHandler(this.阅读ToolStripMenuItem_Click);
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.移除ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 复制路径ToolStripMenuItem1
            // 
            this.复制路径ToolStripMenuItem1.Name = "复制路径ToolStripMenuItem1";
            this.复制路径ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.复制路径ToolStripMenuItem1.Text = "复制路径";
            this.复制路径ToolStripMenuItem1.Click += new System.EventHandler(this.复制路径ToolStripMenuItem1_Click);
            // 
            // 取消全选ToolStripMenuItem1
            // 
            this.取消全选ToolStripMenuItem1.Name = "取消全选ToolStripMenuItem1";
            this.取消全选ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.取消全选ToolStripMenuItem1.Text = "取消全选";
            this.取消全选ToolStripMenuItem1.Click += new System.EventHandler(this.取消全选ToolStripMenuItem1_Click);
            // 
            // 继续阅读ToolStripMenuItem
            // 
            this.继续阅读ToolStripMenuItem.Name = "继续阅读ToolStripMenuItem";
            this.继续阅读ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.继续阅读ToolStripMenuItem.Text = "继续阅读";
            // 
            // BookshelfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.table);
            this.Controls.Add(this.tag1);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.Name = "BookshelfForm";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bookshelf";
            this.Shown += new System.EventHandler(this.BookshelfForm_Shown);
            this.Controls.SetChildIndex(this.tips, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.tag1, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.table, 0);
            this.windowBar1.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.chapterMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Tag tag1;
        private AntdUI.Menu menu1;
        public DataGridView table;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn lastReadChapter;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn percentStr;
        private DataGridViewTextBoxColumn bSize;
        private DataGridViewTextBoxColumn Percent;
        private DataGridViewTextBoxColumn MaxPageNum;
        private DataGridViewTextBoxColumn nowPageNum;
        private DataGridViewTextBoxColumn Url;
        private DataGridViewTextBoxColumn lastReadChapteNo;
        private ToolStripMenuItem 继续阅读ToolStripMenuItem;
        private ContextMenuStrip chapterMenu;
        private ToolStripMenuItem 阅读ToolStripMenuItem;
        private ToolStripMenuItem 移除ToolStripMenuItem;
        private ToolStripMenuItem 全选ToolStripMenuItem;
        private ToolStripMenuItem 复制路径ToolStripMenuItem1;
        private ToolStripMenuItem 取消全选ToolStripMenuItem1;
    }
}