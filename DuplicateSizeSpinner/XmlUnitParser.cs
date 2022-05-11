using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DuplicateSizeSpinner
{
    public class XmlUnitParser
    {
        XmlDocument xmlDoc;
        public UnitPairs Pairs { get; set; }
        public void LoadFile(string xmlPath)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            for (int i = 0; i < xmlDoc.LastChild.ChildNodes.Count; i++)
            {
                XmlNode node = xmlDoc.LastChild.ChildNodes[i];
                if (node.ChildNodes.Count != 2)
                    throw new Exception("xml inconsistent");
                Pairs.AddPair(node.FirstChild.InnerText, node.LastChild.InnerText);
            }
        }
    }
}
