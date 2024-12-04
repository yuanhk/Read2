using ArashiRead.bean;
using ArashiRead.model;
using ArashiRead.util;
using System;
using System.Collections.Generic;

namespace ArashiRead.config
{

    /// <summary>
    /// 配置缓存
    /// </summary>
    public class ConfigCache
    {
        /// <summary>
        /// 书籍列表
        /// </summary>
        public static List<Book> books = new List<Book>();
        /// <summary>
        /// 书签列表
        /// </summary>
        public static List<Book> markers = new List<Book>();
        /// <summary>
        /// 设置
        /// </summary>
        public static DisplayConfig display = new DisplayConfig();
        /// <summary>
        /// 热键
        /// </summary>
        public static List<HotKey> hotKeys = new List<HotKey>();
        /// <summary>
        /// 热键map
        /// </summary>
        public static Dictionary<String, String> hotKeyMap = new Dictionary<String, String>();

        /// <summary>
        /// 键位说明
        /// </summary>
        public static Dictionary<String, String> keyDescMap { get; set; }

        /// <summary>
        /// 预置颜色列表
        /// </summary>
        public static List<ColorConfig> presetColors = new List<ColorConfig>();

        /// <summary>
        /// 当前颜色
        /// </summary>
        public static Colors currentColors = new Colors();



        //字段名
        public static String booksField = nameof(ConfigCache.books),
                    markersField = nameof(ConfigCache.markers),
                    displayField = nameof(ConfigCache.display),
                    hotKeyField = nameof(ConfigCache.hotKeys);

        /// <summary>
        /// 保存书籍列表
        /// </summary>
        public static void saveBooks()
        {
            ConfigUtil.saveObj<Book>(books, booksField);
        }
        /// <summary>
        /// 保存书签列表
        /// </summary>
        public static void saveMarkers()
        {
            ConfigUtil.saveObj<Book>(markers, markersField);
        }
        /// <summary>
        /// 保存显示配置
        /// </summary>
        public static void saveDisplay()
        {
            ConfigUtil.saveObj<DisplayConfig>(new List<DisplayConfig>() { { display } }, displayField);
        }
        /// <summary>
        /// 保存热键配置
        /// </summary>
        public static void saveHotKey()
        {
            ConfigUtil.saveObj<HotKey>(hotKeys, hotKeyField);
        }


    }
}
