namespace ArashiRead.form
{
    partial class FullTextSreachForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fullSearchDgv = new System.Windows.Forms.DataGridView();
            this.chapterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.章节 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.页码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullTextSreachMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sreachBox = new AntdUI.Input();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullSearchDgv)).BeginInit();
            this.FullTextSreachMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.Size = new System.Drawing.Size(648, 26);
            this.windowBar1.Text = " 全文查找";
            // 
            // fullSearchDgv
            // 
            this.fullSearchDgv.AllowUserToAddRows = false;
            this.fullSearchDgv.AllowUserToDeleteRows = false;
            this.fullSearchDgv.AllowUserToResizeColumns = false;
            this.fullSearchDgv.AllowUserToResizeRows = false;
            this.fullSearchDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fullSearchDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.fullSearchDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fullSearchDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.fullSearchDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fullSearchDgv.ColumnHeadersVisible = false;
            this.fullSearchDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chapterNo,
            this.章节,
            this.row,
            this.页码,
            this.realLineNo});
            this.fullSearchDgv.ContextMenuStrip = this.FullTextSreachMenu;
            this.fullSearchDgv.Location = new System.Drawing.Point(10, 32);
            this.fullSearchDgv.MultiSelect = false;
            this.fullSearchDgv.Name = "fullSearchDgv";
            this.fullSearchDgv.ReadOnly = true;
            this.fullSearchDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fullSearchDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.fullSearchDgv.RowTemplate.Height = 23;
            this.fullSearchDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fullSearchDgv.Size = new System.Drawing.Size(626, 357);
            this.fullSearchDgv.TabIndex = 93;
            this.fullSearchDgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fullSearchDgv_CellContentDoubleClick);
            // 
            // chapterNo
            // 
            this.chapterNo.DataPropertyName = "chapterNo";
            this.chapterNo.FillWeight = 1F;
            this.chapterNo.HeaderText = "章节码";
            this.chapterNo.Name = "chapterNo";
            this.chapterNo.ReadOnly = true;
            this.chapterNo.Visible = false;
            // 
            // 章节
            // 
            this.章节.DataPropertyName = "chapterName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.章节.DefaultCellStyle = dataGridViewCellStyle2;
            this.章节.FillWeight = 83.50254F;
            this.章节.HeaderText = "章节";
            this.章节.MinimumWidth = 30;
            this.章节.Name = "章节";
            this.章节.ReadOnly = true;
            // 
            // row
            // 
            this.row.DataPropertyName = "row";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.row.DefaultCellStyle = dataGridViewCellStyle3;
            this.row.FillWeight = 266.4975F;
            this.row.HeaderText = "预览";
            this.row.MinimumWidth = 150;
            this.row.Name = "row";
            this.row.ReadOnly = true;
            // 
            // 页码
            // 
            this.页码.DataPropertyName = "index";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.页码.DefaultCellStyle = dataGridViewCellStyle4;
            this.页码.FillWeight = 1F;
            this.页码.HeaderText = "页码";
            this.页码.Name = "页码";
            this.页码.ReadOnly = true;
            this.页码.Visible = false;
            // 
            // realLineNo
            // 
            this.realLineNo.DataPropertyName = "realLineNo";
            this.realLineNo.FillWeight = 1F;
            this.realLineNo.HeaderText = "真实页码";
            this.realLineNo.Name = "realLineNo";
            this.realLineNo.ReadOnly = true;
            this.realLineNo.Visible = false;
            // 
            // FullTextSreachMenu
            // 
            this.FullTextSreachMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.阅读ToolStripMenuItem});
            this.FullTextSreachMenu.Name = "FullTextSreachMenu";
            this.FullTextSreachMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // 阅读ToolStripMenuItem
            // 
            this.阅读ToolStripMenuItem.Name = "阅读ToolStripMenuItem";
            this.阅读ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.阅读ToolStripMenuItem.Text = "阅读";
            this.阅读ToolStripMenuItem.Click += new System.EventHandler(this.阅读ToolStripMenuItem_Click);
            // 
            // sreachBox
            // 
            this.sreachBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.sreachBox.BorderWidth = 0F;
            this.sreachBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sreachBox.Location = new System.Drawing.Point(120, 32);
            this.sreachBox.Margin = new System.Windows.Forms.Padding(0);
            this.sreachBox.Margins = 1;
            this.sreachBox.Name = "sreachBox";
            this.sreachBox.Prefix = global::ArashiRead.Properties.Resources.search;
            this.sreachBox.PrefixText = "";
            this.sreachBox.Radius = 2;
            this.sreachBox.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.sreachBox.Size = new System.Drawing.Size(380, 28);
            this.sreachBox.Suffix = global::ArashiRead.Properties.Resources.search;
            this.sreachBox.SuffixText = "查询结果 : 0 ";
            this.sreachBox.TabIndex = 94;
            this.sreachBox.Text = "请输入搜索文本";
            this.sreachBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sreachBox.Enter += new System.EventHandler(this.sreachBox_Enter);
            this.sreachBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sreachBox_KeyUp);
            this.sreachBox.Leave += new System.EventHandler(this.sreachBox_Leave);
            // 
            // FullTextSreachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.sreachBox);
            this.Controls.Add(this.fullSearchDgv);
            this.Name = "FullTextSreachForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SreachForm";
            this.Shown += new System.EventHandler(this.FullTextSreachForm_Shown);
            this.Controls.SetChildIndex(this.fullSearchDgv, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.sreachBox, 0);
            this.Controls.SetChildIndex(this.tips, 0);
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fullSearchDgv)).EndInit();
            this.FullTextSreachMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView fullSearchDgv;
        private AntdUI.Input sreachBox;
        private System.Windows.Forms.ContextMenuStrip FullTextSreachMenu;
        private System.Windows.Forms.ToolStripMenuItem 阅读ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn chapterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn 章节;
        private System.Windows.Forms.DataGridViewTextBoxColumn row;
        private System.Windows.Forms.DataGridViewTextBoxColumn 页码;
        private System.Windows.Forms.DataGridViewTextBoxColumn realLineNo;
    }
}