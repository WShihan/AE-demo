using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace BasicService.configratior
{
    public class XmlReader
    {
        private XmlDocument _xmlDoc;

        public XmlReader()
        {
            string xmlPath = Path.Combine(Application.StartupPath, "AppConfig.xl");
            _xmlDoc = new XmlDocument();
            _xmlDoc.LoadXml(xmlPath);
        }
        public XmlNode Read(string nodeName)
        {
            XmlNodeList node = _xmlDoc.GetElementsByTagName(nodeName);
            if (node.Count > 0)
            {
                return node[0];
            }
            return null;
        }
        public XmlNode Read(XmlNode nodeObj, string nodeName)
        {

        }
    }
}
