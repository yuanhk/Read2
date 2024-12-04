namespace WindRead.form
{
    partial class ParentForm
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
            this.loadingPanel = new AntdUI.Panel();
            this.loadingProgress = new AntdUI.Progress();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadingPanel
            // 
            this.loadingPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingPanel.Back = System.Drawing.Color.Transparent;
            this.loadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.loadingPanel.BorderWidth = 1F;
            this.loadingPanel.Controls.Add(this.loadingProgress);
            this.loadingPanel.Location = new System.Drawing.Point(302, 153);
            this.loadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.loadingPanel.MinimumSize = new System.Drawing.Size(120, 120);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(120, 120);
            this.loadingPanel.TabIndex = 143;
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
            this.loadingProgress.Value = 1F;
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadingPanel);
            this.Name = "ParentForm";
            this.Shadow = 0;
            this.ShadowColor = System.Drawing.Color.White;
            this.Text = "parentForm";
            this.Shown += new System.EventHandler(this.parentForm_Shown);
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public AntdUI.Panel loadingPanel;
        public AntdUI.Progress loadingProgress;
    }
}