using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class AExport
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public BExport[] Users { get; set; }
    }
}
