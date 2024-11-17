using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// ammt 20241117

namespace CK41Tours.Models.DataModels
{
    [Table("TT")]
    public class TTEntity:PKEntity
    {
        public string TT01 { get; set; }
        public string? TT02 { get; set; }
        public string TT03 { get; set; }
    }
}
