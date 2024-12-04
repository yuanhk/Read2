using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindRead.util;

namespace WindRead.bean
{
    /// <summary>
    /// 快捷键
    /// </summary>
    public class HotKey
    {
        /// <summary>
        /// 热键编码
        /// </summary>
        public string keyCode { get; set; }
        /// <summary>
        /// 效果
        /// </summary>
        public string effect { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string explain { get; set; }


        /// <summary>
        /// 重置热键设置
        /// </summary>
        /// <returns></returns>
        public static List<HotKey> Default()
        {
            return ConfigUtil.getByFileName<HotKey>("DefaultHotKey");
        }

        //根据编号获取按键码
        public static String getKeyCode(List<HotKey> hotKeyList, int index)
        {
            if (hotKeyList != null && hotKeyList.Count > index)
            {
                return hotKeyList[index].keyCode;
            }
            return "";
        }
    }
}
