using BaitGate.Models.EFContext;

namespace BaitGate.Models.DTO
{
    public class FileHEDDownloadResponse
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public string? Content { get; set; }
        public string? MediaType { get; set; }
        public string? Name { get; set; }
        public string? Href { get; set; }
        public FileHEDDownloadResponse(FileHED fileHED)
        {
            this.Content = fileHED.Content!=null?Convert.ToBase64String(fileHED.Content):null;
            this.MediaType=fileHED.MediaType;
            this.Name = fileHED.Name;
            this.Href = fileHED.Href;
        }
        public FileHEDDownloadResponse()
        {

        }
  
    }
}
