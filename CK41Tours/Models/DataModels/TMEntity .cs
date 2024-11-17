using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CK41Tours.Models.DataModels
{
    [Table("TM")]
    public class TMEntity:PKEntity
    {
        public string TM01 { get; set; }
        public string TM02 { get; set; }
        public string TM03 { get; set; }
        public string TM04 { get; set; }
        public string? TM05 { get; set; }
    }
}
