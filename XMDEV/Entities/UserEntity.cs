using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMDEV.Entities
{
    [Table("LOGINU")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
    }
}
