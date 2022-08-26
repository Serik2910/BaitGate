using BaiterekGateway.Models;
using System.ComponentModel.DataAnnotations;


namespace BaitGate.Models.EFContext
{
    public class FileHED
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; } = null!;
        public byte[]? Content { get; set; } 
        public string? MediaType { get; set; }
        public string? Name { get; set; }
        public long? LifeTime { get; set; }
        public string? Href { get; set; }
        public DateTime? Created { get; set; }
        public FileHED()
        {

        }
        public FileHED(FileHEDUpload fileHEDUpload, string? href)
        {
            Id = Guid.NewGuid().ToString();
            Content = Convert.FromBase64String(fileHEDUpload.Content);
            MediaType = fileHEDUpload.MediaType;
            Name = fileHEDUpload.Name;
            LifeTime = fileHEDUpload.LifeTime;
            Href = href;
            Created = DateTime.Now;
        }
    }
}
