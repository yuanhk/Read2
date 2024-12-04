using ArashiRead.config;
using ArashiRead.service;
using ArashiRead.form;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Drawing;
using ArashiRead.cache;

namespace ArashiRead
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
                switch (effect) {
                    case "下一页":
                        showContent(1,null,null);
                        return true;
                    case "上一页":
                        showContent(-1, null,null);
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chapterTag = new AntdUI.Tag();
            this.readProgress = new AntdUI.Progress();
            this.bookNameTag = new AntdUI.Tag();
            this.rateLab = new AntdUI.Label();
            this.panel1 = new AntdUI.Panel();
            this.reset = new System.Windows.Forms.PictureBox();
            this.setting = new System.Windows.Forms.PictureBox();
            this.hotKey = new System.Windows.Forms.PictureBox();
            this.markers = new System.Windows.Forms.PictureBox();
            this.sreach = new System.Windows.Forms.PictureBox();
            this.catalogs = new System.Windows.Forms.PictureBox();
            this.books = new System.Windows.Forms.PictureBox();
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMark = new System.Windows.Forms.ToolStripMenuItem();
            this.selectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sreachItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webSreachItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentLab = new AntdUI.Label();
            this.totalLab = new AntdUI.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new AntdUI.Label();
            this.textBox = new ArashiRead.form.RichTextBoxEx();
            this.loadingPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sreach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.books)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // partitionTop
            // 
            this.partitionTop.MaximumSize = new System.Drawing.Size(628, 0);
            this.partitionTop.MinimumSize = new System.Drawing.Size(628, 0);
            this.partitionTop.Size = new System.Drawing.Size(628, 0);
            // 
            // windowBar1
            // 
            this.windowBar1.IconSvg = "";
            this.windowBar1.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.windowBar1.MaximizeBox = true;
            this.windowBar1.MinimumSize = new System.Drawing.Size(792, 26);
            this.windowBar1.Size = new System.Drawing.Size(798, 30);
            // 
            // loadingProgress
            // 
            this.loadingProgress.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loadingProgress.Text = "加载中...";
            // 
            // loadingPanel
            // 
            this.loadingPanel.Location = new System.Drawing.Point(541, 470);
            // 
            // tips
            // 
            this.tips.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.tips.Location = new System.Drawing.Point(261, 470);
            // 
            // chapterTag
            // 
            this.chapterTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chapterTag.BackColor = System.Drawing.Color.Transparent;
            this.chapterTag.BorderWidth = 0F;
            this.chapterTag.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.chapterTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.chapterTag.Location = new System.Drawing.Point(66, 468);
            this.chapterTag.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chapterTag.Name = "chapterTag";
            this.chapterTag.Size = new System.Drawing.Size(270, 26);
            this.chapterTag.TabIndex = 7;
            this.chapterTag.Text = "章节";
            this.chapterTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // readProgress
            // 
            this.readProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readProgress.Back = System.Drawing.Color.DimGray;
            this.readProgress.BackColor = System.Drawing.Color.DimGray;
            this.readProgress.Fill = System.Drawing.Color.Tomato;
            this.readProgress.ForeColor = System.Drawing.Color.GreenYellow;
            this.readProgress.Location = new System.Drawing.Point(71, 464);
            this.readProgress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.readProgress.Name = "readProgress";
            this.readProgress.Size = new System.Drawing.Size(708, 1);
            this.readProgress.TabIndex = 3;
            this.readProgress.Text = " ";
            // 
            // bookNameTag
            // 
            this.bookNameTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bookNameTag.BackColor = System.Drawing.Color.Transparent;
            this.bookNameTag.BorderWidth = 0F;
            this.bookNameTag.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.bookNameTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.bookNameTag.Location = new System.Drawing.Point(463, 468);
            this.bookNameTag.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.bookNameTag.Name = "bookNameTag";
            this.bookNameTag.Size = new System.Drawing.Size(269, 26);
            this.bookNameTag.TabIndex = 5;
            this.bookNameTag.Text = "书名";
            this.bookNameTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rateLab
            // 
            this.rateLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rateLab.BackColor = System.Drawing.Color.Transparent;
            this.rateLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rateLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.rateLab.Location = new System.Drawing.Point(732, 467);
            this.rateLab.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.rateLab.Name = "rateLab";
            this.rateLab.Size = new System.Drawing.Size(55, 26);
            this.rateLab.TabIndex = 6;
            this.rateLab.Text = "0%";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Back = System.Drawing.Color.Transparent;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.reset);
            this.panel1.Controls.Add(this.setting);
            this.panel1.Controls.Add(this.hotKey);
            this.panel1.Controls.Add(this.markers);
            this.panel1.Controls.Add(this.sreach);
            this.panel1.Controls.Add(this.catalogs);
            this.panel1.Controls.Add(this.books);
            this.panel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel1.Location = new System.Drawing.Point(1, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 440);
            this.panel1.TabIndex = 1;
            this.panel1.Text = "panel1";
            // 
            // reset
            // 
            this.reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset.Image = global::ArashiRead.Properties.Resources.icons8_restart_40;
            this.reset.Location = new System.Drawing.Point(-1, 319);
            this.reset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(53, 46);
            this.reset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.reset.TabIndex = 6;
            this.reset.TabStop = false;
            this.reset.Tag = "重新载入";
            this.reset.Click += new System.EventHandler(this.reset_Click_1);
            this.reset.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.reset.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.reset.MouseHover += new System.EventHandler(this.books_MouseHover_1);
            // 
            // setting
            // 
            this.setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setting.Image = global::ArashiRead.Properties.Resources.icons8_services_40;
            this.setting.Location = new System.Drawing.Point(-1, 266);
            this.setting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(53, 46);
            this.setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.setting.TabIndex = 5;
            this.setting.TabStop = false;
            this.setting.Tag = "设置";
            this.setting.Click += new System.EventHandler(this.setting_Click);
            this.setting.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.setting.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.setting.MouseHover += new System.EventHandler(this.books_MouseHover_1);
            // 
            // hotKey
            // 
            this.hotKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hotKey.Image = global::ArashiRead.Properties.Resources.icons8_settings_40;
            this.hotKey.Location = new System.Drawing.Point(-1, 213);
            this.hotKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hotKey.Name = "hotKey";
            this.hotKey.Size = new System.Drawing.Size(53, 46);
            this.hotKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.hotKey.TabIndex = 4;
            this.hotKey.TabStop = false;
            this.hotKey.Tag = "快捷键";
            this.hotKey.Click += new System.EventHandler(this.hotKey_Click);
            this.hotKey.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.hotKey.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.hotKey.MouseHover += new System.EventHandler(this.books_MouseHover_1);
            // 
            // markers
            // 
            this.markers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.markers.Image = global::ArashiRead.Properties.Resources.icons8_bookmark_40;
            this.markers.Location = new System.Drawing.Point(-1, 107);
            this.markers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.markers.Name = "markers";
            this.markers.Size = new System.Drawing.Size(53, 46);
            this.markers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.markers.TabIndex = 3;
            this.markers.TabStop = false;
            this.markers.Tag = "书签";
            this.markers.Click += new System.EventHandler(this.markers_Click);
            this.markers.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.markers.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.markers.MouseHover += new System.EventHandler(this.books_MouseHover_1);
            // 
            // sreach
            // 
            this.sreach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sreach.Image = global::ArashiRead.Properties.Resources.icons8_search_40;
            this.sreach.Location = new System.Drawing.Point(-1, 160);
            this.sreach.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sreach.Name = "sreach";
            this.sreach.Size = new System.Drawing.Size(53, 46);
            this.sreach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sreach.TabIndex = 2;
            this.sreach.TabStop = false;
            this.sreach.Tag = "搜索";
            this.sreach.Click += new System.EventHandler(this.sreach_Click);
            this.sreach.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.sreach.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.sreach.MouseHover += new System.EventHandler(this.books_MouseHover_1);
            // 
            // catalogs
            // 
            this.catalogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.catalogs.Image = global::ArashiRead.Properties.Resources.icons8_news_40;
            this.catalogs.Location = new System.Drawing.Point(-1, 54);
            this.catalogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.catalogs.Name = "catalogs";
            this.catalogs.Size = new System.Drawing.Size(53, 46);
            this.catalogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.catalogs.TabIndex = 1;
            this.catalogs.TabStop = false;
            this.catalogs.Tag = "章节";
            this.catalogs.Click += new System.EventHandler(this.catalogs_Click);
            this.catalogs.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.catalogs.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.catalogs.MouseHover += new System.EventHandler(this.books_MouseHover_1);
            // 
            // books
            // 
            this.books.Cursor = System.Windows.Forms.Cursors.Hand;
            this.books.Image = global::ArashiRead.Properties.Resources.icons8_book_shelf_40;
            this.books.InitialImage = global::ArashiRead.Properties.Resources.icons8_book_shelf_40;
            this.books.Location = new System.Drawing.Point(-1, 1);
            this.books.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.books.Name = "books";
            this.books.Size = new System.Drawing.Size(53, 46);
            this.books.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.books.TabIndex = 0;
            this.books.TabStop = false;
            this.books.Tag = "书架";
            this.books.Click += new System.EventHandler(this.books_Click);
            this.books.MouseEnter += new System.EventHandler(this.books_MouseEnter);
            this.books.MouseLeave += new System.EventHandler(this.books_MouseLeave);
            this.books.MouseHover += new System.EventHandler(this.books_MouseHover_1);
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
            this.addMark.Click += new System.EventHandler(this.添加书签ToolStripMenuItem_Click);
            // 
            // selectItem
            // 
            this.selectItem.Name = "selectItem";
            this.selectItem.Size = new System.Drawing.Size(136, 22);
            this.selectItem.Text = "选中文本";
            this.selectItem.Click += new System.EventHandler(this.选中文本ToolStripMenuItem_Click);
            // 
            // copyItem
            // 
            this.copyItem.Name = "copyItem";
            this.copyItem.Size = new System.Drawing.Size(136, 22);
            this.copyItem.Text = "复制";
            this.copyItem.Visible = false;
            this.copyItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
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
            this.webSreachItem.Click += new System.EventHandler(this.搜索ToolStripMenuItem_Click);
            // 
            // currentLab
            // 
            this.currentLab.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.currentLab.BackColor = System.Drawing.Color.Transparent;
            this.currentLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.currentLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.currentLab.Location = new System.Drawing.Point(348, 468);
            this.currentLab.Margin = new System.Windows.Forms.Padding(4, 3, 0, 3);
            this.currentLab.Name = "currentLab";
            this.currentLab.Size = new System.Drawing.Size(50, 26);
            this.currentLab.TabIndex = 9;
            this.currentLab.Text = "0";
            this.currentLab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalLab
            // 
            this.totalLab.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.totalLab.BackColor = System.Drawing.Color.Transparent;
            this.totalLab.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.totalLab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.totalLab.Location = new System.Drawing.Point(413, 468);
            this.totalLab.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
            this.totalLab.Name = "totalLab";
            this.totalLab.Size = new System.Drawing.Size(50, 26);
            this.totalLab.TabIndex = 10;
            this.totalLab.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(52, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 493);
            this.panel2.TabIndex = 11;
            this.panel2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.label1.Location = new System.Drawing.Point(399, 468);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "/";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.ContextMenuStrip = this.mainMenu;
            this.textBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox.HideSelection = false;
            this.textBox.Location = new System.Drawing.Point(71, 34);
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textBox.ShortcutsEnabled = false;
            this.textBox.Size = new System.Drawing.Size(708, 420);
            this.textBox.TabIndex = 18;
            this.textBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(798, 493);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.totalLab);
            this.Controls.Add(this.currentLab);
            this.Controls.Add(this.chapterTag);
            this.Controls.Add(this.rateLab);
            this.Controls.Add(this.readProgress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bookNameTag);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.MaximumSize = new System.Drawing.Size(0, 0);
            this.MinimumSize = new System.Drawing.Size(800, 494);
            this.Name = "MainForm";
            this.Opacity = 1D;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.BindingContextChanged += new System.EventHandler(this.MainForm_BindingContextChanged);
            this.Controls.SetChildIndex(this.bookNameTag, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.readProgress, 0);
            this.Controls.SetChildIndex(this.rateLab, 0);
            this.Controls.SetChildIndex(this.chapterTag, 0);
            this.Controls.SetChildIndex(this.currentLab, 0);
            this.Controls.SetChildIndex(this.totalLab, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tips, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.textBox, 0);
            this.loadingPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sreach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.books)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.Panel panel1;
        private PictureBox reset;
        private PictureBox setting;
        private PictureBox hotKey;
        private PictureBox markers;
        private PictureBox sreach;
        private PictureBox catalogs;
        private PictureBox books;
        public AntdUI.Label currentLab;
        public AntdUI.Label totalLab;
        private Panel panel2;
        public AntdUI.Label label1;
        public AntdUI.Label rateLab;
        public AntdUI.Tag chapterTag;
        public AntdUI.Tag bookNameTag;
        public AntdUI.Progress readProgress;
        private ToolStripMenuItem addMark;
        private RichTextBoxEx textBox;
        private ToolStripMenuItem selectItem;
        private ToolStripMenuItem copyItem;
        private ToolStripMenuItem webSreachItem;
        private ToolStripMenuItem sreachItem;
        public ContextMenuStrip mainMenu;
    }
}
