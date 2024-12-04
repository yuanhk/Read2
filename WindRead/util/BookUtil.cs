using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.bean;
using WindRead.cache;
using WindRead.constants;

namespace WindRead.util
{
    /// <summary>
    /// 书籍工具类
    /// </summary>
    internal class BookUtil
    {

        //章节正则
        public static Regex chapterRegex = new Regex(Constants.chapterScanRule);

        /// <summary>
        /// 获取书籍基本信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Book GetInfo(String path)
        {
            FileInfo fi = new FileInfo(path);
            Book book = new Book();
            book.url = fi.FullName.Replace("\\", "/");
            book.name = Path.GetFileNameWithoutExtension(fi.FullName);
            book.size = CommonUtil.FormatSize(fi.Length);
            return book;
        }



        /// <summary>
        /// 根据章节号获取正文
        /// </summary>
        /// <param name="chapterNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Tuple<String, ContentRow> getContentByChapter(int chapterNo, int? realLineNo, int pageSize)
        {
            List<ContentRow> list = new List<ContentRow>();
            foreach (var item in ReadCache.rows)
            {
                if (item.chapterNo >= chapterNo)
                {
                    //真实行号为空时从章节首行开始读取
                    if (realLineNo == null)
                    {
                        list.Add(item);
                    }
                    else if (item.realLineNo >= realLineNo)
                    {
                        //否则从真实行号开始读取
                        list.Add(item);
                    }

                }
                if (list.Count >= pageSize)
                {
                    break;
                }
            }
            if (list.Count > 0)
            {
                ReadCache.book.rowNo = list.First().index;
                return getContent(list);
            }
            return null;
        }


        /// <summary>
        /// 根据行号和页最大行数获取显示的正文
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Tuple<String, ContentRow> getContentByRowNo(int rowNo, int pageSize)
        {
            List<ContentRow> rowList = ReadCache.rows.GetRange(rowNo, pageSize);
            return getContent(rowList);
        }

        /// <summary>
        /// 从行列表中提取显示的正文
        /// </summary>
        /// <param name="rowList"></param>
        /// <returns></returns>
        public static Tuple<String, ContentRow> getContent(List<ContentRow> rowList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in rowList)
            {
                if (true.Equals(item.isCharpter))
                {
                    ReadCache.chapterStart = sb.Length;
                }
                sb.Append(item.row);
            }
            //真实行号
            if (rowList.Count > 0)
            {
                ReadCache.book.realLineNo = rowList.First().realLineNo;
            }
            return new Tuple<String, ContentRow>(sb.ToString(), rowList.Last());
        }


        /// <summary>
        /// 缓存书籍
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void CacheBook(RichTextBox box, String path)
        {
            //获取书籍基本信息
            ReadCache.book = GetInfo(path);
            //章节列表
            ReadCache.book.chapters = new List<Chapter>();
            List<Chapter> chapters = ReadCache.book.chapters;
            //获取文本编码格式
            Encoding encoding = EncodingTypeUtil.GetType(path);
            //读取文本流
            using (StreamReader sr = new StreamReader(path, encoding))
            {
                String line;
                //章节编号、所在行号
                int chapterNo = 0;
                Match mch;
                //创建序言或简介章节

                StringBuilder sb = new StringBuilder();

                Chapter chapter = new Chapter();
                chapter.ChapterName = "序言或简介";
                //按行读取且拆分章节
                while ((line = sr.ReadLine()) != null)
                {
                    //至少5个字符且通过正则校验
                    if (line.Length > 5 && (mch = chapterRegex.Match(line)).Success)
                    {
                        if (chapters.Count == 0 && sb.Replace("\n", "").ToString().Trim().Length > 0)
                        {
                            //创建序言或简介章节
                            chapter.ChapterNo = chapterNo++;
                            chapter.Content = sb.ToString();
                            chapters.Add(chapter);
                            sb.Clear();
                        }
                        else if (chapters.Count > 0)
                        {
                            //保存上一章节内容
                            chapters.Last().Content = sb.ToString();
                            sb.Clear();
                        }
                        //创建新的章节对象
                        chapter = new Chapter(chapterNo++, mch.Value);
                        chapters.Add(chapter);
                    }
                    //每行内容
                    sb.Append(line).Append("\n");
                    chapter.map.Add(sb.Length);
                }
                //保存最后一章节内容
                if (chapters.Count > 0)
                {
                    chapters.Last().Content = sb.ToString();
                    sb.Clear();
                }
            }
            box.Text = "";
        }

        /// <summary>
        /// 缓存文本行
        /// </summary>
        /// <param name="box"></param>
        /// <param name="chapters"></param>
        /// <param name="action"></param>
        public static void cacheRows(RichTextBox box, List<Chapter> chapters, Action<decimal, String> action)
        {
            //章节内容重新拆分行
            if (chapters.Count > 0)
            {
                //序言章节若文本行均为空，则移除序言章节
                Chapter c = chapters[0];
                if (CommonUtil.isBlank(c.Content.Trim().Replace("\n", "")))
                {
                    chapters.RemoveAt(0);
                }
                int index = 0;
                //读取所有章节对应文本后，根据textBox显示宽高裁剪行
                foreach (var chapter in chapters)
                {
                    String content = chapter.Content;
                    box.Text = content;
                    //获取本章实际渲染行数
                    int lastLine = box.GetLineFromCharIndex(content.Length);
                    for (int i = 0; i < lastLine; i++)
                    {
                        //本行开始结束下标
                        int start = box.GetFirstCharIndexFromLine(i), end = box.GetFirstCharIndexFromLine(i + 1);
                        //裁剪后的行
                        String line = content.Substring(0, end - start);
                        //获取当前行实际原行号
                        int realLineNo = calcRealLine(chapter.map, start);
                        //保存文本行对象
                        ContentRow contentRow = new ContentRow(line, realLineNo, chapter.ChapterNo, chapter.ChapterName, index++);
                        contentRow.isCharpter = i == 0 && !chapter.ChapterName.Equals("序言或简介");
                        ReadCache.rows.Add(contentRow);

                        content = content.Substring(end - start);
                    }

                    //计算缓存比率
                    decimal d = decimal.Divide(chapter.ChapterNo + 1, chapters.Count);
                    chapter.rateStr = CommonUtil.toRateStr(d);
                    action(d, chapter.rateStr);
                }
            }
            box.Text = "";
        }

        /// <summary>
        /// 获取字符所在实际行数
        /// </summary>
        /// <param name="realLines"></param>
        /// <param name="charIndex"></param>
        /// <returns></returns>
        private static int calcRealLine(List<int> indexList, int charIndex)
        {
            for (int i = 0; i < indexList.Count; i++)
            {
                if (charIndex < indexList[i])
                {
                    return i;
                }
            }
            return indexList.Count - 1;
        }


        /// <summary>
        /// 递归扫描文件夹下的书籍（调用）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<Book> ScanningFolder(String url)
        {
            if (Directory.Exists(url))
            {
                return scanningFolder(url, new List<Book>());
            }
            return new List<Book>();
        }


        /// <summary>
        /// 递归扫描文件夹下的书籍
        /// </summary>
        /// <param name="url"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Book> scanningFolder(String url, List<Book> list)
        {
            DirectoryInfo Di = new DirectoryInfo(url);
            try
            {
                FileSystemInfo[] Fsi = Di.GetFileSystemInfos();
                for (int i = 0; i < Fsi.Length; i++)
                {
                    String path = "";
                    List<Book> child = new List<Book>();
                    if (Fsi[i] is DirectoryInfo)//是文件夹
                    {
                        path = (Fsi[i] as DirectoryInfo).FullName;
                        child = scanningFolder(path, child);
                    }
                    if (Fsi[i] is FileInfo)//是文件
                    {
                        FileInfo file = new FileInfo(Fsi[i].FullName);
                        if (!file.Extension.Equals(".txt")) continue;
                        String name = file.Name.Replace(".txt", "");//文件名
                        String size = CommonUtil.FormatSize(file.Length);//大小
                        path = Fsi[i].FullName.Replace("\\", "/");//路径

                        list.Add(new Book(path, name, size));
                    }
                    list.AddRange(child);
                }
            }
            catch (Exception)
            {
                //没有权限的文件夹不做任何操作
            }
            return list;
        }

        /// <summary>
        /// 保存最后阅读历史
        /// </summary>
        public static void SaveLastRead()
        {
            Book bookCache = ReadCache.book;
            if (bookCache == null || !CommonUtil.isExist(bookCache.url)) return;
            Book config = ConfigCache.books.Find(b => b.url.Equals(bookCache.url));
            if (config != null)
            {
                config.name = bookCache.name;
                config.url = bookCache.url;
                config.size = bookCache.size;
                config.readPercent = bookCache.readPercent;
                config.readRate = bookCache.readRate;
                config.lastReadChapteNo = bookCache.lastReadChapteNo;
                config.lastReadChapter = bookCache.lastReadChapter;
                config.lastReadTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                config.rowNo = bookCache.rowNo;
                config.realLineNo = bookCache.realLineNo;
                config.totalRowCount = bookCache.totalRowCount;
                ConfigCache.saveBooks();
            }
        }

    }
}
