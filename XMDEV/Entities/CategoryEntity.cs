using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMDEV.Entities
{
    [Table("CATEGORY")]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string ChatLieu { get; set; }
        public string KichThuoc { get; set; }
        public string MauSacBan { get; set; }
        public int BaoHanh { get; set; }
    }
}
