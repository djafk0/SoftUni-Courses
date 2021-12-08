using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersAndPrisonersXmlDto
    {

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Money { get; set; }

        public string Position { get; set; }

        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        public ImportPrisonersDto[] Prisoners { get; set; }
    }
}
