using ArashiRead.bean;
using ArashiRead.cache;
using ArashiRead.config;
using ArashiRead.constant;
using ArashiRead.form;
using ArashiRead.model;
using ArashiRead.service;
using ArashiRead.util;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace ArashiRead
{
    public partial class MainForm : ParentForm
    {
        public MainForm()
        {
            InitializeComponent();
            partitionTop.Visible = false;
            RedrawFormControls(this, ConfigCache.currentColors);
            setFormSize(ConfigCache.display.mainFormWeight, ConfigCache.display.mainFormHeight);
            RedrawControlCMS(mainMenu);
            textBox.bReadOnly = true;
        }


        /// <summary>
        /// 窗体关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BookUtil.SaveLastRead();
            ConfigCache.saveDisplay();
            ConfigCache.saveHotKey();
            ConfigCache.saveBooks();
            ConfigCache.saveMarkers();
        }





        /// <summary>
        /// 显示文本
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="chapterNo">章节号</param>
        public void showContent(int? page, int? chapterNo, int? realLineNo)
        {
            ReadCache.chapterStart = -1;
            textBox.SelectedText = "";
            int pageSize = ReadCache.GetDisplayRowCount(textBox);
            Tuple<String, ContentRow> tuple;
            //优先取行号
            if (page != null)
            {
                int start = ReadCache.book.rowNo + pageSize * page.Value;
                int end = start + pageSize;
                int total = ReadCache.rows.Count;
                if (start >= total)
                {
                    showInfo("已阅读到书籍末尾");
                    return;
                }
                else if (start >= 0 && end < total)
                {
                    ReadCache.book.rowNo = start;
                    tuple = BookUtil.getContentByRowNo(ReadCache.book.rowNo, pageSize);
                }
                else if (end >= total)
                {
                    showInfo("已阅读到书籍末尾");
                    ReadCache.book.rowNo = start;
                    int remainder = ReadCache.rows.Count - start;
                    tuple = BookUtil.getContentByRowNo(ReadCache.book.rowNo, remainder);
                }
                else
                {
                    tuple = BookUtil.getContentByRowNo(0, pageSize);
                    showInfo("已阅读到书籍开始");
                    ReadCache.book.rowNo = 0;
                }
            }
            else
            {
                tuple = BookUtil.getContentByChapter(chapterNo.Value, realLineNo, pageSize);
                if (tuple == null)
                {
                    showError("章节跳转失败");
                }
            }

            if (tuple != null)
            {
                textBox.Text = tuple.Item1.EndsWith("\n") ?
                    tuple.Item1.Substring(0, tuple.Item1.Length - 1) :
                    tuple.Item1;
                //阅读进度
                decimal rate = decimal.Divide(tuple.Item2.index, ReadCache.rows.Count);
                ReadCache.book.readPercent = rate;
                rateLab.Text = CommonUtil.toRateStr(rate);
                ReadCache.book.readRate = rateLab.Text;
                //章节
                ReadCache.book.lastReadChapteNo = tuple.Item2.chapterNo;
                String chapter = tuple.Item2.chapterName;
                this.chapterTag.Text = chapter;
                ReadCache.book.lastReadChapter = chapter;
                //章节高亮
                if (ReadCache.chapterStart >= 0)
                {
                    textBox.SelectionStart = ReadCache.chapterStart;
                    //得到字符串的长度
                    textBox.SelectionLength = chapter.Length;
                    //然后就可以改变这个字符串的颜色
                    //textBox.SelectionColor = ConfigCache.getOtherColor();
                    textBox.SelectionFont = new Font(textBox.Font.FontFamily, textBox.Font.Size + 3, FontStyle.Bold);
                    textBox.SelectionStart = 0;
                    textBox.SelectionLength = 0;
                }
                //当前页数
                int s = ReadCache.book.rowNo + 1;
                int now = s % pageSize == 0 ? s / pageSize : s / pageSize + 1;
                this.currentLab.Text = now + "";

                //总页数
                int s1 = ReadCache.rows.Count + 1;
                int totalPage = s1 % pageSize == 0 ? s1 / pageSize : s1 / pageSize + 1;
                this.totalLab.Text = totalPage + "";
            }
        }

        /// <summary>
        /// 异步打开书籍
        /// </summary>
        /// <param name="url"></param>
        public void ansycOpenBook(String url, int? rowNo, int? chapterNo, int? realLineNo)
        {
            asyncWork(() => openBook(url, rowNo, chapterNo, realLineNo));
        }


        /// <summary>
        /// 异步打开最后一次阅读的书籍
        /// </summary>
        public void loadLastReadBook()
        {
            asyncWork(() => openBook("", null, null, null));
        }

        /// <summary>
        /// 打开一本书
        /// </summary>
        public bool openBook(String url, int? rowNo, int? chapterNo, int? realLineNo)
        {
            if (ConfigCache.books != null && ConfigCache.books.Count > 0)
            {
                Book config = CommonUtil.isBlank(url) ? ConfigCache.books[0] : ConfigCache.books.Find(z => z.url.Equals(url));
                if (config == null)
                {
                    showInfo("书架中没有任何书籍");
                    return false;
                }
                else if (!CommonUtil.isExist(config.url))
                {
                    showError("该书籍已移动或已删除，无法打开");
                    return false;
                }
                else if (CommonUtil.FileIsBlank(config.url))
                {
                    showError("该书籍为空");
                    return false;
                }
                else
                {
                    //清除搜索结果
                    ReadCache.lastSelectIndex = -1;
                    ReadCache.searchResults.Clear();
                    ReadCache.sreachTerm = "";

                    this.bookNameTag.Text = "";
                    this.chapterTag.Text = "";
                    this.currentLab.Text = "0";
                    this.totalLab.Text = "0";
                    this.rateLab.Text = "0%";
                    //重新计算每页显示行数
                    ReadCache.displayRowCount = 0;
                    ReadCache.rows.Clear();
                    //当前阅读书籍置换到首位
                    if (ConfigCache.books.IndexOf(config) != 0)
                    {
                        ConfigCache.books.Remove(config);
                        ConfigCache.books.Insert(0, config);
                    }
                    //缓存书籍
                    BookUtil.CacheBook(textBox, config.url);
                    //缓存文本行
                    BookUtil.cacheRows(textBox, ReadCache.book.chapters, (x, y) =>
                    {
                        loadingProgress.Value = ((float)x);
                        loadingProgress.Text = y;
                        loadingProgress.Refresh();
                    });
                    this.bookNameTag.Text = ReadCache.book.name;
                    ReadCache.book.totalRowCount = ReadCache.rows.Count;
                    //判断总条数是否一致
                    if (ReadCache.rows.Count == config.totalRowCount)
                    {
                        ReadCache.book.rowNo = rowNo != null ? rowNo.Value : config.rowNo;
                        showContent(0, null, null);
                    }
                    else
                    {
                        config.totalRowCount = ReadCache.rows.Count;
                        chapterNo = chapterNo == null ? config.lastReadChapteNo : chapterNo.Value;
                        realLineNo = realLineNo != null ? realLineNo.Value : config.realLineNo;
                        showContent(null, chapterNo, realLineNo);
                    }
                }
            }
            textBox.Visible = true;
            panel2.BringToFront();
            panel2.Show();
            return true;
        }


        /// <summary>
        /// 窗体绑定控件时 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_BindingContextChanged(object sender, EventArgs e)
        {
            loadingPanel.Visible = true;
            loadingPanel.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// 窗体绘制完成后 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            loadLastReadBook();
        }

        /// <summary>
        /// 书架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void books_Click(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
            BookshelfForm open = new BookshelfForm(this);
            open.ShowDialog(this);
        }

        /// <summary>
        /// 章节列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catalogs_Click(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
            ChapterForm chapter = new ChapterForm(this);
            chapter.ShowDialog(this);
        }

        /// <summary>
        /// 书签列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void markers_Click(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
            MarkForm markForm = new MarkForm(this);
            markForm.ShowDialog(this);
        }
        /// <summary>
        /// 全文查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sreach_Click(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
            FullTextSreachForm fullTextSreachForm = new FullTextSreachForm(this);
            fullTextSreachForm.ShowDialog(this);
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotKey_Click(object sender, EventArgs e)
        {
            HotKeyForm keyForm = new HotKeyForm(this);
            keyForm.ShowDialog(this);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setting_Click(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
            SettingForm keyForm = new SettingForm(this);
            keyForm.ShowDialog(this);
        }

        /// <summary>
        /// 重新载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reset_Click_1(object sender, EventArgs e)
        {
            if (ReadCache.book != null)
            {
                Book book = ReadCache.book;
                ansycOpenBook(book.url, book.rowNo, book.lastReadChapteNo, book.realLineNo);
            }
        }

        private void 添加书签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book bookCache = ReadCache.book;
            if (bookCache == null || !CommonUtil.isExist(bookCache.url)) return;
            Book mark = new Book();
            mark.name = bookCache.name;
            mark.url = bookCache.url;
            mark.size = bookCache.size;
            mark.readPercent = bookCache.readPercent;
            mark.readRate = bookCache.readRate;
            mark.lastReadChapteNo = bookCache.lastReadChapteNo;
            mark.lastReadChapter = bookCache.lastReadChapter;
            mark.lastReadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            mark.rowNo = bookCache.rowNo;
            mark.realLineNo = bookCache.realLineNo;
            mark.totalRowCount = bookCache.totalRowCount;
            ConfigCache.markers.Add(mark);
            showSuccess("书签添加成功");
        }

        /// <summary>
        /// 高亮显示指定文字
        /// </summary>
        /// <param name="value"></param>
        public void highlight(String str)
        {
            if (CommonUtil.isBlank(str)) return;
            int startIndex = 0;
            while ((startIndex = textBox.Find(str, startIndex + 1, RichTextBoxFinds.None)) > -1)
            {
                textBox.SelectionStart = startIndex;
                //得到字符串的长度
                textBox.SelectionLength = str.Length;
                //然后就可以改变这个字符串的颜色
                textBox.SelectionColor = ConfigCache.currentColors.promptColor;
            }
        }

        /// <summary>
        /// 设置窗体尺寸
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void setFormSize(int? width, int? height)
        {
            if (width != null && height != null && width >= Constants.MainFormWidthMin && height >= Constants.MainFormHeightMin)
            {
                int w = this.Width;
                int h = this.Height;
                this.Width = width.Value; this.Height = height.Value;
                int x = this.Location.X - (width.Value - w) / 2;
                int y = this.Location.Y - (height.Value - h) / 2;
                if (x >= 0 && y >= 0)
                {

                    this.Location = new Point(x, y);
                }
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            int w = this.Width, h = this.Height;
            //新的尺寸大于最小尺寸、且尺寸与缓存中的尺寸不一致
            if (w >= Constants.MainFormWidthMin && h >= Constants.MainFormHeightMin
                && (w != ConfigCache.display.mainFormWeight || h != ConfigCache.display.mainFormHeight))
            {

                if (w == ConfigCache.display.mainFormWeight)
                {
                    //只改变高度
                    ReadCache.displayRowCount = ReadCache.calcDisplayRowCount(textBox);
                    showContent(0, null, null);
                    textBox.Show();
                }
                else
                {
                    showInfo("宽度改变,重新载入书籍");
                    loadLastReadBook();
                }
                ConfigCache.display.setSize(w, h);
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
        }

        private void 搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 选中文本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;


            if (item.Text.Equals("选中文本"))
            {
                item.Text = "关闭选中";
                addMark.Visible = false;
                copyItem.Visible = true;
                sreachItem.Visible = true;
                webSreachItem.Visible = true;
                textBox.bReadOnly = false;
                textBox.SelectionLength = 0;
                textBox.Cursor = Cursors.IBeam;
                textBox.Focus();
            }
            else
            {
                item.Text = "选中文本";
                addMark.Visible = true;
                copyItem.Visible = false;
                sreachItem.Visible = false;
                webSreachItem.Visible = false;
                textBox.SelectedText = "";
                textBox.SelectionStart = textBox.Text.Length - 10;
                textBox.SelectionLength = 0;
                textBox.bReadOnly = true;
                textBox.Cursor = Cursors.Default;
                // input1.Focus();
                String s = textBox.Text;
                textBox.Clear();
                textBox.Text = s;
            }
        }



        /// <summary>
        /// 鼠标悬浮提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        System.Windows.Forms.ToolTip toolTip;

        public void showTip(Control sender)
        {
            if (toolTip != null)
                toolTip.Dispose();
            toolTip = new System.Windows.Forms.ToolTip();
            // 设置显示样式
            toolTip.AutoPopDelay = 2000;//提示信息的可见时间
            toolTip.InitialDelay = 0;//事件触发多久后出现提示
            toolTip.ReshowDelay = 0;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip.ShowAlways = true;//是否显示提示框
            toolTip.ForeColor = ConfigCache.currentColors.foreColor;
            //  设置伴随的对象.
            toolTip.SetToolTip(sender, sender.Tag.ToString());//设置提示按钮和提示内容
        }



        private void books_MouseEnter(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.BackColor = ConfigCache.currentColors.promptColor;
            p.Left--;
        }

        private void books_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Transparent;
            ((PictureBox)sender).Left++;
        }

        private void books_MouseHover_1(object sender, EventArgs e)
        {
            showTip((Control)sender);
        }
    }
}
