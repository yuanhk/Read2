using System.Drawing;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class ParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentForm));
            this.windowBar1 = new AntdUI.WindowBar();
            this.partitionTop = new System.Windows.Forms.Panel();
            this.loadingPanel = new AntdUI.Panel();
            this.loadingProgress = new AntdUI.Progress();
            this.tips = new AntdUI.Alert();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBar1
            // 
            this.windowBar1.BackColor = System.Drawing.Color.Transparent;
            this.windowBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.windowBar1.ForeColor = System.Drawing.Color.White;
            this.windowBar1.Location = new System.Drawing.Point(0, 0);
            this.windowBar1.MaximizeBox = false;
            this.windowBar1.MinimumSize = new System.Drawing.Size(598, 26);
            this.windowBar1.Name = "windowBar1";
            this.windowBar1.ShowIcon = false;
            this.windowBar1.Size = new System.Drawing.Size(648, 26);
            this.windowBar1.TabIndex = 0;
            this.windowBar1.Text = " ";
            this.windowBar1.UseSystemStyleColor = true;
            // 
            // partitionTop
            // 
            this.partitionTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partitionTop.BackColor = System.Drawing.Color.White;
            this.partitionTop.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.partitionTop.Location = new System.Drawing.Point(10, 28);
            this.partitionTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.partitionTop.MaximumSize = new System.Drawing.Size(628, 1);
            this.partitionTop.MinimumSize = new System.Drawing.Size(628, 1);
            this.partitionTop.Name = "partitionTop";
            this.partitionTop.Size = new System.Drawing.Size(628, 1);
            this.partitionTop.TabIndex = 3;
            // 
            // loadingPanel
            // 
            this.loadingPanel.Back = System.Drawing.Color.Transparent;
            this.loadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.loadingPanel.BorderWidth = 1F;
            this.loadingPanel.Controls.Add(this.loadingProgress);
            this.loadingPanel.Location = new System.Drawing.Point(111, 189);
            this.loadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.loadingPanel.MinimumSize = new System.Drawing.Size(120, 120);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(120, 120);
            this.loadingPanel.TabIndex = 15;
            this.loadingPanel.Tag = "loading";
            this.loadingPanel.Text = "panel3";
            this.loadingPanel.Visible = false;
            // 
            // loadingProgress
            // 
            this.loadingProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingProgress.Back = System.Drawing.Color.Transparent;
            this.loadingProgress.BackColor = System.Drawing.Color.Transparent;
            this.loadingProgress.Location = new System.Drawing.Point(10, 10);
            this.loadingProgress.Margin = new System.Windows.Forms.Padding(0);
            this.loadingProgress.MaximumSize = new System.Drawing.Size(100, 100);
            this.loadingProgress.MinimumSize = new System.Drawing.Size(100, 100);
            this.loadingProgress.Name = "loadingProgress";
            this.loadingProgress.Radius = 2;
            this.loadingProgress.Shape = AntdUI.TShape.Circle;
            this.loadingProgress.Size = new System.Drawing.Size(100, 100);
            this.loadingProgress.TabIndex = 13;
            this.loadingProgress.Tag = "loading";
            this.loadingProgress.Text = "0%";
            // 
            // tips
            // 
            this.tips.Icon = AntdUI.TType.Success;
            this.tips.Location = new System.Drawing.Point(10, 32);
            this.tips.Name = "tips";
            this.tips.Radius = 2;
            this.tips.Size = new System.Drawing.Size(75, 24);
            this.tips.TabIndex = 16;
            this.tips.Text = "提示框";
            this.tips.Visible = false;
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.tips);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.partitionTop);
            this.Controls.Add(this.windowBar1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(650, 402);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 402);
            this.Name = "ParentForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Shown += new System.EventHandler(this.ParentForm_Shown);
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Panel partitionTop;
        public AntdUI.WindowBar windowBar1;
        public AntdUI.Progress loadingProgress;
        public AntdUI.Panel loadingPanel;
        public AntdUI.Alert tips;
    }
}