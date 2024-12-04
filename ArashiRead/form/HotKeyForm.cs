using ArashiRead.config;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ArashiRead.form
{
    /// <summary>
    /// 热键
    /// </summary>
    public partial class HotKeyForm : ParentForm
    {
        MainForm mainForm;
        public HotKeyForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            RedrawFormControls(this, ConfigCache.currentColors);
            hotKeyDgv.Columns[0].ToolTipText = "注意:全局热键均为组合键，规则为 Ctrl + Alt + 设置键码 ";
        }

        //窗体渲染完成后
        private void HotKeyForm_Shown(object sender, EventArgs e)
        {
            if (ConfigCache.hotKeys.Count > 0)
            {
                hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
                this.hotKeyDgv.Rows[0].Selected = false;

            }

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
            else
            {
            }
        }


        private void hotKeyDgv_KeyDown_1(object sender, KeyEventArgs e)
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
                    showError("该键位不可用");
                }
                else if (ConfigCache.hotKeyMap.ContainsKey(inputKey))
                {
                    showError("该键位已被使用");
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
                        showSuccess("已成功修改快捷键设置");
                    }
                    else
                    {
                        showInfo("修改失败!" + inputKey + ":" + ConfigCache.keyDescMap[inputKey]);
                        hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
                    }
                    this.hotKeyDgv.Rows[selectIndex].Selected = true;
                }
            }
        }

        private void menu1_SelectChanged(object sender, AntdUI.MenuItem item)
        {
            ConfigCache.hotKeys = HotKey.Default();
            ConfigCache.hotKeyMap = ConfigCache.hotKeys.ToDictionary(i => i.keyCode, i => i.effect);
            hotKeyDgv.DataSource = new BindingList<HotKey>(ConfigCache.hotKeys);
            this.hotKeyDgv.Rows[0].Selected = false;
            showSuccess("快捷键已全部重置");
        }
    }
}
