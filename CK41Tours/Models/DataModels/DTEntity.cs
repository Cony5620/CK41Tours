using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CK41Tours.Models.DataModels
{
    [Table("DT")]
    public class DTEntity:PKEntity
    {
        public string DT01 { get; set; }
        public string? DT02 { get; set; }
        public string DT03 { get; set; }
    }
}
