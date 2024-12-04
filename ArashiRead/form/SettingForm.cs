using AntdUI;
using ArashiRead.bean;
using ArashiRead.config;
using ArashiRead.constant;
using ArashiRead.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class SettingForm : ParentForm
    {
        MainForm mainForm;

        List<System.Drawing.FontFamily> families = new InstalledFontCollection().Families.ToList();

        static bool resetSize = true;
        bool isOpen = true;

        public SettingForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            RedrawFormControls(this, ConfigCache.currentColors);
        }

        private void SettingForm_Shown(object sender, EventArgs e)
        {
            // applyUpdate();
            //RedrawControls(tabPage1.Controls);
            //RedrawControls(tabPage2.Controls);
            loadColor(ConfigCache.currentColors);
            //获取系统字体(字体名必须含汉字)：
            fontFamilyCmb.Items.Clear();
            foreach (System.Drawing.FontFamily font in families)
            {
                if (Regex.IsMatch(font.Name, @"[\u4e00-\u9fa5]"))
                {
                    this.fontFamilyCmb.Items.Add(font.Name);
                    if (font.Name.Equals(ConfigCache.display.fontFamily))
                        this.fontFamilyCmb.SelectedIndex = this.fontFamilyCmb.Items.Count - 1;
                }
            }
            //设置字体
            float f = (float)ConfigCache.display.fontSize;
            System.Drawing.FontFamily fontFamily = new System.Drawing.FontFamily(ConfigCache.display.fontFamily);
            updateFont(f, fontFamily, ConfigCache.display.fontBold ? FontStyle.Bold : FontStyle.Regular);
            fontSizeslider.Value = (int)((ConfigCache.display.fontSize - 10) * 2);
            switch2.Checked = ConfigCache.display.fontBold;
            //判断主窗体尺寸
            int w = mainForm.Width, h = mainForm.Height;
            if (w == Constants.MainFormWidthMin && h == Constants.MainFormHeightMin)
            {
                sizeCmb.SelectedIndex = 0;
            }
            else if (w == Constants.MainFormWidthMedium && h == Constants.MainFormHeightMedium)
            {
                sizeCmb.SelectedIndex = 1;
            }
            else if (w == Constants.MainFormWidthMax && h == Constants.MainFormHeightMax)
            {
                sizeCmb.SelectedIndex = 2;
            }
            else
            {
                sizeCmb.Text = "自定义";
            }
            //判断是否使用了默认主题
            int i = getIndex();
            if (i == -1)
            {
                select1.SelectedValue = "自定义";
            }
            else
            {
                select1.SelectedIndex = i;
            }
            isOpen = false;
        }

        /// <summary>
        /// 获取当前主题在预置集合下标
        /// </summary>
        /// <returns></returns>
        public int getIndex()
        {
            Colors a = ConfigCache.currentColors;
            if (a.foreColor == null)
            {
                return -1;
            }
            List<ColorConfig> b = ConfigCache.presetColors;
            int index = 0;
            foreach (ColorConfig item in b)
            {
                Colors i = Colors.toColors(item);
                if (i.backColor.Equals(a.backColor)
                    && i.foreColor.Equals(a.foreColor)
                    && i.promptColor.Equals(a.promptColor)
                    && i.otherColor.Equals(a.otherColor)
                    && i.selectionColor.Equals(a.selectionColor))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }


        void loadColor(Colors colors)
        {
            input1.Text = ColorUtil.toColorStr(colors.backColor);
            input2.Text = ColorUtil.toColorStr(colors.foreColor);
            input3.Text = ColorUtil.toColorStr(colors.promptColor);
            input4.Text = ColorUtil.toColorStr(colors.selectionColor);
            input5.Text = ColorUtil.toColorStr(colors.otherColor);

            colorPicker1.Value = colors.backColor;
            colorPicker2.Value = colors.foreColor;
            colorPicker3.Value = colors.promptColor;
            colorPicker4.Value = colors.selectionColor;
            colorPicker5.Value = colors.otherColor;

        }

        private void input1_TextChanged(object sender, EventArgs e)
        {

        }

        private void input_Leave(object sender, EventArgs e)
        {
            try
            {
                Input input = (Input)sender;
                if (input.Text != null)
                {
                    Color color = ColorUtil.toColor(input.Text);
                    if (input.Name.Equals("input1"))
                    {
                        colorPicker1.Value = color;
                    }
                    if (input.Name.Equals("input2"))
                    {
                        colorPicker2.Value = color;
                    }
                    if (input.Name.Equals("input3"))
                    {
                        colorPicker3.Value = color;
                    }
                    if (input.Name.Equals("input4"))
                    {
                        colorPicker4.Value = color;
                    }
                    if (input.Name.Equals("input5"))
                    {
                        colorPicker5.Value = color;
                    }
                }
            }
            catch
            {
                showError("错误的颜色格式");
            }
        }


        private void SettingForm_Load(object sender, EventArgs e)
        {
            input1.Leave += input_Leave;
            input2.Leave += input_Leave;
            input3.Leave += input_Leave;
            input4.Leave += input_Leave;
            input5.Leave += input_Leave;
            colorPicker2.ValueChanged += colorPicker1_ValueChanged;
            colorPicker3.ValueChanged += colorPicker1_ValueChanged;
            colorPicker4.ValueChanged += colorPicker1_ValueChanged;
            colorPicker5.ValueChanged += colorPicker1_ValueChanged;
        }

        private void colorPicker1_ValueChanged(object sender, Color value)
        {
            try
            {
                ColorPicker cp = (ColorPicker)sender;
                if (cp.Value != null)
                {
                    String colorStr = ColorUtil.toColorStr(cp.Value);
                    if (cp.Name.Equals("colorPicker1"))
                    {
                        input1.Text = colorStr;
                    }
                    if (cp.Name.Equals("colorPicker2"))
                    {
                        input2.Text = colorStr;
                    }
                    if (cp.Name.Equals("colorPicker3"))
                    {
                        input3.Text = colorStr;
                    }
                    if (cp.Name.Equals("colorPicker4"))
                    {
                        input4.Text = colorStr;
                    }
                    if (cp.Name.Equals("colorPicker5"))
                    {
                        input5.Text = colorStr;
                    }
                }
            }
            catch
            {
                showError("错误的颜色格式");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetSize = false;
            loadColor(ConfigCache.currentColors);
            mainForm.setFormSize(ConfigCache.display.mainFormWeight, ConfigCache.display.mainFormHeight);
        }

        private void select1_SelectedIndexChanged(object sender, int value)
        {
            if (isOpen)
            {
                return;
            }
            ColorConfig colorConfig = ConfigCache.presetColors.Find(x => x.index == value);
            if (colorConfig == null)
            {
                showError("未定义的颜色配置");
                return;
            }
            Colors colors = Colors.toColors(colorConfig);
            loadColor(colors);
            RedrawControls(tabPage1.Controls, colors);
            RedrawControls(tabPage2.Controls, colors);
            RedrawFormControls(this, colors);
            showSuccess("加载预置配色成功");
            showChangeBox.BackColor = colors.backColor;
        }

        /// <summary>
        /// 保存并应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            ConfigCache.display.backColor = ColorUtil.toColorStr(colorPicker1.Value);
            ConfigCache.display.foreColor = ColorUtil.toColorStr(colorPicker2.Value);
            ConfigCache.display.promptColor = ColorUtil.toColorStr(colorPicker3.Value);
            ConfigCache.display.selectionColor = ColorUtil.toColorStr(colorPicker4.Value);
            ConfigCache.display.otherColor = ColorUtil.toColorStr(colorPicker5.Value);

            ConfigCache.currentColors.backColor = colorPicker1.Value;
            ConfigCache.currentColors.foreColor = colorPicker2.Value;
            ConfigCache.currentColors.promptColor = colorPicker3.Value;
            ConfigCache.currentColors.selectionColor = colorPicker4.Value;
            ConfigCache.currentColors.otherColor = colorPicker5.Value;

            ConfigCache.display.fontFamily = fontFamilyCmb.SelectedValue.ToString();
            ConfigCache.display.fontSize = float.Parse(fontSizeLab.Text);
            ConfigCache.display.fontBold = switch2.Checked;
            //主窗体设置颜色
            RedrawFormControls(mainForm, ConfigCache.currentColors);
            //经测试，右上角按钮无法重置颜色


            //窗口大小
            int newWidth = (int)widthInput.Value;
            int newHeight = (int)heigthInput.Value;
            if (newWidth != ConfigCache.display.mainFormWeight || newHeight != ConfigCache.display.mainFormHeight)
            {
                ConfigCache.display.setSize(newWidth, newHeight);
            }
            //保存配置
            ConfigCache.saveDisplay();
            //重新加载 TODO 此处需判断是否需要重新加载 2. 判断是否为自定义主题
            mainForm.loadLastReadBook();
            RedrawControlCMS(mainForm.mainMenu);
            resetSize = false;
            this.Close();
        }

        /// <summary>
        /// 字体风格下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void fontStyleCmb_SelectedValueChanged(object sender, object value)
        {
            System.Drawing.FontFamily fontFamily = families.Find(x => x.Name.Equals(value));
            if (fontFamily == null)
            {
                showError("该字体不存在");
            }
            else
            {
                updateFont(null, fontFamily, null);
            }

        }


        /// <summary>
        /// 修改字体大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void fontSizeslider_ValueChanged(object sender, int value)
        {
            float f = (float)value / 2f + 10f;
            updateFont(f, null, null);

        }

        /// <summary>
        /// 修改字体
        /// </summary>
        /// <param name="f"></param>
        /// <param name="fontFamily"></param>
        /// <param name="style"></param>
        private void updateFont(float? f, System.Drawing.FontFamily fontFamily, FontStyle? style)
        {
            Font font = showChangeBox.Font;
            if (f == null)
            {
                f = font.Size;
            }
            if (fontFamily == null)
                fontFamily = font.FontFamily;
            if (style == null)
                style = font.Style;


            showChangeBox.Font = new Font(fontFamily, f.Value, style.Value);
            fontSizeLab.Text = showChangeBox.Font.Size + "";
            chapterLab.Font = new Font(fontFamily, f.Value + 3f, FontStyle.Bold);
        }





        /// <summary>
        /// 主窗口尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void sizeCmb_SelectedIndexChanged(object sender, int value)
        {
            if (value == 0)
            {
                mainForm.setFormSize(Constants.MainFormWidthMin, Constants.MainFormHeightMin);
            }
            else if (value == 1)
            {
                mainForm.setFormSize(Constants.MainFormWidthMedium, Constants.MainFormHeightMedium);
            }
            else if (value == 2)
            {
                mainForm.setFormSize(Constants.MainFormWidthMax, Constants.MainFormHeightMax);
            }
            widthInput.Value = mainForm.Width;
            heigthInput.Value = mainForm.Height;

        }

        /// <summary>
        /// 关闭前检查窗口尺寸是否需要恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (resetSize)
            {
                mainForm.setFormSize(ConfigCache.display.mainFormWeight, ConfigCache.display.mainFormHeight);
            }
        }
    }
}
