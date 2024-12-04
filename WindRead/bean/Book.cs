using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindRead.bean
{
    /// <summary>
    /// 书籍
    /// </summary>
    public class Book
    {

        /// <summary>
        /// 书源
        /// </summary>
        public String source { get; set; }
        /// <summary>
        /// 书籍地址
        /// </summary>
        public String url { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// 章节列表
        /// </summary>
        public List<Chapter> chapters = new List<Chapter>();
        /// <summary>
        /// 已阅读进度
        /// </summary>
        public Decimal readPercent { get; set; }
        /// <summary>
        /// 已阅读进度百分比
        /// </summary>
        public String readRate { get; set; }
        /// <summary>
        /// 最后阅读时间
        /// </summary>
        public String lastReadTime { get; set; }
        /// <summary>
        /// 最后阅读章节
        /// </summary>
        public String lastReadChapter { get; set; }
        /// <summary>
        /// 最后阅读章节编号
        /// </summary>
        public int lastReadChapteNo { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int rowNo { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int realLineNo { get; set; }

        /// <summary>
        /// 总行数（经过txtbox解析后）
        /// </summary>
        public int totalRowCount { get; set; }


        /**
        * 本地书籍字段
        */
        /// <summary>
        /// 书籍大小
        /// </summary>
        public String size { get; set; }
        /// <summary>
        /// 检索片段地址
        /// </summary>
        public String partPath { get; set; }


        public Book()
        {
        }

        public Book(string url, string name, string size)
        {
            this.url = url;
            this.name = name;
            this.size = size;
            this.lastReadChapter = "-";
            this.lastReadTime = "-";
        }
    }
}
