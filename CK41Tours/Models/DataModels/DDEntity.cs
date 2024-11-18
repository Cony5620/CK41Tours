using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CK41Tours.Models.DataModels
{
    [Table("DD")]
    public class DDEntity:PKEntity
    {
        public string DD01 { get; set; }
        public string DD02 { get; set; }
        public string DD03 { get; set; }
        public string DD04 { get; set; }
        public string? DD05 { get; set; }
        public string DD06 { get; set; }
        public string DD07 { get; set; }
        public string DD08 { get; set; }
        public string DD09 { get; set; }
        public string DD10 { get; set; }
        public string DD11 { get; set; }
    }
}

