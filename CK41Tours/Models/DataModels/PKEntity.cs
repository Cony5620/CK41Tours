using CK41Tours.Utility;
using System.ComponentModel.DataAnnotations;

namespace CK41Tours.Models.DataModels
{
  
    public abstract class PKEntity
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; } = "001";
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Ip { get; set; }= NetWorkHelper.GetLocalIPAddress();
        public string? Remark { get; set; }
        public bool IsInActive { get; set; }
    }
}
