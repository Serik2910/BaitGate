using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MySqlConnector;
using System.Text.Json;

namespace BaitGate.Models.EFContext
{
    public class SEDContext: DbContext
    {
        public DbSet<User>? Users { get; set; } = null;
        public DbSet<Client>? Clients { get; set; } = null;
        public DbSet<Document>? Documents { get; set; } = null;
        public DbSet<DocumentState>? DocumentStates { get; set; } = null;
        public DbSet<FileHED>? fileHED { get; set; } = null;
        public DbSet<Role>? Roles { get; set; } = null;
        public SEDContext(DbContextOptions<SEDContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasKey(u => new { u.Href, u.Client });
            modelBuilder.Entity<Document>().Property(e => e.Attachments).HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null)
                , v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<List<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));
        }
    }
}
