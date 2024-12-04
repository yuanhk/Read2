using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.bean;
using WindRead.cache;
using WindRead.constants;
using WindRead.form;
using WindRead.util;

namespace WindRead.Resources
{
    public partial class SubForm : Form
    {
        MainForm mainForm;

      

        public SubForm(MainForm form)
        {
            InitializeComponent();

            mainForm = form;
            this.RedrawFormControls(ConfigCache.theme);
            this.bookCms.RedrawControlCMS();

            //左侧按钮点击打开对应tab页
            foreach (var item in leftPanel.Controls)
            {
                if (item is AntdUI.Button) {
                    ((AntdUI.Button)item).MouseClick += btnClick;
                }
            }
            //加载书籍
            if (ReadCache.book != null)
            {
                BookUtil.SaveLastRead();
            }
            //读取配置中的书籍列表
            if (ConfigCache.books != null)
            {
                refreshBookDgv();
            }

        }

        /// <summary>
        /// 左侧按钮点击打开对应tab页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClick(object sender, EventArgs e)
        {
            AntdUI.Button btn = sender as AntdUI.Button;
            tabControl.SelectTab(btn.TabIndex);
        }


       

        /// <summary>
        /// 刷新
        /// </summary>
        public void refreshBookDgv()
        {
            if (ConfigCache.books != null)
                bookDgv.DataSource = new BindingList<Book>(ConfigCache.books);
        }

        public Form _drawerForm;

        private Form getDrawer() {
            if (_drawerForm == null) {
                _drawerForm = mainForm.getDrawerForm();
            }
            return _drawerForm;
        }


        private void booksMenu_SelectChanged(object sender, AntdUI.MenuItem item)
        {
            switch (item.Text)
            {
                case "导入书籍":
                    selectBook();
                    break;
                case "检索书籍":
                    String path = selectFolder();
                    if (path.Contains("\\"))
                    {
                        ConfigCache.display.BookFolderPath = path;
                        sreachBooks(path);
                    }
                    else if (CommonUtil.notBlank(path))
                    {
                        getDrawer().showError("错误的文件夹路径:" + path);
                    }
                    break;
                case "清理无效书籍":
                    List<Book> list = ConfigCache.books;
                    if (list.Count==0) {
                        getDrawer().showInfo("当前书架无书籍");
                        break;
                    }
                    int j = 0;
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (CommonUtil.FileIsBlank(list[i].url))
                        {
                            j++;
                            ConfigCache.books.RemoveAt(i);
                        }
                    }
                    bookDgv.DataSource = new BindingList<Book>(list);
                    getDrawer().showSuccess("已移除无效的书籍" + j + "本");
                    break;
            }

            ConfigCache.saveBooks();
        }

        /// <summary>
        /// 异步遍历文件夹获取书籍列表
        /// </summary>
        public void sreachBooks(String searchUrl)
        {
            if (Directory.Exists(searchUrl))
            {
                int count = ConfigCache.books.Count;
                List<Book> a = new List<Book>();
                BookUtil.scanningFolder(searchUrl, a);
                searchUrl = searchUrl.Replace("\\", "/");
                foreach (Book j in a)
                {
                    if (!ConfigCache.books.Exists(p => p.url.Equals(j.url)))
                    {
                        j.partPath = j.url.Replace(searchUrl, "").Replace("/" + j.name, "").Replace(".txt", "");
                        ConfigCache.books.Add(j);
                    }
                }
                if (ConfigCache.books.Count == count)
                {
                    getDrawer().showError("未检索到新的书籍");
                    return;
                }
                bookDgv.DataSource = new BindingList<Book>(ConfigCache.books);
                getDrawer().showSuccess("已从该文件夹导入" + a.Count + "本书籍");
            }
            else
            {
                getDrawer().showError("文件夹地址不存在");
            }
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <returns></returns>
        public static String selectFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择Txt所在文件夹";
            //设置此次默认目录为上一次选中目录
            if (CommonUtil.notBlank(ConfigCache.display.BookFolderPath))
                dialog.SelectedPath = ConfigCache.display.BookFolderPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    return "文件夹路径不能为空";
                }
                return dialog.SelectedPath;
            }
            return "";
        }

        /// <summary>
        /// 选择书籍
        /// </summary>
        private void selectBook()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择书籍";
            dialog.Filter = "文本文件(*.txt)|*.txt";
            dialog.InitialDirectory = ConfigCache.display.BookFolderPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<Book> list = ConfigCache.books;
                for (int i = 0; i < dialog.FileNames.Length; i++)
                {
                    FileInfo fi = new FileInfo(dialog.FileNames[i]);
                    ImportBook(list, fi);
                }
                bookDgv.DataSource = new BindingList<Book>(list);
            }
        }


        /// <summary>
        /// 导入书籍
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fi"></param>
        public static Book ImportBook(List<Book> list, FileInfo fi)
        {
            Book book;
            String url = fi.FullName.Replace("\\", "/");
            if (!list.Exists(t => url.Equals(t.url)))
            {
                book = new Book();
                book.url = url;
                book.name = Path.GetFileNameWithoutExtension(fi.FullName);
                book.readPercent = 0;
                book.readRate = "0%";
                book.lastReadTime = "-";
                book.lastReadChapter = "-";
                book.size = CommonUtil.FormatSize(fi.Length);
            }
            else
            {
                book = list.Find(t => url.Equals(t.url));
                //已经存在的书籍不改动 只调整位置
                if (book != null)
                {
                    list.Remove(book);
                }
            }
            list.Insert(0, book);
            return book;
        }

        private void 阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookDgv.SelectedRows.Count == 0)
            {
                getDrawer().showError("未选中书籍");
                return;
            }

            DataGridViewRow row = bookDgv.SelectedRows[0];
            String url = row.Cells[8].Value.ToString();
            if (!CommonUtil.isExist(url))
            {
                getDrawer().showError("该书籍已移动或已删除，无法打开");
                return;
            }
            if (new FileInfo(url).Length == 0)
            {
                getDrawer().showError("该书籍为空");
                return;
            }
            int rowNo = (int)row.Cells[6].Value;
            int chapterNo = (int)row.Cells[9].Value;
            int realLineNo = (int)row.Cells[7].Value;
            //关闭抽屉
            mainForm.closeDrawerForm();
            //不再主动调用winfrom方法
            mainForm.ansycOpenBook(url, rowNo, chapterNo, realLineNo);

        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //支持批量删除
            List<Book> list = ConfigCache.books;
            if (bookDgv.SelectedRows.Count > 0 && ConfigCache.books.Count > 0)
            {
                //获取选中文件路径集合
                List<String> paths = new List<string>();
                for (int i = 0; i < bookDgv.SelectedRows.Count; i++)
                {
                    paths.Add(CommonUtil.toString(bookDgv.SelectedRows[i].Cells[8].Value));
                }
                if (ReadCache.book != null && paths.Contains(ReadCache.book.url))
                {
                    getDrawer().showError("正在阅读的书籍不可移出");
                    paths.Remove(ReadCache.book.url);
                }
                //遍历删除选中的书籍
                for (int j = ConfigCache.books.Count - 1; j >= 0; j--)
                {
                    Book b = ConfigCache.books[j];
                    if (paths.Contains(b.url))
                    {
                        ConfigCache.books.RemoveAt(j);
                    }
                }
                bookDgv.DataSource = new BindingList<Book>(ConfigCache.books);
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = bookDgv.Rows.Count - 1; i >= 0; i--)
            {
                bookDgv.Rows[i].Selected = true;
            }
        }

        private void 取消全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = bookDgv.Rows.Count - 1; i >= 0; i--)
            {
                bookDgv.Rows[i].Selected = false;
            }
        }

        private void 复制路径ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StringBuilder urls = new StringBuilder();
            for (int i = bookDgv.SelectedRows.Count - 1; i >= 0; i--)
            {
                urls.Append(bookDgv.SelectedRows[i].Cells[8].Value).Append("\n");
            }
            if (urls.Length > 0)
            {
                Clipboard.SetDataObject(urls.ToString());
                getDrawer().showSuccess("已复制所选中书籍的路径");
            }
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
           
        }

        private void SubForm_Load(object sender, EventArgs e)
        {

        }


        //************章节****************//

        private void filterBox_Enter(object sender, EventArgs e)
        {
            if (filterBox.Text.Equals("请输入章节名"))
            {
                filterBox.Text = "";
            }
        }

        private void filterBox_Leave(object sender, EventArgs e)
        {
            if (filterBox.Text.Equals(""))
            {
                filterBox.Text = "请输入章节名";
            }
        }

        private void chapterBtn_Click(object sender, EventArgs e)
        {
            this.filterBox.BorderWidth = 0;
            Book b = ReadCache.book;
            if (b != null && b.chapters.Count > 0)
            {
                chapterDgv.DataSource = new BindingList<Chapter>(b.chapters);
                //选中指定单元格（滚动条自动跳转）
                this.chapterDgv.CurrentCell = this.chapterDgv.Rows[b.lastReadChapteNo].Cells[0];
            }
        }
        /// <summary>
        /// 开始阅读
        /// </summary>
        private void read()
        {
            if (chapterDgv.CurrentRow == null)
            {
                mainForm.showError("未选中章节");
                return;
            }
            int index = chapterDgv.CurrentRow.Index;
            int chapterNo = (int)chapterDgv.Rows[index].Cells[0].Value;
            mainForm.showContent(null, chapterNo, 0);
            this.Close();
        }

        private void chapterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            read();
            //关闭抽屉
            mainForm.closeDrawerForm();
        }


        private void filterBox_TextChanged(object sender, EventArgs e)
        {
            if (CommonUtil.notBlank(filterBox.Text) && !filterBox.Text.Equals("请输入章节名"))
            {
                filter();
            }
        }

        /// <summary>
        /// 根据输入的关键字筛选目录 
        /// </summary>
        public void filter()
        {
            if (ReadCache.book == null)
            {
                mainForm.showError("没有正在阅读的书籍");
                return;
            }
            List<Chapter> chapters = ReadCache.book.chapters;
            String filterStr = filterBox.Text;
            if (CommonUtil.notBlank(filterStr) && chapters != null)
            {
                List<Chapter> filterList = new List<Chapter>();
                foreach (Chapter c in chapters)
                {
                    if (CommonUtil.notBlank(c.ChapterName) && c.ChapterName.Contains(filterStr))
                    {
                        filterList.Add(c);
                    }
                }
                chapterDgv.DataSource = new BindingList<Chapter>(filterList);
                return;
            }
            chapterDgv.DataSource = new BindingList<Chapter>(chapters);
        }

        //************书签****************//


        private void markBtn_Click(object sender, EventArgs e)
        {
            ConfigCache.markers = ConfigCache.markers.OrderByDescending(x => x.lastReadTime).ToList();
            markDgv.DataSource = new BindingList<Book>(ConfigCache.markers);
        }
        private void menu2_SelectChanged(object sender, AntdUI.MenuItem item)
        {
            if (item.Text.Equals("清理无效书签"))
            {
                List<Book> list = ConfigCache.markers;
                int j = 0;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (!CommonUtil.isExist(list[i].url))
                    {
                        j++;
                        list.RemoveAt(i);
                    }
                }
                markDgv.DataSource = new BindingList<Book>(list);
                mainForm.showSuccess("已清除失效书签" + j + "个");
            }
            else if (item.Text.Equals("移除指定书签"))
            {
                if (markDgv.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in markDgv.SelectedRows)
                    {
                        markDgv.Rows.Remove(row);

                    }
                    List<Book> list = new List<Book>((BindingList<Book>)this.markDgv.DataSource);
                    list = list.OrderByDescending(x => x.lastReadTime).ToList();
                    ConfigCache.markers = list;
                }
                else
                {
                    mainForm.showError("未选中书签");
                }
            }
        }

        private void markDgv_MouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (markDgv.SelectedRows.Count == 0)
            {
                mainForm.showError("未选中书签");
                return;
            }
            DataGridViewRow row = markDgv.SelectedRows[0];
            String url = row.Cells[7].Value.ToString();
            int rowNo = (int)row.Cells[5].Value;
            int chapterNo = (int)row.Cells[0].Value;
            int realLineNo = (int)row.Cells[6].Value;
            int totalRowCount = (int)row.Cells[8].Value;
            //继续阅读
            if (ReadCache.book != null && ReadCache.book.url.Equals(url))
            {
                ReadCache.book.totalRowCount = ReadCache.rows.Count;
                //判断总条数是否一致
                if (ReadCache.rows.Count == totalRowCount)
                {
                    ReadCache.book.rowNo = rowNo;
                    mainForm.showContent(0, null, null);
                }
                else
                {
                    mainForm.showContent(null, chapterNo, realLineNo);
                }
            }
            else
            {
                //打开书籍
                if (!CommonUtil.isExist(url))
                {
                    mainForm.showError("该书籍已移动或已删除，无法打开");
                    return;
                }
                if (CommonUtil.FileIsBlank(url))
                {
                    mainForm.showError("该书籍为空");
                    return;
                }
                mainForm.ansycOpenBook(url, rowNo, chapterNo, realLineNo);
            }
        }
      





        //************搜索****************//

        private void searchBtn_Click(object sender, EventArgs e)
        {
            
            this.sreachInput.BorderWidth = 0;
            showSearchPage();
        }

        private void showSearchPage()
        {
            if (CommonUtil.notBlank(ReadCache.sreachTerm))
            {
                sreachInput.Text = ReadCache.sreachTerm;
            }
            if (ReadCache.searchResults.Count > 0)
            {
                sreachDgv.DataSource = new BindingList<ContentRow>(ReadCache.searchResults);
                sreachInput.SuffixText = "查询结果 : " + ReadCache.searchResults.Count;
                if (ReadCache.lastSelectIndex >= 0 && ReadCache.lastSelectIndex < ReadCache.searchResults.Count)
                {
                    this.sreachDgv.CurrentCell = this.sreachDgv.Rows[ReadCache.lastSelectIndex].Cells[1];
                }
            }
        }

        private void sreachInput_Enter(object sender, EventArgs e)
        {
            if (sreachInput.Text.Equals("请输入搜索文本"))
            {
                sreachInput.Text = "";
            }
        }

        private void sreachInput_Leave(object sender, EventArgs e)
        {
            if (sreachInput.Text.Equals(""))
            {
                sreachInput.Text = "请输入搜索文本";
            }
            else if (!sreachInput.Text.Equals("请输入搜索文本") && !sreachInput.Text.Equals(ReadCache.sreachTerm))
            {
                ReadCache.sreachTerm = sreachInput.Text;
                sreach();
            }
        }

        private void sreachInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && CommonUtil.notBlank(sreachInput.Text)
                && !sreachInput.Text.Equals("请输入搜索文本")
                )
            {
                ReadCache.sreachTerm = sreachInput.Text;
                sreach();
            }
        }

        /// <summary>
        /// 全文查找
        /// </summary>
        public void sreach()
        {
            List<ContentRow> rows = ReadCache.rows;
            if (rows.Count == 0)
            {
                mainForm.showError("没有正在阅读的书籍");
                return;
            }
            ReadCache.searchResults.Clear();
            String str = ReadCache.sreachTerm;
            List<ContentRow> find = rows.FindAll(x => x.row.Contains(str)).ToList();
            if (find.Count == 0)
            {
                mainForm.showInfo("指定文本全文未找到");
                sreachInput.SuffixText = "查询结果 : 0";
            }
            else
            {
                mainForm.showSuccess("全文查找成功，共找到" + find.Count + "条结果");
                sreachInput.SuffixText = "查询结果 : " + find.Count;
                ReadCache.searchResults = find;
            }
            sreachDgv.DataSource = new BindingList<ContentRow>(ReadCache.searchResults);
            mainForm.closeDrawerForm();
        }
        private void sreachDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sreachDgv.CurrentRow == null)
            {
                mainForm.showError("未选中结果行");
                return;
            }
            int index = sreachDgv.CurrentRow.Index;
            if (index >= 0)
            {
                ReadCache.lastSelectIndex = index;
                int rowNo = (int)sreachDgv.Rows[index].Cells[3].Value;
                ReadCache.book.rowNo = rowNo;
                mainForm.showContent(0, null, null);
                mainForm.highlight(ReadCache.sreachTerm);
                this.Close();
            }
            else
            {
                mainForm.showError("未选中查询结果");
            }

        }




        //************快捷键****************//
        private void hotKeyBtn_Click(object sender, EventArgs e)
        {
            if (ConfigCache.hotKeys.Count > 0)
            {
                hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
                this.hotKeyDgv.Rows[0].Selected = false;
            }
        }

        private void menu4_SelectChanged(object sender, AntdUI.MenuItem item)
        {
            ConfigCache.hotKeys = HotKey.Default();
            ConfigCache.hotKeyMap = ConfigCache.hotKeys.ToDictionary(i => i.keyCode, i => i.effect);
            hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
            this.hotKeyDgv.Rows[0].Selected = false;
            mainForm.showSuccess("快捷键已全部重置");
        }


        private void hotKeyDgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCell cell = hotKeyDgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value.ToString().Contains("全局"))
                {
                    hotKeyDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "全局快捷键：Ctrl + Alt + 设置键码组合使用";
                }
            }
        }

        private void hotKeyDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
            if (hotKeyDgv.SelectedRows.Count == 1)
            {
                String inputKey = e.KeyCode.ToString();
                if (!ConfigCache.keyDescMap.ContainsKey(inputKey))
                {
                    mainForm.showError("该键位不可用");
                }
                else if (ConfigCache.hotKeyMap.ContainsKey(inputKey))
                {
                    mainForm.showError("该键位已被使用");
                }
                else
                {
                    //选中行下标
                    int selectIndex = hotKeyDgv.CurrentRow.Index;
                    String sourceKey = hotKeyDgv.Rows[selectIndex].Cells[1].Value.ToString();
                    HotKey key = ConfigCache.hotKeys.Find(x => x.keyCode.Equals(sourceKey));
                    if (key != null)
                    {
                        key.keyCode = inputKey;
                        key.explain = ConfigCache.keyDescMap[inputKey];
                        //修改热键键值对map
                        ConfigCache.hotKeyMap.Add(inputKey, ConfigCache.hotKeyMap[sourceKey]);
                        ConfigCache.hotKeyMap.Remove(sourceKey);

                        //重新绑定数据
                        hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
                        mainForm.showSuccess("已成功修改快捷键设置");
                    }
                    else
                    {
                        mainForm.showInfo("修改失败!" + inputKey + ":" + ConfigCache.keyDescMap[inputKey]);
                        hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
                    }
                    this.hotKeyDgv.Rows[selectIndex].Selected = true;
                }
            }
        }




        //************主题****************//

        private void themeBtn_Click(object sender, EventArgs e)
        {
        }



        //************设置****************//


        private void settingBtn_Click(object sender, EventArgs e)
        {
            settingInit();
        }

        /// <summary>
        /// 设置初始化
        /// </summary>
        private void settingInit()
        {
            //loadColor(ConfigCache.currentColors);
            //获取系统字体(字体名必须含汉字)：
            fontFamilyCmb.Items.Clear();
            foreach (System.Drawing.FontFamily font in families)
            {
                if (Regex.IsMatch(font.Name, @"[\u4e00-\u9fa5]"))
                {
                    this.fontFamilyCmb.Items.Add(font.Name);
                    if (font.Name.ToLower().Equals(ConfigCache.display.FontFamily.ToLower()))
                        this.fontFamilyCmb.SelectedIndex = this.fontFamilyCmb.Items.Count - 1;
                }
            }
            //设置字体
            float f = (float)ConfigCache.display.FontSize;
            System.Drawing.FontFamily fontFamily = new System.Drawing.FontFamily(ConfigCache.display.FontFamily);
            updateFont(f, fontFamily, ConfigCache.display.FontBold ? FontStyle.Bold : FontStyle.Regular);
            fontSizeslider.Value = (int)((ConfigCache.display.FontSize - 10) * 2);
            switch2.Checked = ConfigCache.display.FontBold;
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
        }


        List<System.Drawing.FontFamily> families = new InstalledFontCollection().Families.ToList();

        private void fontFamilyCmb_SelectedValueChanged(object sender, object value)
        {
            System.Drawing.FontFamily fontFamily = families.Find(x => x.Name.Equals(value));
            if (fontFamily == null)
            {
                getDrawer().showError("该字体不存在");
            }
            else
            {
                updateFont(null, fontFamily, null);
            }
        }

        /// <summary>
        /// 修改字体
        /// </summary>
        /// <param name="f"></param>
        /// <param name="fontFamily"></param>
        /// <param name="style"></param>
        private void updateFont(float? f, System.Drawing.FontFamily fontFamily, FontStyle? style)
        {
            Font font = mainForm.textBox.Font;
            if (f == null)
            {
                f = font.Size;
            }
            if (fontFamily == null)
                fontFamily = font.FontFamily;
            if (style == null)
                style = font.Style;
            mainForm.textBox.Font = new Font(fontFamily, f.Value, style.Value);
            fontSizeLab.Text = mainForm.textBox.Font.Size + "";
            ConfigCache.display.FontFamily = fontFamily.Name;
            ConfigCache.display.FontSize = f.Value;
          //  ConfigCache.display.FontBold = (style.Value == 1);
        }

        /// <summary>
        /// 字体大小修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void fontSizeslider_ValueChanged(object sender, int value)
        {
            float f = (float)value / 2f + 10f;
            updateFont(f, null, null);
        }

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
            ConfigCache.display.Weight = mainForm.Width;
            ConfigCache.display.Height = mainForm.Height;
        }

        private void menuPanel_MouseLeave(object sender, EventArgs e)
        {
            mainForm.closeDrawerForm();

            ///todo
            /// 不要再用antdui的蒙版窗口了 一堆问题 自己写一个



        }
    }
}
