using ArashiRead.cache;
using ArashiRead.config;
using ArashiRead.model;
using ArashiRead.service;
using ArashiRead.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class BookshelfForm : ParentForm
    {
        MainForm mainForm;

        public BookshelfForm(MainForm form)
        {
            InitializeComponent();
            this.mainForm = form;
            RedrawFormControls(this, ConfigCache.currentColors);


            RedrawControlCMS(chapterMenu);
        }


        /// <summary>
        /// 右上角菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        private void menu1_SelectChanged(object sender, AntdUI.MenuItem item)
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
                        ConfigCache.display.bookFolderPath = path;
                        SearchBookForm s = new SearchBookForm(path);
                        s.refresh += refresh;
                        s.ShowDialog();
                    }
                    else if (CommonUtil.notBlank(path))
                    {
                        showInfo("错误的文件夹路径:" + path);
                    }
                    break;
                case "清理无效书籍":
                    List<Book> list = ConfigCache.books;
                    int j = 0;
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (CommonUtil.FileIsBlank(list[i].url))
                        {
                            j++;
                            ConfigCache.books.RemoveAt(i);
                        }
                    }
                    table.DataSource = new BindingList<Book>(list);
                    showSuccess("已移除无效的书籍" + j + "本");
                    break;
            }
        }

        public delegate void refreshBookDgv();
        void refresh()
        {
            if (ConfigCache.books != null)
                table.DataSource = new BindingList<Book>(ConfigCache.books);
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
            if (CommonUtil.notBlank(ConfigCache.display.bookFolderPath))
                dialog.SelectedPath = ConfigCache.display.bookFolderPath;
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
            dialog.InitialDirectory = ConfigCache.display.bookFolderPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<Book> list = ConfigCache.books;
                for (int i = 0; i < dialog.FileNames.Length; i++)
                {
                    FileInfo fi = new FileInfo(dialog.FileNames[i]);
                    ImportBook(list, fi);
                }
                showSuccess("指定书籍已加入书架");
                table.DataSource = new BindingList<Book>(list);

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

        /// <summary>
        /// 开始阅读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void BookshelfForm_Shown(object sender, EventArgs e)
        {
            if (ReadCache.book != null)
            {
                BookUtil.SaveLastRead();
            }
            //读取配置中的书籍列表
            if (ConfigCache.books != null)
            {
                table.DataSource = ConfigCache.books;
            }
        }

        private void table_DoubleClick(object sender, EventArgs e)
        {
            testToolStripMenuItem_Click(sender, e);
        }

        private void 取消全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                table.Rows[i].Selected = false;
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                table.Rows[i].Selected = true;
            }
        }

        private void 复制路径ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StringBuilder urls = new StringBuilder();
            for (int i = table.SelectedRows.Count - 1; i >= 0; i--)
            {
                urls.Append(table.SelectedRows[i].Cells[8].Value).Append("\n");
            }
            if (urls.Length > 0)
            {
                Clipboard.SetDataObject(urls.ToString());
                showSuccess("已复制所选中书籍的路径");
            }
        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //支持批量删除
            List<Book> list = ConfigCache.books;
            if (table.SelectedRows.Count > 0 && ConfigCache.books.Count > 0)
            {
                //获取选中文件路径集合
                List<String> paths = new List<string>();
                for (int i = 0; i < table.SelectedRows.Count; i++)
                {
                    paths.Add(CommonUtil.toString(table.SelectedRows[i].Cells[8].Value));
                }
                if (ReadCache.book != null && paths.Contains(ReadCache.book.url))
                {
                    showError("正在阅读的书籍不可移出");
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
                table.DataSource = new BindingList<Book>(ConfigCache.books);
            }
        }

        private void 阅读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (table.SelectedRows.Count == 0)
            {
                showError("未选中书籍");
                return;
            }

            DataGridViewRow row = table.SelectedRows[0];
            String url = row.Cells[8].Value.ToString();
            if (!CommonUtil.isExist(url))
            {
                showError("该书籍已移动或已删除，无法打开");
                return;
            }
            if (new FileInfo(url).Length == 0)
            {
                showError("该书籍为空");
                return;
            }
            int rowNo = (int)row.Cells[6].Value;
            int chapterNo = (int)row.Cells[9].Value;
            int realLineNo = (int)row.Cells[7].Value;
            mainForm.ansycOpenBook(url, rowNo, chapterNo, realLineNo);
            this.Close();
        }
    }
}
