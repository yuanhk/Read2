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
        /// ����ر�ǰ
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
        /// ��ʾ�ı�
        /// </summary>
        /// <param name="page">ҳ��</param>
        /// <param name="chapterNo">�½ں�</param>
        public void showContent(int? page, int? chapterNo, int? realLineNo)
        {
            ReadCache.chapterStart = -1;
            textBox.SelectedText = "";
            int pageSize = ReadCache.GetDisplayRowCount(textBox);
            Tuple<String, ContentRow> tuple;
            //����ȡ�к�
            if (page != null)
            {
                int start = ReadCache.book.rowNo + pageSize * page.Value;
                int end = start + pageSize;
                int total = ReadCache.rows.Count;
                if (start >= total)
                {
                    showInfo("���Ķ����鼮ĩβ");
                    return;
                }
                else if (start >= 0 && end < total)
                {
                    ReadCache.book.rowNo = start;
                    tuple = BookUtil.getContentByRowNo(ReadCache.book.rowNo, pageSize);
                }
                else if (end >= total)
                {
                    showInfo("���Ķ����鼮ĩβ");
                    ReadCache.book.rowNo = start;
                    int remainder = ReadCache.rows.Count - start;
                    tuple = BookUtil.getContentByRowNo(ReadCache.book.rowNo, remainder);
                }
                else
                {
                    tuple = BookUtil.getContentByRowNo(0, pageSize);
                    showInfo("���Ķ����鼮��ʼ");
                    ReadCache.book.rowNo = 0;
                }
            }
            else
            {
                tuple = BookUtil.getContentByChapter(chapterNo.Value, realLineNo, pageSize);
                if (tuple == null)
                {
                    showError("�½���תʧ��");
                }
            }

            if (tuple != null)
            {
                textBox.Text = tuple.Item1.EndsWith("\n") ?
                    tuple.Item1.Substring(0, tuple.Item1.Length - 1) :
                    tuple.Item1;
                //�Ķ�����
                decimal rate = decimal.Divide(tuple.Item2.index, ReadCache.rows.Count);
                ReadCache.book.readPercent = rate;
                rateLab.Text = CommonUtil.toRateStr(rate);
                ReadCache.book.readRate = rateLab.Text;
                //�½�
                ReadCache.book.lastReadChapteNo = tuple.Item2.chapterNo;
                String chapter = tuple.Item2.chapterName;
                this.chapterTag.Text = chapter;
                ReadCache.book.lastReadChapter = chapter;
                //�½ڸ���
                if (ReadCache.chapterStart >= 0)
                {
                    textBox.SelectionStart = ReadCache.chapterStart;
                    //�õ��ַ����ĳ���
                    textBox.SelectionLength = chapter.Length;
                    //Ȼ��Ϳ��Ըı�����ַ�������ɫ
                    //textBox.SelectionColor = ConfigCache.getOtherColor();
                    textBox.SelectionFont = new Font(textBox.Font.FontFamily, textBox.Font.Size + 3, FontStyle.Bold);
                    textBox.SelectionStart = 0;
                    textBox.SelectionLength = 0;
                }
                //��ǰҳ��
                int s = ReadCache.book.rowNo + 1;
                int now = s % pageSize == 0 ? s / pageSize : s / pageSize + 1;
                this.currentLab.Text = now + "";

                //��ҳ��
                int s1 = ReadCache.rows.Count + 1;
                int totalPage = s1 % pageSize == 0 ? s1 / pageSize : s1 / pageSize + 1;
                this.totalLab.Text = totalPage + "";
            }
        }

        /// <summary>
        /// �첽���鼮
        /// </summary>
        /// <param name="url"></param>
        public void ansycOpenBook(String url, int? rowNo, int? chapterNo, int? realLineNo)
        {
            asyncWork(() => openBook(url, rowNo, chapterNo, realLineNo));
        }


        /// <summary>
        /// �첽�����һ���Ķ����鼮
        /// </summary>
        public void loadLastReadBook()
        {
            asyncWork(() => openBook("", null, null, null));
        }

        /// <summary>
        /// ��һ����
        /// </summary>
        public bool openBook(String url, int? rowNo, int? chapterNo, int? realLineNo)
        {
            if (ConfigCache.books != null && ConfigCache.books.Count > 0)
            {
                Book config = CommonUtil.isBlank(url) ? ConfigCache.books[0] : ConfigCache.books.Find(z => z.url.Equals(url));
                if (config == null)
                {
                    showInfo("�����û���κ��鼮");
                    return false;
                }
                else if (!CommonUtil.isExist(config.url))
                {
                    showError("���鼮���ƶ�����ɾ�����޷���");
                    return false;
                }
                else if (CommonUtil.FileIsBlank(config.url))
                {
                    showError("���鼮Ϊ��");
                    return false;
                }
                else
                {
                    //����������
                    ReadCache.lastSelectIndex = -1;
                    ReadCache.searchResults.Clear();
                    ReadCache.sreachTerm = "";

                    this.bookNameTag.Text = "";
                    this.chapterTag.Text = "";
                    this.currentLab.Text = "0";
                    this.totalLab.Text = "0";
                    this.rateLab.Text = "0%";
                    //���¼���ÿҳ��ʾ����
                    ReadCache.displayRowCount = 0;
                    ReadCache.rows.Clear();
                    //��ǰ�Ķ��鼮�û�����λ
                    if (ConfigCache.books.IndexOf(config) != 0)
                    {
                        ConfigCache.books.Remove(config);
                        ConfigCache.books.Insert(0, config);
                    }
                    //�����鼮
                    BookUtil.CacheBook(textBox, config.url);
                    //�����ı���
                    BookUtil.cacheRows(textBox, ReadCache.book.chapters, (x, y) =>
                    {
                        loadingProgress.Value = ((float)x);
                        loadingProgress.Text = y;
                        loadingProgress.Refresh();
                    });
                    this.bookNameTag.Text = ReadCache.book.name;
                    ReadCache.book.totalRowCount = ReadCache.rows.Count;
                    //�ж��������Ƿ�һ��
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
        /// ����󶨿ؼ�ʱ 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_BindingContextChanged(object sender, EventArgs e)
        {
            loadingPanel.Visible = true;
            loadingPanel.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// ���������ɺ� 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            loadLastReadBook();
        }

        /// <summary>
        /// ���
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
        /// �½��б�
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
        /// ��ǩ�б�
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
        /// ȫ�Ĳ���
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
        /// ��ݼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotKey_Click(object sender, EventArgs e)
        {
            HotKeyForm keyForm = new HotKeyForm(this);
            keyForm.ShowDialog(this);
        }

        /// <summary>
        /// ����
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
        /// ��������
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

        private void �����ǩToolStripMenuItem_Click(object sender, EventArgs e)
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
            showSuccess("��ǩ��ӳɹ�");
        }

        /// <summary>
        /// ������ʾָ������
        /// </summary>
        /// <param name="value"></param>
        public void highlight(String str)
        {
            if (CommonUtil.isBlank(str)) return;
            int startIndex = 0;
            while ((startIndex = textBox.Find(str, startIndex + 1, RichTextBoxFinds.None)) > -1)
            {
                textBox.SelectionStart = startIndex;
                //�õ��ַ����ĳ���
                textBox.SelectionLength = str.Length;
                //Ȼ��Ϳ��Ըı�����ַ�������ɫ
                textBox.SelectionColor = ConfigCache.currentColors.promptColor;
            }
        }

        /// <summary>
        /// ���ô���ߴ�
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
            //�µĳߴ������С�ߴ硢�ҳߴ��뻺���еĳߴ粻һ��
            if (w >= Constants.MainFormWidthMin && h >= Constants.MainFormHeightMin
                && (w != ConfigCache.display.mainFormWeight || h != ConfigCache.display.mainFormHeight))
            {

                if (w == ConfigCache.display.mainFormWeight)
                {
                    //ֻ�ı�߶�
                    ReadCache.displayRowCount = ReadCache.calcDisplayRowCount(textBox);
                    showContent(0, null, null);
                    textBox.Show();
                }
                else
                {
                    showInfo("��ȸı�,���������鼮");
                    loadLastReadBook();
                }
                ConfigCache.display.setSize(w, h);
            }
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            BookUtil.SaveLastRead();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ѡ���ı�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;


            if (item.Text.Equals("ѡ���ı�"))
            {
                item.Text = "�ر�ѡ��";
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
                item.Text = "ѡ���ı�";
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
        /// ���������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        System.Windows.Forms.ToolTip toolTip;

        public void showTip(Control sender)
        {
            if (toolTip != null)
                toolTip.Dispose();
            toolTip = new System.Windows.Forms.ToolTip();
            // ������ʾ��ʽ
            toolTip.AutoPopDelay = 2000;//��ʾ��Ϣ�Ŀɼ�ʱ��
            toolTip.InitialDelay = 0;//�¼�������ú������ʾ
            toolTip.ReshowDelay = 0;//ָ���һ���ؼ�������һ���ؼ�ʱ��������òŻ���ʾ��һ����ʾ��
            toolTip.ShowAlways = true;//�Ƿ���ʾ��ʾ��
            toolTip.ForeColor = ConfigCache.currentColors.foreColor;
            //  ���ð���Ķ���.
            toolTip.SetToolTip(sender, sender.Tag.ToString());//������ʾ��ť����ʾ����
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
