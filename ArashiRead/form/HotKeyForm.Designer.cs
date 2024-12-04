namespace ArashiRead.form
{
    partial class HotKeyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            this.hotKeyDgv = new System.Windows.Forms.DataGridView();
            this.CatalogNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.章节 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.页码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu1 = new AntdUI.Menu();
            this.windowBar1.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hotKeyDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.Controls.Add(this.menu1);
            this.windowBar1.Text = "快捷键";
            // 
            // hotKeyDgv
            // 
            this.hotKeyDgv.AllowUserToAddRows = false;
            this.hotKeyDgv.AllowUserToDeleteRows = false;
            this.hotKeyDgv.AllowUserToResizeColumns = false;
            this.hotKeyDgv.AllowUserToResizeRows = false;
            this.hotKeyDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hotKeyDgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.hotKeyDgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hotKeyDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.hotKeyDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hotKeyDgv.ColumnHeadersVisible = false;
            this.hotKeyDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CatalogNo,
            this.章节,
            this.页码});
            this.hotKeyDgv.Location = new System.Drawing.Point(9, 35);
            this.hotKeyDgv.MultiSelect = false;
            this.hotKeyDgv.Name = "hotKeyDgv";
            this.hotKeyDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hotKeyDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.hotKeyDgv.RowTemplate.Height = 23;
            this.hotKeyDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hotKeyDgv.Size = new System.Drawing.Size(627, 354);
            this.hotKeyDgv.TabIndex = 94;
            this.hotKeyDgv.Tag = "注意:全局热键均为组合键，规则为 Ctrl + Alt + 设置键码 ";
            this.hotKeyDgv.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.hotKeyDgv_CellMouseEnter);
            this.hotKeyDgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotKeyDgv_KeyDown_1);
            // 
            // CatalogNo
            // 
            this.CatalogNo.DataPropertyName = "effect";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CatalogNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.CatalogNo.FillWeight = 35F;
            this.CatalogNo.HeaderText = "对应功能";
            this.CatalogNo.Name = "CatalogNo";
            this.CatalogNo.ReadOnly = true;
            // 
            // 章节
            // 
            this.章节.DataPropertyName = "keyCode";
            this.章节.FillWeight = 35F;
            this.章节.HeaderText = "按键代码";
            this.章节.Name = "章节";
            this.章节.ReadOnly = true;
            // 
            // 页码
            // 
            this.页码.DataPropertyName = "explain";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.页码.DefaultCellStyle = dataGridViewCellStyle3;
            this.页码.FillWeight = 50F;
            this.页码.HeaderText = "按键详情";
            this.页码.Name = "页码";
            this.页码.ReadOnly = true;
            // 
            // menu1
            // 
            this.menu1.BackActive = System.Drawing.Color.Transparent;
            this.menu1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu1.ForeActive = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.menu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            menuItem1.Text = "全部重置";
            this.menu1.Items.AddRange(new AntdUI.MenuItem[] {
            menuItem1});
            this.menu1.Location = new System.Drawing.Point(436, 5);
            this.menu1.Mode = AntdUI.TMenuMode.Horizontal;
            this.menu1.Name = "menu1";
            this.menu1.Radius = 1;
            this.menu1.Size = new System.Drawing.Size(65, 20);
            this.menu1.TabIndex = 95;
            this.menu1.Text = "重置";
            this.menu1.SelectChanged += new AntdUI.Menu.SelectEventHandler(this.menu1_SelectChanged);
            // 
            // HotKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.hotKeyDgv);
            this.Name = "HotKeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HotKeyForm";
            this.Shown += new System.EventHandler(this.HotKeyForm_Shown);
            this.Controls.SetChildIndex(this.hotKeyDgv, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.tips, 0);
            this.windowBar1.ResumeLayout(false);
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hotKeyDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView hotKeyDgv;
        private AntdUI.Menu menu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatalogNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn 章节;
        private System.Windows.Forms.DataGridViewTextBoxColumn 页码;
    }
}