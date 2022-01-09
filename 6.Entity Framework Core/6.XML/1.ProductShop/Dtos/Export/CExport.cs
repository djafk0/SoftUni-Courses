using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class CExport
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public DExport[] Products { get; set; }
    }
}
