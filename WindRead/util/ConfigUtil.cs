using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindRead.bean;
using WindRead.cache;
using WindRead.constants;

namespace WindRead.util
{
    /// <summary>
    /// 阅读配置工具类
    /// </summary>
    public class ConfigUtil
    {



        /// <summary>
        /// 检查修复配置文件
        /// </summary>
        public static void repairXml()
        {
            String cfgurl = Constants.configPath;
            //无则创建文件夹
            if (!Directory.Exists(cfgurl)) Directory.CreateDirectory(cfgurl);
            //无则创建配置文件
            String xmlUrl = cfgurl + Constants.configName;
            if (!File.Exists(xmlUrl)) File.Create(xmlUrl).Close();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(xmlUrl);
            }
            catch (Exception)
            {
                doc.RemoveAll();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
                XmlElement root = doc.CreateElement("Configuration");
                root.InnerText = "";
                doc.AppendChild(root);
                doc.Save(xmlUrl);
                CommonUtil.saveLog("初始化配置文件");
            }
            XmlElement baseNode = doc.DocumentElement;
            if (baseNode == null)
            {
                CommonUtil.saveLog("获取DocumentElement失败");
                return;
            }
            String[] nodes = { ConfigCache.booksField, ConfigCache.markersField, ConfigCache.hotKeyField, ConfigCache.displayField, ConfigCache.themeField };
            foreach (String node in nodes)
            {
                if (baseNode.SelectSingleNode(node) == null)
                {
                    XmlElement book = doc.CreateElement(node);
                    book.InnerText = "";
                    baseNode.AppendChild(book);
                }
            }
            doc.Save(xmlUrl);
        }



        /// <summary>
        /// 加载配置初始化
        /// </summary>
        public static void Init()
        {
            repairXml();
            //所有热键说明
            ConfigCache.keyDescMap = getMap("AllKeyDesc");
            //预置颜色列表
            List<ThemeConf> presetColor = getByFileName<ThemeConf>("DefaultPresetColor");
            ConfigCache.presetColors= presetColor.ConvertAll<ThemeInfo>(( x) => x.toThemeInfo()).ToList();

            //自定义配置
            String xmlUrl = Constants.configPath + Constants.configName;
            if (File.Exists(xmlUrl))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlUrl);
                    //书籍
                    ConfigCache.books = getList<Book>(doc, ConfigCache.booksField);
                    //书签
                    ConfigCache.markers = getList<Book>(doc, ConfigCache.markersField);

                    //设置
                    ConfigCache.display = getOne<DisplayInfo>(doc, ConfigCache.displayField);
                    //颜色
                    ThemeConf themeConf = getOne<ThemeConf>(doc, ConfigCache.themeField);
                    if (themeConf != null && CommonUtil.notBlank(themeConf.BackColor))
                    {
                        ConfigCache.theme = themeConf.toThemeInfo();
                    }
                    else {
                        ConfigCache.theme = ConfigCache.presetColors[0];
                    }
                   

                    //热键
                    ConfigCache.hotKeys = getList<HotKey>(doc, ConfigCache.hotKeyField);
                    if (ConfigCache.hotKeys == null || ConfigCache.hotKeys.Count == 0)
                    {
                        ConfigCache.hotKeys = HotKey.Default();
                        ConfigCache.saveHotKey();
                    }
                    //转map
                    ConfigCache.hotKeyMap = ConfigCache.hotKeys.ToDictionary(i => i.keyCode, i => i.effect);
                }
                catch (Exception e)
                {
                    CommonUtil.saveLog("解析xml异常！" + e.Message);
                    MessageBox.Show("解析xml异常！" + e.Message);
                }
            }
        }

        /// <summary>
        /// 获取指定配置列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private static List<T> getList<T>(XmlDocument doc, String nodeName) where T : new()
        {
            XmlNode node = doc.SelectSingleNode("//" + nodeName);
            if (node != null && node.ChildNodes.Count > 0)
            {
                return toList<T>(node.ChildNodes);
            }
            return new List<T>();
        }


        /// <summary>
        /// 获取指定配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doc"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private static T getOne<T>(XmlDocument doc, String nodeName) where T : new()
        {
            List<T> values = getList<T>(doc, nodeName);
            if (values.Count > 0)
            {
                return values[0];
            }
            return new T();
        }



        /// <summary>
        /// XmlNodeList转list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="childList"></param>
        /// <returns></returns>
        public static List<T> toList<T>(XmlNodeList childList) where T : new()
        {
            List<T> list = new List<T>();
            foreach (XmlNode xn in childList)
            {
                var md = new T();
                if (CommonUtil.isBlank(xn.InnerText)) continue;
                foreach (XmlNode field in xn.ChildNodes)
                {
                    PropertyInfo info = md.GetType().GetProperty(field.Name);
                    if (info != null) info.SetValue(md, Convert.ChangeType(field.InnerText, info.PropertyType));
                }
                list.Add(md);
            }
            return list;
        }



        /// <summary>
        /// XmlNodeList转map
        /// </summary>
        /// <param name="childList"></param>
        /// <returns></returns>
        public static Dictionary<string, string> toMap(XmlNodeList childList)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            foreach (XmlNode xn in childList)
            {
                if (CommonUtil.isBlank(xn.InnerText)) continue;
                String key = null;
                String value = null;
                foreach (XmlNode field in xn.ChildNodes)
                {
                    if ("Key".Equals(field.Name))
                    {
                        key = field.InnerText;
                    }
                    else if ("Value".Equals(field.Name))
                    {
                        value = field.InnerText;
                    }
                    if (CommonUtil.notBlank(key) && CommonUtil.notBlank(value))
                    {
                        map.Add(key, value);
                    }
                }
            }
            return map;
        }


        /// <summary>
        /// 从xml文件中获取默认设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> getByFileName<T>(String fileName) where T : new()
        {
            try
            {
                Dictionary<string, string> map = new Dictionary<string, string>();
                ResourceManager rm = new ResourceManager(Constants.resourcesPath, Assembly.GetEntryAssembly());
                Object obj = rm.GetObject(fileName);
                if (obj != null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(obj.ToString());
                    return toList<T>(doc.ChildNodes[2].ChildNodes);
                }
            }
            catch (Exception e)
            {
                CommonUtil.saveLog("从Xml中获取默认设置失败！文件名:" + fileName + ";" + e.Message);
            }
            return new List<T>();
        }


        /// <summary>
        /// 将对象集合写入xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int saveObj<T>(List<T> list, String nodeName) where T : new()
        {
            if (list == null || list.Count == 0)
                return 0;
            repairXml();
            Type type = new T().GetType();
            String xmlUrl = Constants.configPath + Constants.configName;
            if (File.Exists(xmlUrl))
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlUrl);
                    XmlNode xn = doc.SelectSingleNode("//" + nodeName);
                    xn.RemoveAll();
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlElement node = doc.CreateElement("item");
                        foreach (PropertyInfo pi in type.GetProperties())
                        {
                            if (!Constants.filterField.Contains(pi.Name))
                            {
                                object value = pi.GetValue(list[i], null);//用pi.GetValue获得值
                                XmlElement element = doc.CreateElement(pi.Name);
                                element.InnerText = Convert.ToString(value);
                                node.AppendChild(element);
                            }
                        }
                        xn.AppendChild(node);
                        XmlElement node2 = doc.CreateElement("item");
                    }
                    doc.Save(Constants.configPath + Constants.configName);
                    return list.Count;
                }
                catch (Exception e)
                {
                    CommonUtil.saveLog("写入xml异常！" + e.Message);
                    MessageBox.Show("写入xml异常！" + e.Message);
                }
            }
            return 0;
        }

        /// <summary>
        /// 从Xml中获取数据并转为Map
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Dictionary<string, string> getMap(String fileName)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            ResourceManager rm = new ResourceManager(Constants.resourcesPath, Assembly.GetEntryAssembly());
            Object obj = rm.GetObject(fileName);
            if (obj == null) return map;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(obj.ToString());
                XmlNodeList childList = doc.SelectSingleNode(fileName).ChildNodes;
                return toMap(childList);
            }
            catch (Exception e)
            {
                CommonUtil.saveLog("从Xml中获取数据并转为Map异常！文件名:" + fileName + ";" + e.Message);
            }
            return map;
        }

    }
}
