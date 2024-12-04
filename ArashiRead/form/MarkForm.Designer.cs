namespace ArashiRead.form
{
    partial class MarkForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            this.markDgv = new System.Windows.Forms.DataGridView();
            this.lastReadChapteNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastReadChapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastReadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalRowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.继续阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除书签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu1 = new AntdUI.Menu();
            this.windowBar1.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markDgv)).BeginInit();
            this.markMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.Controls.Add(this.menu1);
            this.windowBar1.Size = new System.Drawing.Size(648, 26);
            this.windowBar1.Text = " 书 签";
            // 
            // tips
            // 
            this.tips.Location = new System.Drawing.Point(237, 212);
            // 
            // markDgv
            // 
            this.markDgv.AllowUserToAddRows = false;
            this.markDgv.AllowUserToDeleteRows = false;
            this.markDgv.AllowUserToResizeColumns = false;
            this.markDgv.AllowUserToResizeRows = false;
            this.markDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.markDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.markDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.markDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.markDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.markDgv.ColumnHeadersVisible = false;
            this.markDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastReadChapteNo,
            this.name,
            this.lastReadChapter,
            this.lastReadTime,
            this.readRate,
            this.rowNo,
            this.realLineNo,
            this.url,
            this.totalRowCount});
            this.markDgv.ContextMenuStrip = this.markMenu;
            this.markDgv.Location = new System.Drawing.Point(10, 35);
            this.markDgv.MultiSelect = false;
            this.markDgv.Name = "markDgv";
            this.markDgv.ReadOnly = true;
            this.markDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.markDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.markDgv.RowTemplate.Height = 23;
            this.markDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.markDgv.Size = new System.Drawing.Size(626, 354);
            this.markDgv.TabIndex = 17;
            this.markDgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.markDgv_MouseDoubleClick);
            // 
            // lastReadChapteNo
            // 
            this.lastReadChapteNo.DataPropertyName = "lastReadChapteNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.lastReadChapteNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.lastReadChapteNo.FillWeight = 50F;
            this.lastReadChapteNo.HeaderText = "章节编号";
            this.lastReadChapteNo.Name = "lastReadChapteNo";
            this.lastReadChapteNo.ReadOnly = true;
            this.lastReadChapteNo.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.FillWeight = 200F;
            this.name.HeaderText = "书名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // lastReadChapter
            // 
            this.lastReadChapter.DataPropertyName = "lastReadChapter";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.lastReadChapter.DefaultCellStyle = dataGridViewCellStyle3;
            this.lastReadChapter.FillWeight = 200.1929F;
            this.lastReadChapter.HeaderText = "章节名";
            this.lastReadChapter.Name = "lastReadChapter";
            this.lastReadChapter.ReadOnly = true;
            // 
            // lastReadTime
            // 
            this.lastReadTime.DataPropertyName = "lastReadTime";
            this.lastReadTime.HeaderText = "加入书签时间";
            this.lastReadTime.Name = "lastReadTime";
            this.lastReadTime.ReadOnly = true;
            // 
            // readRate
            // 
            this.readRate.DataPropertyName = "readRate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.readRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.readRate.FillWeight = 52.0171F;
            this.readRate.HeaderText = "进度";
            this.readRate.Name = "readRate";
            this.readRate.ReadOnly = true;
            // 
            // rowNo
            // 
            this.rowNo.DataPropertyName = "rowNo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rowNo.DefaultCellStyle = dataGridViewCellStyle5;
            this.rowNo.FillWeight = 1F;
            this.rowNo.HeaderText = "行号";
            this.rowNo.Name = "rowNo";
            this.rowNo.ReadOnly = true;
            this.rowNo.Visible = false;
            // 
            // realLineNo
            // 
            this.realLineNo.DataPropertyName = "realLineNo";
            this.realLineNo.HeaderText = "真实行号";
            this.realLineNo.Name = "realLineNo";
            this.realLineNo.ReadOnly = true;
            this.realLineNo.Visible = false;
            // 
            // url
            // 
            this.url.DataPropertyName = "url";
            this.url.HeaderText = "书籍路径";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            this.url.Visible = false;
            // 
            // totalRowCount
            // 
            this.totalRowCount.DataPropertyName = "totalRowCount";
            this.totalRowCount.HeaderText = "最大行数";
            this.totalRowCount.Name = "totalRowCount";
            this.totalRowCount.ReadOnly = true;
            this.totalRowCount.Visible = false;
            // 
            // markMenu
            // 
            this.markMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.继续阅读ToolStripMenuItem,
            this.移除书签ToolStripMenuItem});
            this.markMenu.Name = "markMenu";
            this.markMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // 继续阅读ToolStripMenuItem
            // 
            this.继续阅读ToolStripMenuItem.Name = "继续阅读ToolStripMenuItem";
            this.继续阅读ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.继续阅读ToolStripMenuItem.Text = "继续阅读";
            this.继续阅读ToolStripMenuItem.Click += new System.EventHandler(this.继续阅读ToolStripMenuItem_Click);
            // 
            // 移除书签ToolStripMenuItem
            // 
            this.移除书签ToolStripMenuItem.Name = "移除书签ToolStripMenuItem";
            this.移除书签ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.移除书签ToolStripMenuItem.Text = "移除书签";
            this.移除书签ToolStripMenuItem.Click += new System.EventHandler(this.移除书签ToolStripMenuItem_Click);
            // 
            // menu1
            // 
            this.menu1.BackActive = System.Drawing.Color.Transparent;
            this.menu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu1.ForeActive = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.menu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            menuItem1.Text = "清除失效书签";
            this.menu1.Items.AddRange(new AntdUI.MenuItem[] {
            menuItem1});
            this.menu1.Location = new System.Drawing.Point(456, 5);
            this.menu1.Mode = AntdUI.TMenuMode.Horizontal;
            this.menu1.Name = "menu1";
            this.menu1.Radius = 1;
            this.menu1.Size = new System.Drawing.Size(93, 20);
            this.menu1.TabIndex = 6;
            this.menu1.Text = "menu1";
            this.menu1.SelectChanged += new AntdUI.Menu.SelectEventHandler(this.menu1_SelectChanged);
            // 
            // MarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.markDgv);
            this.Name = "MarkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MarkForm";
            this.Shown += new System.EventHandler(this.MarkForm_Shown);
            this.Controls.SetChildIndex(this.markDgv, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.tips, 0);
            this.windowBar1.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.markDgv)).EndInit();
            this.markMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView markDgv;
        private System.Windows.Forms.ContextMenuStrip markMenu;
        private System.Windows.Forms.ToolStripMenuItem 继续阅读ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除书签ToolStripMenuItem;
        private AntdUI.Menu menu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastReadChapteNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastReadChapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastReadTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn readRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn realLineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalRowCount;
    }
}