using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace BasicService.configratior
{
    public class XMLReader
    {
        private XmlDocument xmlDoc;
        private static XMLReader _xmlReader;
        private XMLReader()
        {
            string xmlPath = Path.Combine(Application.StartupPath, "test.xml");
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
        }
        public XmlNode Read(string nodeName)
        {
            XmlNodeList nodes = xmlDoc.SelectNodes(nodeName);
            if (nodes.Count > 0)
            {
                return nodes[0];
            }
            return null;
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
        public string Read(XmlNode nodeObj, string nodeName)
        {
            return nodeObj.SelectSingleNode("mxd").InnerText;
        }
    }
}
