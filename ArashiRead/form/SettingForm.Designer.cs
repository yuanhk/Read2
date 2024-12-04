namespace ArashiRead.form
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.chapterLab = new System.Windows.Forms.Label();
            this.showChangeBox = new System.Windows.Forms.RichTextBox();
            this.sizeCmb = new AntdUI.Select();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fontFamilyCmb = new AntdUI.Select();
            this.label5 = new System.Windows.Forms.Label();
            this.select1 = new AntdUI.Select();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.colorPicker1 = new AntdUI.ColorPicker();
            this.colorPicker2 = new AntdUI.ColorPicker();
            this.colorPicker3 = new AntdUI.ColorPicker();
            this.colorPicker4 = new AntdUI.ColorPicker();
            this.colorPicker5 = new AntdUI.ColorPicker();
            this.label11 = new System.Windows.Forms.Label();
            this.switch1 = new AntdUI.Switch();
            this.label12 = new System.Windows.Forms.Label();
            this.input1 = new AntdUI.Input();
            this.input2 = new AntdUI.Input();
            this.input3 = new AntdUI.Input();
            this.input4 = new AntdUI.Input();
            this.input5 = new AntdUI.Input();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.switch2 = new AntdUI.Switch();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new AntdUI.Label();
            this.fontSizeLab = new AntdUI.Label();
            this.slider1 = new AntdUI.Slider();
            this.fontSizeslider = new AntdUI.Slider();
            this.tabs1 = new AntdUI.Tabs();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new AntdUI.Button();
            this.button4 = new AntdUI.Button();
            this.widthInput = new AntdUI.InputNumber();
            this.heigthInput = new AntdUI.InputNumber();
            this.loadingPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabs1.SuspendLayout();
            this.SuspendLayout();
            // 
            // partitionTop
            // 
            this.partitionTop.MaximumSize = new System.Drawing.Size(860, 1);
            this.partitionTop.MinimumSize = new System.Drawing.Size(860, 1);
            this.partitionTop.Size = new System.Drawing.Size(860, 1);
            // 
            // windowBar1
            // 
            this.windowBar1.Size = new System.Drawing.Size(878, 26);
            this.windowBar1.Text = "设置";
            // 
            // loadingPanel
            // 
            this.loadingPanel.Controls.Add(this.heigthInput);
            this.loadingPanel.Location = new System.Drawing.Point(698, 530);
            this.loadingPanel.Controls.SetChildIndex(this.loadingProgress, 0);
            this.loadingPanel.Controls.SetChildIndex(this.heigthInput, 0);
            // 
            // tips
            // 
            this.tips.Location = new System.Drawing.Point(608, 530);
            // 
            // chapterLab
            // 
            this.chapterLab.AutoSize = true;
            this.chapterLab.BackColor = System.Drawing.Color.Transparent;
            this.chapterLab.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chapterLab.Location = new System.Drawing.Point(14, 36);
            this.chapterLab.Name = "chapterLab";
            this.chapterLab.Size = new System.Drawing.Size(143, 21);
            this.chapterLab.TabIndex = 120;
            this.chapterLab.Text = "第一章 陨落的天才";
            // 
            // showChangeBox
            // 
            this.showChangeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showChangeBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showChangeBox.Location = new System.Drawing.Point(16, 71);
            this.showChangeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showChangeBox.Name = "showChangeBox";
            this.showChangeBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.showChangeBox.Size = new System.Drawing.Size(538, 465);
            this.showChangeBox.TabIndex = 119;
            this.showChangeBox.Text = resources.GetString("showChangeBox.Text");
            // 
            // sizeCmb
            // 
            this.sizeCmb.Items.AddRange(new object[] {
            "小",
            "中",
            "大"});
            this.sizeCmb.Location = new System.Drawing.Point(95, 21);
            this.sizeCmb.Name = "sizeCmb";
            this.sizeCmb.PrefixText = "";
            this.sizeCmb.Radius = 2;
            this.sizeCmb.Size = new System.Drawing.Size(151, 35);
            this.sizeCmb.TabIndex = 127;
            this.sizeCmb.Text = "自定义";
            this.sizeCmb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeCmb.SelectedIndexChanged += new AntdUI.IntEventHandler(this.sizeCmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 126;
            this.label1.Text = "窗口大小";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(9, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 117;
            this.label8.Text = "字体样式";
            // 
            // fontFamilyCmb
            // 
            this.fontFamilyCmb.Items.AddRange(new object[] {
            "纯白",
            "藏青",
            "IDEA"});
            this.fontFamilyCmb.Location = new System.Drawing.Point(95, 65);
            this.fontFamilyCmb.Name = "fontFamilyCmb";
            this.fontFamilyCmb.PrefixText = "";
            this.fontFamilyCmb.Radius = 2;
            this.fontFamilyCmb.Size = new System.Drawing.Size(151, 35);
            this.fontFamilyCmb.TabIndex = 118;
            this.fontFamilyCmb.Text = "微软雅黑";
            this.fontFamilyCmb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fontFamilyCmb.SelectedValueChanged += new AntdUI.ObjectNEventHandler(this.fontStyleCmb_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(9, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 119;
            this.label5.Text = "字体大小";
            // 
            // select1
            // 
            this.select1.Items.AddRange(new object[] {
            "纯白",
            "藏青",
            "IDEA"});
            this.select1.Location = new System.Drawing.Point(89, 14);
            this.select1.Name = "select1";
            this.select1.PrefixText = "";
            this.select1.Radius = 2;
            this.select1.Size = new System.Drawing.Size(195, 35);
            this.select1.TabIndex = 114;
            this.select1.Text = " ";
            this.select1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.select1.SelectedIndexChanged += new AntdUI.IntEventHandler(this.select1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(181)))), ((int)(((byte)(182)))));
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 127;
            this.label2.Text = "主题选择";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(8, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 128;
            this.label4.Text = "字体颜色";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 130;
            this.label3.Text = "背景颜色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(8, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 136;
            this.label6.Text = "选中颜色";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(10, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 134;
            this.label7.Text = "其他颜色";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(8, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 133;
            this.label10.Text = "提示颜色";
            // 
            // colorPicker1
            // 
            this.colorPicker1.Location = new System.Drawing.Point(227, 61);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.Radius = 2;
            this.colorPicker1.Size = new System.Drawing.Size(57, 35);
            this.colorPicker1.TabIndex = 138;
            this.colorPicker1.Text = "colorPicker1";
            this.colorPicker1.Value = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.colorPicker1.ValueChanged += new AntdUI.ColorEventHandler(this.colorPicker1_ValueChanged);
            // 
            // colorPicker2
            // 
            this.colorPicker2.Location = new System.Drawing.Point(227, 108);
            this.colorPicker2.Name = "colorPicker2";
            this.colorPicker2.Radius = 2;
            this.colorPicker2.Size = new System.Drawing.Size(57, 35);
            this.colorPicker2.TabIndex = 139;
            this.colorPicker2.Text = "colorPicker2";
            this.colorPicker2.Value = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            // 
            // colorPicker3
            // 
            this.colorPicker3.Location = new System.Drawing.Point(227, 155);
            this.colorPicker3.Name = "colorPicker3";
            this.colorPicker3.Radius = 2;
            this.colorPicker3.Size = new System.Drawing.Size(57, 35);
            this.colorPicker3.TabIndex = 140;
            this.colorPicker3.Text = "colorPicker3";
            this.colorPicker3.Value = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            // 
            // colorPicker4
            // 
            this.colorPicker4.Location = new System.Drawing.Point(227, 202);
            this.colorPicker4.Name = "colorPicker4";
            this.colorPicker4.Radius = 2;
            this.colorPicker4.Size = new System.Drawing.Size(57, 35);
            this.colorPicker4.TabIndex = 141;
            this.colorPicker4.Text = "colorPicker4";
            this.colorPicker4.Value = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            // 
            // colorPicker5
            // 
            this.colorPicker5.Location = new System.Drawing.Point(227, 249);
            this.colorPicker5.Name = "colorPicker5";
            this.colorPicker5.Radius = 2;
            this.colorPicker5.Size = new System.Drawing.Size(57, 35);
            this.colorPicker5.TabIndex = 142;
            this.colorPicker5.Text = "colorPicker5";
            this.colorPicker5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(9, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 20);
            this.label11.TabIndex = 128;
            this.label11.Text = "窗体非激活状态时自动隐藏";
            // 
            // switch1
            // 
            this.switch1.Location = new System.Drawing.Point(197, 245);
            this.switch1.Name = "switch1";
            this.switch1.Size = new System.Drawing.Size(49, 23);
            this.switch1.TabIndex = 129;
            this.switch1.Text = "switch1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(9, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 130;
            this.label12.Text = "行文间距";
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(89, 61);
            this.input1.Name = "input1";
            this.input1.Radius = 2;
            this.input1.Size = new System.Drawing.Size(142, 35);
            this.input1.TabIndex = 143;
            this.input1.Text = "input1";
            this.input1.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(89, 108);
            this.input2.Name = "input2";
            this.input2.Radius = 2;
            this.input2.Size = new System.Drawing.Size(142, 35);
            this.input2.TabIndex = 144;
            this.input2.Text = "input2";
            // 
            // input3
            // 
            this.input3.Location = new System.Drawing.Point(89, 155);
            this.input3.Name = "input3";
            this.input3.Radius = 2;
            this.input3.Size = new System.Drawing.Size(142, 35);
            this.input3.TabIndex = 145;
            this.input3.Text = "input3";
            // 
            // input4
            // 
            this.input4.Location = new System.Drawing.Point(89, 202);
            this.input4.Name = "input4";
            this.input4.Radius = 2;
            this.input4.Size = new System.Drawing.Size(142, 35);
            this.input4.TabIndex = 146;
            this.input4.Text = "input4";
            // 
            // input5
            // 
            this.input5.Location = new System.Drawing.Point(89, 249);
            this.input5.Name = "input5";
            this.input5.Radius = 2;
            this.input5.Size = new System.Drawing.Size(142, 35);
            this.input5.TabIndex = 147;
            this.input5.Text = "input5";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.input5);
            this.tabPage2.Controls.Add(this.input4);
            this.tabPage2.Controls.Add(this.input3);
            this.tabPage2.Controls.Add(this.input2);
            this.tabPage2.Controls.Add(this.input1);
            this.tabPage2.Controls.Add(this.colorPicker5);
            this.tabPage2.Controls.Add(this.colorPicker4);
            this.tabPage2.Controls.Add(this.colorPicker3);
            this.tabPage2.Controls.Add(this.colorPicker2);
            this.tabPage2.Controls.Add(this.colorPicker1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.select1);
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(295, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主题设置    ";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.switch2);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.fontSizeLab);
            this.tabPage1.Controls.Add(this.slider1);
            this.tabPage1.Controls.Add(this.fontSizeslider);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.switch1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.sizeCmb);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.fontFamilyCmb);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(295, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "阅读设置  ";
            // 
            // switch2
            // 
            this.switch2.BackColor = System.Drawing.Color.Transparent;
            this.switch2.ForeColor = System.Drawing.Color.White;
            this.switch2.Location = new System.Drawing.Point(95, 115);
            this.switch2.Name = "switch2";
            this.switch2.Size = new System.Drawing.Size(151, 23);
            this.switch2.TabIndex = 138;
            this.switch2.Text = "switch2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(9, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 137;
            this.label9.Text = "字体加粗";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(254, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 23);
            this.label14.TabIndex = 136;
            this.label14.Text = "16";
            // 
            // fontSizeLab
            // 
            this.fontSizeLab.Location = new System.Drawing.Point(252, 159);
            this.fontSizeLab.Name = "fontSizeLab";
            this.fontSizeLab.Size = new System.Drawing.Size(37, 23);
            this.fontSizeLab.TabIndex = 135;
            this.fontSizeLab.Text = "10.5";
            // 
            // slider1
            // 
            this.slider1.DotSize = 10;
            this.slider1.DotSizeActive = 15;
            this.slider1.Fill = System.Drawing.Color.Aqua;
            this.slider1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.slider1.LineSize = 2;
            this.slider1.Location = new System.Drawing.Point(91, 197);
            this.slider1.MaxValue = 18;
            this.slider1.MinValue = 10;
            this.slider1.Name = "slider1";
            this.slider1.ShowValue = true;
            this.slider1.Size = new System.Drawing.Size(151, 35);
            this.slider1.TabIndex = 134;
            this.slider1.Value = 16;
            // 
            // fontSizeslider
            // 
            this.fontSizeslider.Dots = new int[0];
            this.fontSizeslider.DotSize = 10;
            this.fontSizeslider.DotSizeActive = 15;
            this.fontSizeslider.Fill = System.Drawing.Color.RosyBrown;
            this.fontSizeslider.ForeColor = System.Drawing.Color.RosyBrown;
            this.fontSizeslider.LineSize = 2;
            this.fontSizeslider.Location = new System.Drawing.Point(91, 153);
            this.fontSizeslider.Margin = new System.Windows.Forms.Padding(0);
            this.fontSizeslider.MaxValue = 16;
            this.fontSizeslider.Name = "fontSizeslider";
            this.fontSizeslider.Size = new System.Drawing.Size(151, 35);
            this.fontSizeslider.TabIndex = 133;
            this.fontSizeslider.ValueChanged += new AntdUI.IntEventHandler(this.fontSizeslider_ValueChanged);
            // 
            // tabs1
            // 
            this.tabs1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabs1.BadgeBack = System.Drawing.SystemColors.ActiveCaption;
            this.tabs1.BarBack = System.Drawing.SystemColors.AppWorkspace;
            this.tabs1.BarBackSize = 0F;
            this.tabs1.BarSize = 1F;
            this.tabs1.Controls.Add(this.tabPage1);
            this.tabs1.Controls.Add(this.tabPage2);
            this.tabs1.Fill = System.Drawing.Color.SkyBlue;
            this.tabs1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabs1.ItemSize = new System.Drawing.Size(72, 22);
            this.tabs1.Location = new System.Drawing.Point(575, 45);
            this.tabs1.Margin = new System.Windows.Forms.Padding(0);
            this.tabs1.Multiline = true;
            this.tabs1.Name = "tabs1";
            this.tabs1.Padding = new System.Drawing.Point(0, 0);
            this.tabs1.SelectedIndex = 0;
            this.tabs1.Size = new System.Drawing.Size(303, 330);
            this.tabs1.TabIndex = 129;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(562, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 485);
            this.panel1.TabIndex = 130;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.DefaultBack = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(590, 390);
            this.button3.Name = "button3";
            this.button3.Radius = 2;
            this.button3.Size = new System.Drawing.Size(118, 35);
            this.button3.TabIndex = 131;
            this.button3.Text = "放弃更改";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Ghost = true;
            this.button4.Location = new System.Drawing.Point(736, 390);
            this.button4.Name = "button4";
            this.button4.Radius = 2;
            this.button4.Size = new System.Drawing.Size(118, 35);
            this.button4.TabIndex = 132;
            this.button4.Text = "保存并应用";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // widthInput
            // 
            this.widthInput.Location = new System.Drawing.Point(746, 504);
            this.widthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(75, 23);
            this.widthInput.TabIndex = 133;
            this.widthInput.Text = "0";
            this.widthInput.Visible = false;
            // 
            // heigthInput
            // 
            this.heigthInput.Location = new System.Drawing.Point(48, 0);
            this.heigthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heigthInput.Name = "heigthInput";
            this.heigthInput.Size = new System.Drawing.Size(75, 23);
            this.heigthInput.TabIndex = 134;
            this.heigthInput.Text = "0";
            this.heigthInput.Visible = false;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 549);
            this.Controls.Add(this.widthInput);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showChangeBox);
            this.Controls.Add(this.chapterLab);
            this.Controls.Add(this.tabs1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(880, 550);
            this.MinimumSize = new System.Drawing.Size(880, 550);
            this.Mode = AntdUI.TAMode.Light;
            this.Name = "SettingForm";
            this.Opacity = 0.98D;
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.Shown += new System.EventHandler(this.SettingForm_Shown);
            this.Controls.SetChildIndex(this.windowBar1, 0);
            this.Controls.SetChildIndex(this.partitionTop, 0);
            this.Controls.SetChildIndex(this.loadingPanel, 0);
            this.Controls.SetChildIndex(this.tips, 0);
            this.Controls.SetChildIndex(this.tabs1, 0);
            this.Controls.SetChildIndex(this.chapterLab, 0);
            this.Controls.SetChildIndex(this.showChangeBox, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.widthInput, 0);
            this.loadingPanel.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabs1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label chapterLab;
        public System.Windows.Forms.RichTextBox showChangeBox;
        private AntdUI.Select sizeCmb;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label8;
        private AntdUI.Select fontFamilyCmb;
        public System.Windows.Forms.Label label5;
        private AntdUI.Select select1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        private AntdUI.ColorPicker colorPicker1;
        private AntdUI.ColorPicker colorPicker5;
        private AntdUI.ColorPicker colorPicker4;
        private AntdUI.ColorPicker colorPicker3;
        private AntdUI.ColorPicker colorPicker2;
        public System.Windows.Forms.Label label12;
        private AntdUI.Switch switch1;
        public System.Windows.Forms.Label label11;
        private AntdUI.Input input5;
        private AntdUI.Input input4;
        private AntdUI.Input input3;
        private AntdUI.Input input2;
        private AntdUI.Input input1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private AntdUI.Tabs tabs1;
        private System.Windows.Forms.Panel panel1;
        private AntdUI.Button button3;
        private AntdUI.Button button4;
        private AntdUI.Slider fontSizeslider;
        private AntdUI.Slider slider1;
        private AntdUI.Label label14;
        private AntdUI.Label fontSizeLab;
        public System.Windows.Forms.Label label9;
        private AntdUI.Switch switch2;
        private AntdUI.InputNumber heigthInput;
        private AntdUI.InputNumber widthInput;
    }
}