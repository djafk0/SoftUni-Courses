using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesXmlDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        public PurchaseType? Type { get; set; }

        [Required]
        [RegularExpression("[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        public string Key { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Card { get; set; }
        //      <Purchase title = "Dungeon Warfare 2" >
        //  < Type > Digital </ Type >
        //  < Key > ZTZ3 - 0D2S-G4TJ</Key>
        //  <Card>1833 5024 0553 6211</Card>
        //  <Date>07/12/2016 05:49</Date>
        //</Purchase>

    }
}
