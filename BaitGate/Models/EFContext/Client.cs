using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaitGate.Models.EFContext
{
    [Table("clients")]
    public class Client
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string URLDocument { get; set; } = null!;
        public string URLState { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
