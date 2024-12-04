using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindRead.bean;

namespace WindRead.cache
{
    /// <summary>
    /// 阅读缓存
    /// </summary>
    public class ReadCache
    {
        //书籍缓存
        public static Book book;

        //分页缓存
        public static List<ContentRow> rows = new List<ContentRow>();

        //richTxtBox能显示的行数
        public static int displayRowCount = 0;

        //章节行开始下标
        public static int chapterStart = -1;

        //全文检索结果
        public static List<ContentRow> searchResults = new List<ContentRow>();

        //全文检索条件
        public static String sreachTerm = "";

        //全文检索条件-最后选中
        public static int lastSelectIndex = -1;


        public static int calcDisplayRowCount(RichTextBox r)
        {
            r.Hide();
            r.Text = "1\n2";
            //第一行第一个字节的坐标
            System.Drawing.Point ptLine1 = r.GetPositionFromCharIndex(r.GetFirstCharIndexFromLine(0));
            //第二行第一个字节的坐标
            System.Drawing.Point ptLine2 = r.GetPositionFromCharIndex(r.GetFirstCharIndexFromLine(1));
            r.Text = "";
            displayRowCount = r.Height / (ptLine2.Y - ptLine1.Y);
            Debug.WriteLine("最大显示行数：" + displayRowCount);
            return displayRowCount;
        }

        //计算richTxtBox能显示的行数
        public static int GetDisplayRowCount(RichTextBox r)
        {
            if (displayRowCount == 0)
            {
                displayRowCount = calcDisplayRowCount(r);

            }
            return displayRowCount;
        }

    }
}
