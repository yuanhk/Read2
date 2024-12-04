using System;
using System.Collections.Generic;

namespace ArashiRead.model
{
    /// <summary>
    /// 章节
    /// </summary>
    public class Chapter
    {
        //排序码
        public Int32 ChapterNo { get; set; }
        //章节名
        public String ChapterName { get; set; }
        //章节内容
        public String Content { get; set; }

        //章节所在占比
        public String rateStr { get; set; }

        public int startIndex { get; set; }

        public List<int> map { get; set; }

        //章节地址
        public String ChapterUrl { get; set; }

        public Chapter()
        {
            map = new List<int>();
        }



        public Chapter(int chapterNo, string chapterName)
        {
            ChapterNo = chapterNo;
            ChapterName = chapterName; map = new List<int>();
        }
    }
}
