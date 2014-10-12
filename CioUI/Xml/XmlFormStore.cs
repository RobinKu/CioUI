using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CioUI.Xml
{
    internal class XmlFormStore : IFormStore
    {
        private readonly XmlDocument xmlDoc;

        public XmlFormStore(Stream xml)
        {
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.Load(xml);
        }

        public string GetRenderType()
        {
            return this.xmlDoc.SelectSingleNode("/cioUIApplication/@renderType").Value;
        }
    }
}
