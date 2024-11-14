using System.ComponentModel.DataAnnotations.Schema;

namespace CK41Tours.Models.DataModels
{
    [Table("TG")]
    public class TGEntity:PKEntity
    {
        public string TG01 { get; set; }
        public string TG02 { get; set; }
    }
}
