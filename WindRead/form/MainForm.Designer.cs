using System.Collections.Generic;
using System.Windows.Forms;
using System;
using WindRead.cache;
using WindRead.util;

namespace WindRead.form
{
    partial class MainForm
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//取消方向键对控件的焦点的控件，用自己自定义的函数处理各个方向键的处理函数
        {
            string code = keyData.ToString();
            //屏蔽tab键
            if (code.Equals("Tab"))
            {
                return true;
            }
            Dictionary<String, String> hotKeyMap = ConfigCache.hotKeyMap;
            if (hotKeyMap != null && hotKeyMap.ContainsKey(code))
            {
                String effect = hotKeyMap[code];
                switch (effect)
                {
                    case "下一页":
                        showContent(1, null, null);
                        return true;
                    case "上一页":
                        showContent(-1, null, null);
                        return true;
                    case "最小化":
                        WindowState = FormWindowState.Minimized;
                        this.ShowInTaskbar = false;
                        return true;
                    case "关闭":
                        BookUtil.SaveLastRead();
                        System.Environment.Exit(0);
                        return true;
                }
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.windowBar = new AntdUI.WindowBar();
            this.menuPanel = new AntdUI.Panel();
            this.leftDivider = new AntdUI.Divider();
            this.readProgress = new AntdUI.Slider();
            this.chapterTag = new AntdUI.Tag();
            this.label1 = new AntdUI.Label();
            this.totalLab = new AntdUI.Label();
            this.currentLab = new AntdUI.Label();
            this.rateLab = new AntdUI.Label();
            this.bookNameTag = new AntdUI.Tag();
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMark = new System.Windows.Forms.ToolStripMenuItem();
            this.selectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sreachItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webSreachItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new ArashiRead.form.RichTextBoxEx();
            this.testBox = new System.Windows.Forms.TextBox();
            this.loadingPanel.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadingPanel
            // 
            this.loadingPanel.Location = new System.Drawing.Point(377, 195);
            this.loadingPanel.Size = new System.Drawing.Size(200, 200);
            // 
            // loadingProgress
            // 
            this.loadingProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.loadingProgress.Location = new System.Drawing.Point(1, 1);
            this.loadingProgress.MaximumSize = new System.Drawing.Size(200, 200);
            this.loadingProgress.Size = new System.Drawing.Size(198, 198);
            // 
            // windowBar
            // 
            this.windowBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowBar.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowBar.Location = new System.Drawing.Point(0, 0);
            this.windowBar.Name = "windowBar";
            this.windowBar.ShowIcon = false;
            this.windowBar.Size = new System.Drawing.Size(1000, 30);
            this.windowBar.TabIndex = 0;
            this.windowBar.Text = " ";
            // 
            // menuPanel
            // 
            this.menuPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(40, 618);
            this.menuPanel.TabIndex = 1;
            this.menuPanel.Text = "panel1";
            this.menuPanel.MouseEnter += new System.EventHandler(this.menuPanel_Enter);
            // 
            // leftDivider
            // 
            this.leftDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftDivider.ColorSplit = System.Drawing.Color.DarkGray;
            this.leftDivider.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leftDivider.Location = new System.Drawing.Point(41, 0);
            this.leftDivider.Name = "leftDivider";
            this.leftDivider.Orientation = AntdUI.TOrientation.Left;
            this.leftDivider.OrientationMargin = 0F;
            this.leftDivider.Size = new System.Drawing.Size(5, 618);
            this.leftDivider.TabIndex = 2;
            this.leftDivider.Text = "";
            this.leftDivider.Vertical = true;
            // 
            // readProgress
            // 
            this.readProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readProgress.BackColor = System.Drawing.Color.Transparent;
            this.readProgress.BadgeBack = System.Drawing.SystemColors.ActiveCaptionText;
            this.readProgress.DotSize = 6;
            this.readProgress.DotSizeActive = 6;
            this.readProgress.Fill = System.Drawing.Color.Aqua;
            this.readProgress.FillActive = System.Drawing.Color.DarkRed;
            this.readProgress.FillHover = System.Drawing.Color.AliceBlue;
            this.readProgress.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readProgress.ForeColor = System.Drawing.Color.White;
            this.readProgress.LineSize = 1;
            this.readProgress.Location = new System.Drawing.Point(51, 581);
            this.readProgress.Margin = new System.Windows.Forms.Padding(0);
            this.readProgress.MaxValue = 10000;
            this.readProgress.Name = "readProgress";
            this.readProgress.ShowValue = true;
            this.readProgress.Size = new System.Drawing.Size(932, 10);
            this.readProgress.TabIndex = 135;
            // 
            // chapterTag
            // 
            this.chapterTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chapterTag.BackColor = System.Drawing.Color.Transparent;
            this.chapterTag.BorderWidth = 0F;
            this.chapterTag.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chapterTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.chapterTag.Location = new System.Drawing.Point(49, 591);
            this.chapterTag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chapterTag.Name = "chapterTag";
            this.chapterTag.Size = new System.Drawing.Size(270, 24);
            this.chapterTag.TabIndex = 136;
            this.chapterTag.Text = "章节";
            this.chapterTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.label1.Location = new System.Drawing.Point(512, 592);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 24);
            this.label1.TabIndex = 141;
            this.label1.Text = "/";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalLab
            // 
            this.totalLab.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.totalLab.BackColor = System.Drawing.Color.Transparent;
            this.totalLab.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.totalLab.Location = new System.Drawing.Point(526, 592);
            this.totalLab.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.totalLab.Name = "totalLab";
            this.totalLab.Size = new System.Drawing.Size(50, 24);
            this.totalLab.TabIndex = 140;
            this.totalLab.Text = "0";
            // 
            // currentLab
            // 
            this.currentLab.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.currentLab.BackColor = System.Drawing.Color.Transparent;
            this.currentLab.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.currentLab.Location = new System.Drawing.Point(461, 592);
            this.currentLab.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.currentLab.Name = "currentLab";
            this.currentLab.Size = new System.Drawing.Size(50, 24);
            this.currentLab.TabIndex = 139;
            this.currentLab.Text = "0";
            this.currentLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rateLab
            // 
            this.rateLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rateLab.BackColor = System.Drawing.Color.Transparent;
            this.rateLab.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rateLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.rateLab.Location = new System.Drawing.Point(925, 593);
            this.rateLab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rateLab.Name = "rateLab";
            this.rateLab.Size = new System.Drawing.Size(57, 24);
            this.rateLab.TabIndex = 138;
            this.rateLab.Text = "0%";
            // 
            // bookNameTag
            // 
            this.bookNameTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bookNameTag.BackColor = System.Drawing.Color.Transparent;
            this.bookNameTag.BorderWidth = 0F;
            this.bookNameTag.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookNameTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.bookNameTag.Location = new System.Drawing.Point(656, 592);
            this.bookNameTag.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.bookNameTag.Name = "bookNameTag";
            this.bookNameTag.Size = new System.Drawing.Size(269, 24);
            this.bookNameTag.TabIndex = 137;
            this.bookNameTag.Text = "书名";
            this.bookNameTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMark,
            this.selectItem,
            this.copyItem,
            this.sreachItem,
            this.webSreachItem});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(137, 114);
            // 
            // addMark
            // 
            this.addMark.Name = "addMark";
            this.addMark.Size = new System.Drawing.Size(136, 22);
            this.addMark.Text = "添加书签";
            this.addMark.Click += new System.EventHandler(this.addMark_Click);
            // 
            // selectItem
            // 
            this.selectItem.Name = "selectItem";
            this.selectItem.Size = new System.Drawing.Size(136, 22);
            this.selectItem.Text = "选中文本";
            this.selectItem.Visible = false;
            // 
            // copyItem
            // 
            this.copyItem.Name = "copyItem";
            this.copyItem.Size = new System.Drawing.Size(136, 22);
            this.copyItem.Text = "复制";
            this.copyItem.Visible = false;
            // 
            // sreachItem
            // 
            this.sreachItem.Name = "sreachItem";
            this.sreachItem.Size = new System.Drawing.Size(136, 22);
            this.sreachItem.Text = "全文检索";
            this.sreachItem.Visible = false;
            // 
            // webSreachItem
            // 
            this.webSreachItem.Name = "webSreachItem";
            this.webSreachItem.Size = new System.Drawing.Size(136, 22);
            this.webSreachItem.Text = "浏览器搜索";
            this.webSreachItem.Visible = false;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BackColor = System.Drawing.Color.Bisque;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.ContextMenuStrip = this.mainMenu;
            this.textBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox.HideSelection = false;
            this.textBox.Location = new System.Drawing.Point(58, 30);
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBox.ShortcutsEnabled = false;
            this.textBox.Size = new System.Drawing.Size(922, 548);
            this.textBox.TabIndex = 19;
            this.textBox.Text = "";
            // 
            // testBox
            // 
            this.testBox.Location = new System.Drawing.Point(871, 542);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(100, 26);
            this.testBox.TabIndex = 145;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 618);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.chapterTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalLab);
            this.Controls.Add(this.currentLab);
            this.Controls.Add(this.rateLab);
            this.Controls.Add(this.bookNameTag);
            this.Controls.Add(this.readProgress);
            this.Controls.Add(this.leftDivider);
            this.Controls.Add(this.windowBar);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.testBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(618, 382);
            this.Name = "MainForm";
            this.Radius = 6;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.BindingContextChanged += new System.EventHandler(this.MainForm_BindingContextChanged);
            this.Controls.SetChildIndex(this.testBox, 0);
            this.Controls.SetChildIndex(this.textBox, 0);
            this.Controls.SetChildIndex(this.windowBar, 0);
            this.Controls.SetChildIndex(this.leftDivider, 0);
            this.Controls.SetChildIndex(this.readProgress, 0);
            this.Controls.SetChildIndex(this.bookNameTag, 0);
            this.Controls.SetChildIndex(this.rateLab, 0);
            this.Controls.SetChildIndex(this.currentLab, 0);
            this.Controls.SetChildIndex(this.totalLab, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chapterTag, 0);
            this.Controls.SetChildIndex(this.menuPanel, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.loadingPanel.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AntdUI.WindowBar windowBar;
        private AntdUI.Panel menuPanel;
        private AntdUI.Divider leftDivider;
        private AntdUI.Slider readProgress;
        public AntdUI.Tag chapterTag;
        public AntdUI.Label label1;
        public AntdUI.Label totalLab;
        public AntdUI.Label currentLab;
        public AntdUI.Label rateLab;
        public AntdUI.Tag bookNameTag;
        public ArashiRead.form.RichTextBoxEx textBox;
        public ContextMenuStrip mainMenu;
        private ToolStripMenuItem addMark;
        private ToolStripMenuItem selectItem;
        private ToolStripMenuItem copyItem;
        private ToolStripMenuItem sreachItem;
        private ToolStripMenuItem webSreachItem;
        private TextBox testBox;
    }
}