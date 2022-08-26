using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaitGate.Models.EFContext
{
    [Table("users")]
    public class User
    {
        [Column("UserName")]
        [Key]
        public string UserName { get; set; } = string.Empty;

        public List<Role> Roles { get; set; } = null!;

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
