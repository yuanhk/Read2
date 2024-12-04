using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindRead.bean
{
    /// <summary>
    /// 正文行
    /// </summary>
    public class ContentRow
    {
        //下标
        public int index { get; set; }
        //行
        public String row { get; set; }
        //所属真实行
        public int realLineNo { get; set; }
        //所属章节
        public int chapterNo { get; set; }
        //所属章节名
        public String chapterName { get; set; }

        public Boolean isCharpter { get; set; }

        public ContentRow(string row, int lineNo, int chapterNo, String chapterName, int index)
        {
            this.row = row;
            this.realLineNo = lineNo;
            this.chapterNo = chapterNo;
            this.chapterName = chapterName;
            this.index = index;
        }
    }
}
