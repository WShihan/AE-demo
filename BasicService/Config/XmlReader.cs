using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using framework.Interface;

namespace BasicService.configratior
{
    public class XMLReader:IXMLReader
    {
        private XmlDocument xmlDoc;
        private static XMLReader _xmlReader;
        private XMLReader()
        {
            string xmlPath = Path.Combine(Application.StartupPath, "test.xml");
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
        }
        public static XMLReader Instance
        {
            get
            {
                if (_xmlReader != null)
                {
                    return _xmlReader;
                }
                else
                {
                    _xmlReader = new XMLReader();
                    return _xmlReader;
                }
            }
        }
        /// <summary>
        /// 读取节点
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public XmlNode Read(string nodeName)
        {
            XmlNodeList nodes = xmlDoc.SelectNodes(nodeName);
            if (nodes.Count > 0)
            {
                return nodes[0];
            }
            return null;
        }
        /// <summary>
        /// 通过节点读取文本
        /// </summary>
        /// <param name="nodeObj"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string Read(XmlNode nodeObj, string nodeName)
        {
            return nodeObj.SelectSingleNode("mxd").InnerText;
        }
        /// <summary>
        /// 读取节点属性
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        public string Read(string nodeName, string attrName)
        {
            XmlNode node = _xmlReader.xmlDoc.SelectSingleNode(nodeName);
            if (node != null)
            {
                return node.Attributes[attrName].Value.ToString();
            }
            else
            {
                return null;
            }
        }
        public string ReadText(string nodeName)
        {
            return xmlDoc.SelectSingleNode(nodeName).InnerText;
        }
    }
}
