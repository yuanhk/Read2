using ArashiRead.config;
using ArashiRead.model;
using ArashiRead.service;
using ArashiRead.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ArashiRead.form
{
    public partial class SearchBookForm : ParentForm
    {
        private String searchUrl = "";

        public SearchBookForm(String url)
        {
            InitializeComponent();
            searchUrl = url;
            RedrawFormControls(this, ConfigCache.currentColors);
        }

        public event BookshelfForm.refreshBookDgv refresh;

        /// <summary>
        /// 全部导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        private void menu1_SelectChanged(object sender, AntdUI.MenuItem item)
        {
            if (item.Text.Equals("全部导入"))
            {
                if (searchResultDgv.Rows.Count == 0)
                {
                    showError("没有可以导入的书籍");
                }
                else
                {
                    searchResultDgv.SelectAll();
                    importSelectedBooks(searchResultDgv.SelectedRows);
                }
            }
            else
            {
                searchUrl = BookshelfForm.selectFolder();
                if (CommonUtil.notBlank(searchUrl))
                {
                    sreachBooks();
                }
            }
        }

        /// <summary>
        /// 导入书籍
        /// </summary>
        /// <param name="rows"></param>
        private void importSelectedBooks(DataGridViewSelectedRowCollection rows)
        {
            List<Book> addList = ConfigCache.books;
            int i = 0;
            foreach (DataGridViewRow row in rows)
            {
                Book temp = new Book();
                temp.name = CommonUtil.toString(row.Cells[0].Value);
                temp.size = CommonUtil.toString(row.Cells[1].Value);
                temp.partPath = CommonUtil.toString(row.Cells[2].Value);
                temp.url = CommonUtil.toString(row.Cells[3].Value);
                temp.lastReadChapter = "-";
                temp.lastReadTime = "-";
                addList.Add(temp);
                searchResultDgv.Rows.Remove(row);
                i++;
            }
            showSuccess("成功导入" + i + "本书籍");
            refresh();
        }


        /// <summary>
        /// 异步遍历文件夹获取书籍列表
        /// </summary>
        public void sreachBooks()
        {
            List<Book> result = new List<Book>();
            if (Directory.Exists(searchUrl))
            {
                List<Book> a = new List<Book>();
                BookUtil.scanningFolder(searchUrl, a);
                List<Book> b = ConfigCache.books;
                searchUrl = searchUrl.Replace("\\", "/");
                foreach (Book j in a)
                {
                    if (!b.Exists(p => p.url.Equals(j.url)))
                    {
                        j.partPath = j.url.Replace(searchUrl, "").Replace("/" + j.name, "").Replace(".txt", "");
                        result.Add(j);
                    }
                }
                showSuccess("检索到" + result.Count + "本新书籍");
                searchResultDgv.DataSource = new BindingList<Book>(result);
            }
            else
            {
                showError("文件夹地址不存在");
            }
        }

        private void SearchBookForm_Shown(object sender, EventArgs e)
        {
            asyncWork(() => sreachBooks());
        }
    }
}
