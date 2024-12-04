namespace ArashiRead.form
{
    partial class ChapterForm
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
            this.catalogDgv = new System.Windows.Forms.DataGridView();
            this.CatalogNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatalogName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.页码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chapterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.阅读ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox = new AntdUI.Input();
            this.windowBar1.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catalogDgv)).BeginInit();
            this.chapterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.Controls.Add(this.filterBox);
            this.windowBar1.Size = new System.Drawing.Size(648, 26);
            this.windowBar1.Text = "章节列表";
            // 
            // loadingProgress
            // 
            this.loadingProgress.Location = new System.Drawing.Point(50, 51);
            // 
            // loadingPanel
            // 
            this.loadingPanel.Location = new System.Drawing.Point(9, 392);
            // 
            // catalogDgv
            // 
            this.catalogDgv.AllowUserToAddRows = false;
            this.catalogDgv.AllowUserToDeleteRows = false;
            this.catalogDgv.AllowUserToResizeColumns = false;
            this.catalogDgv.AllowUserToResizeRows = false;
            this.catalogDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.catalogDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.catalogDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.catalogDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.catalogDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogDgv.ColumnHeadersVisible = false;
            this.catalogDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CatalogNo,
            this.CatalogName,
            this.进度,
            this.页码});
            this.catalogDgv.ContextMenuStrip = this.chapterMenu;
            this.catalogDgv.Location = new System.Drawing.Point(10, 35);
            this.catalogDgv.MultiSelect = false;
            this.catalogDgv.Name = "catalogDgv";
            this.catalogDgv.ReadOnly = true;
            this.catalogDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.catalogDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.catalogDgv.RowTemplate.Height = 23;
            this.catalogDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.catalogDgv.Size = new System.Drawing.Size(626, 354);
            this.catalogDgv.TabIndex = 16;
            this.catalogDgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.catalogDgv_MouseClick);
            this.catalogDgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.catalogDgv_MouseDoubleClick);
            // 
            // CatalogNo
            // 
            this.CatalogNo.DataPropertyName = "chapterNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CatalogNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.CatalogNo.FillWeight = 50F;
            this.CatalogNo.HeaderText = "章节";
            this.CatalogNo.Name = "CatalogNo";
            this.CatalogNo.ReadOnly = true;
            // 
            // CatalogName
            // 
            this.CatalogName.DataPropertyName = "chapterName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CatalogName.DefaultCellStyle = dataGridViewCellStyle3;
            this.CatalogName.FillWeight = 200.1929F;
            this.CatalogName.HeaderText = "章节名";
            this.CatalogName.Name = "CatalogName";
            this.CatalogName.ReadOnly = true;
            // 
            // 进度
            // 
            this.进度.DataPropertyName = "rateStr";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.进度.DefaultCellStyle = dataGridViewCellStyle4;
            this.进度.FillWeight = 52.0171F;
            this.进度.HeaderText = "进度";
            this.进度.Name = "进度";
            this.进度.ReadOnly = true;
            // 
            // 页码
            // 
            this.页码.DataPropertyName = "Index";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.页码.DefaultCellStyle = dataGridViewCellStyle5;
            this.页码.FillWeight = 1F;
            this.页码.HeaderText = "页码";
            this.页码.Name = "页码";
            this.页码.ReadOnly = true;
            this.页码.Visible = false;
            // 
            // chapterMenu
            // 
            this.chapterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.阅读ToolStripMenuItem});
            this.chapterMenu.Name = "chapterMenu";
            this.chapterMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // 阅读ToolStripMenuItem
            // 
            this.阅读ToolStripMenuItem.Name = "阅读ToolStripMenuItem";
            this.阅读ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.阅读ToolStripMenuItem.Text = "阅读";
            this.阅读ToolStripMenuItem.Click += new System.EventHandler(this.阅读ToolStripMenuItem_Click);
            // 
            // filterBox
            // 
            this.filterBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.filterBox.BorderWidth = 0F;
            this.filterBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filterBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filterBox.Location = new System.Drawing.Point(307, -1);
            this.filterBox.Margin = new System.Windows.Forms.Padding(0);
            this.filterBox.Margins = 1;
            this.filterBox.Name = "filterBox";
            this.filterBox.Prefix = global::ArashiRead.Properties.Resources.search;
            this.filterBox.PrefixText = "";
            this.filterBox.Radius = 2;
            this.filterBox.SelectionColor = System.Drawing.SystemColors.ActiveCaption;
            this.filterBox.Size = new System.Drawing.Size(245, 28);
            this.filterBox.Suffix = global::ArashiRead.Properties.Resources.search;
            this.filterBox.SuffixText = "";
            this.filterBox.TabIndex = 1;
            this.filterBox.Text = "请输入章节名";
            this.filterBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filterBox.SuffixClick += new System.Windows.Forms.MouseEventHandler(this.input1_SuffixClick);
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            this.filterBox.Enter += new System.EventHandler(this.filterBox_Enter);
            this.filterBox.Leave += new System.EventHandler(this.filterBox_Leave);
            // 
            // ChapterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.catalogDgv);
            this.MaximizeBox = false;
            this.Name = "ChapterForm";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChapterForm";
            this.Shown += new System.EventHandler(this.ChapterForm_Shown);
            this.Controls.SetChildIndex(this.tips, 0);
            this.Controls.SetChildIndex(this.catalogDgv, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.windowBar1.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.catalogDgv)).EndInit();
            this.chapterMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView catalogDgv;
        private AntdUI.Input filterBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatalogNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatalogName;
        private System.Windows.Forms.DataGridViewTextBoxColumn 进度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 页码;
        private System.Windows.Forms.ContextMenuStrip chapterMenu;
        private System.Windows.Forms.ToolStripMenuItem 阅读ToolStripMenuItem;
    }
}