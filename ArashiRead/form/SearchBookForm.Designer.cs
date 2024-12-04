namespace ArashiRead.form
{
    partial class SearchBookForm
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
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu1 = new AntdUI.Menu();
            this.searchResultDgv = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxPageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nowPageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windowBar1.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // partitionTop
            // 
            this.partitionTop.MaximumSize = new System.Drawing.Size(530, 1);
            this.partitionTop.MinimumSize = new System.Drawing.Size(530, 1);
            this.partitionTop.Size = new System.Drawing.Size(530, 1);
            // 
            // windowBar1
            // 
            this.windowBar1.Controls.Add(this.menu1);
            this.windowBar1.MaximumSize = new System.Drawing.Size(550, 26);
            this.windowBar1.MinimizeBox = false;
            this.windowBar1.MinimumSize = new System.Drawing.Size(550, 26);
            this.windowBar1.Size = new System.Drawing.Size(550, 26);
            this.windowBar1.Text = "  检索书籍";
            // 
            // menu1
            // 
            this.menu1.BackActive = System.Drawing.Color.Transparent;
            this.menu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu1.ForeActive = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.menu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            menuItem1.Text = "全部导入";
            menuItem2.Text = "更换文件夹";
            this.menu1.Items.AddRange(new AntdUI.MenuItem[] {
            menuItem1,
            menuItem2});
            this.menu1.Location = new System.Drawing.Point(353, 4);
            this.menu1.Mode = AntdUI.TMenuMode.Horizontal;
            this.menu1.Name = "menu1";
            this.menu1.Radius = 1;
            this.menu1.Size = new System.Drawing.Size(152, 20);
            this.menu1.TabIndex = 6;
            this.menu1.Text = "menu1";
            this.menu1.SelectChanged += new AntdUI.Menu.SelectEventHandler(this.menu1_SelectChanged);
            // 
            // searchResultDgv
            // 
            this.searchResultDgv.AllowUserToAddRows = false;
            this.searchResultDgv.AllowUserToDeleteRows = false;
            this.searchResultDgv.AllowUserToResizeColumns = false;
            this.searchResultDgv.AllowUserToResizeRows = false;
            this.searchResultDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchResultDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.searchResultDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchResultDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.searchResultDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResultDgv.ColumnHeadersVisible = false;
            this.searchResultDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.bSize,
            this.partPath,
            this.Url,
            this.chapter,
            this.percentStr,
            this.time,
            this.Percent,
            this.MaxPageNum,
            this.nowPageNum});
            this.searchResultDgv.Location = new System.Drawing.Point(10, 35);
            this.searchResultDgv.Name = "searchResultDgv";
            this.searchResultDgv.ReadOnly = true;
            this.searchResultDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchResultDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.searchResultDgv.RowTemplate.Height = 23;
            this.searchResultDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchResultDgv.Size = new System.Drawing.Size(530, 292);
            this.searchResultDgv.TabIndex = 96;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "书名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // bSize
            // 
            this.bSize.DataPropertyName = "Size";
            this.bSize.FillWeight = 35F;
            this.bSize.HeaderText = "书籍大小";
            this.bSize.Name = "bSize";
            this.bSize.ReadOnly = true;
            // 
            // partPath
            // 
            this.partPath.DataPropertyName = "partPath";
            this.partPath.FillWeight = 85F;
            this.partPath.HeaderText = "局部路径";
            this.partPath.Name = "partPath";
            this.partPath.ReadOnly = true;
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
            // chapter
            // 
            this.chapter.DataPropertyName = "Chapter";
            this.chapter.FillWeight = 1F;
            this.chapter.HeaderText = "章节或预览";
            this.chapter.Name = "chapter";
            this.chapter.ReadOnly = true;
            this.chapter.Visible = false;
            // 
            // percentStr
            // 
            this.percentStr.DataPropertyName = "PercentStr";
            this.percentStr.FillWeight = 1F;
            this.percentStr.HeaderText = "阅读进度(显示)";
            this.percentStr.Name = "percentStr";
            this.percentStr.ReadOnly = true;
            this.percentStr.Visible = false;
            // 
            // time
            // 
            this.time.DataPropertyName = "LastReadTime";
            this.time.FillWeight = 1F;
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Visible = false;
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
            this.MaxPageNum.DataPropertyName = "MaxPageNum";
            this.MaxPageNum.FillWeight = 1F;
            this.MaxPageNum.HeaderText = "最大页数";
            this.MaxPageNum.Name = "MaxPageNum";
            this.MaxPageNum.ReadOnly = true;
            this.MaxPageNum.Visible = false;
            // 
            // nowPageNum
            // 
            this.nowPageNum.DataPropertyName = "NowPageNum";
            this.nowPageNum.FillWeight = 1F;
            this.nowPageNum.HeaderText = "当前页码";
            this.nowPageNum.Name = "nowPageNum";
            this.nowPageNum.ReadOnly = true;
            this.nowPageNum.Visible = false;
            // 
            // SearchBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 339);
            this.Controls.Add(this.searchResultDgv);
            this.MaximumSize = new System.Drawing.Size(550, 340);
            this.MinimumSize = new System.Drawing.Size(550, 340);
            this.Name = "SearchBookForm";
            this.Opacity = 1D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchBookForm";
            this.Shown += new System.EventHandler(this.SearchBookForm_Shown);
            this.Controls.SetChildIndex(this.tips, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.searchResultDgv, 0);
            this.windowBar1.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchResultDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Menu menu1;
        public System.Windows.Forms.DataGridView searchResultDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn partPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn chapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxPageNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn nowPageNum;
    }
}