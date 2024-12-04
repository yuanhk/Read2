using AntdUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.bean;
using WindRead.cache;
using WindRead.constants;
using WindRead.Resources;
using WindRead.util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindRead.form
{
    public partial class MainForm : ParentForm
    {
        SubForm subForm;
        public MainForm()
        {
            //取消线程间调用的错误捕获
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setFormSize(Constants.MainFormWidthMax, Constants.MainFormHeightMax);
        }


        private void menuPanel_Enter(object sender, EventArgs e)
        {
            if (subForm == null)
            {
                subForm = new SubForm(this);
            }
            AntdUI.Panel panel = subForm.menuPanel;
            panel.Height = this.Height;
            Drawer.Config config = new Drawer.Config(this, panel);
            config.Dispose = false;
            config.Padding = 0;
            config.Align = TAlignMini.Left;
            config.open();
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
                    this.showInfo("书架中没有任何书籍");
                    return false;
                }
                else if (!CommonUtil.isExist(config.url))
                {
                    this.showError("该书籍已移动或已删除，无法打开");
                    return false;
                }
                else if (CommonUtil.FileIsBlank(config.url))
                {
                    this.showError("该书籍为空");
                    return false;
                }
                else
                {
                    showLoading();
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
                    Debug.WriteLine(DateTime.Now);
                    //缓存书籍
                    BookUtil.CacheBook(textBox, config.url);
                    //缓存文本行
                    BookUtil.cacheRows(textBox, ReadCache.book.chapters, (x, y) =>
                    {
                        loadingProgress.Value = (float)x;
                        loadingProgress.Text = y;
                        loadingProgress.Refresh();
                    });
                    Debug.WriteLine(DateTime.Now);
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
            hideLoading();
            return true;
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
            textBox.SelectionStart = 0;
            textBox.SelectionLength = 0;
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
                    this.showInfo("已阅读到书籍末尾");
                    return;
                }
                else if (start >= 0 && end < total)
                {
                    ReadCache.book.rowNo = start;
                    tuple = BookUtil.getContentByRowNo(ReadCache.book.rowNo, pageSize);
                }
                else if (end >= total)
                {
                    this.showInfo("已阅读到书籍末尾");
                    ReadCache.book.rowNo = start;
                    int remainder = ReadCache.rows.Count - start;
                    tuple = BookUtil.getContentByRowNo(ReadCache.book.rowNo, remainder);
                }
                else
                {
                    tuple = BookUtil.getContentByRowNo(0, pageSize);
                    this.showInfo("已阅读到书籍开始");
                    ReadCache.book.rowNo = 0;
                }
            }
            else
            {
                tuple = BookUtil.getContentByChapter(chapterNo.Value, realLineNo, pageSize);
                if (tuple == null)
                {
                    this.showError("章节跳转失败");
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
                readProgress.Value = (int)(rate * 10000);
                readProgress.Refresh();
                //章节
                ReadCache.book.lastReadChapteNo = tuple.Item2.chapterNo;
                String chapter = tuple.Item2.chapterName;
                this.chapterTag.Text = chapter;
                ReadCache.book.lastReadChapter = chapter;
                //章节高亮
                //if (ReadCache.chapterStart >= 0)
                //{
                //    textBox.SelectionStart = ReadCache.chapterStart;
                //    //得到字符串的长度
                //    textBox.SelectionLength = chapter.Length;
                //    //然后就可以改变这个字符串的颜色
                //    //textBox.SelectionColor = ConfigCache.getOtherColor();
                //    textBox.SelectionFont = new Font(textBox.Font.FontFamily, textBox.Font.Size + 3, FontStyle.Bold);
                //    textBox.SelectionStart = 0;
                //    textBox.SelectionLength = 0;
                //}
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BookUtil.SaveLastRead();
            ConfigCache.saveDisplay();
            ConfigCache.saveTheme();
            ConfigCache.saveHotKey();
            ConfigCache.saveBooks();
            ConfigCache.saveMarkers();
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
                && (w != ConfigCache.display.Weight || h != ConfigCache.display.Height))
            {

                if (w == ConfigCache.display.Weight)
                {
                    //只改变高度
                    ReadCache.displayRowCount = ReadCache.calcDisplayRowCount(textBox);
                    showContent(0, null, null);
                    textBox.Show();
                }
                else
                {
                    this.showInfo("宽度改变,重新载入书籍");
                    loadLastReadBook();
                }
                setSize(w, h);
            }
        }

        /// <summary>
        /// 设置尺寸
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void setSize(int w, int h)
        {
            if (w >= Constants.MainFormWidthMin && h >= Constants.MainFormHeightMin)
            {
                ConfigCache.display.Weight = w; ConfigCache.display.Height = h;
            }
        }

        /// <summary>
        /// 窗体绑定控件时 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_BindingContextChanged(object sender, EventArgs e)
        {
            textBox.ForeColor = ConfigCache.theme.ForeColor;
            textBox.BackColor = ConfigCache.theme.BackColor;
            textBox.Font = new Font(ConfigCache.display.FontFamily, ConfigCache.display.FontSize, FontStyle.Regular);
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
                textBox.SelectionColor = ConfigCache.theme.CheckedColor;
            }
        }

        private void addMark_Click(object sender, EventArgs e)
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
            this.showSuccess("书签添加成功");
        }

    }
}