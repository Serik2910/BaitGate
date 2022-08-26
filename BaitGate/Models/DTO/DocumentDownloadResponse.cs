namespace BaitGate.Models.DTO
{
    public class DocumentDownloadResponse
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public DocumentDTO? DocumentDTO { get; set; }
    }
}
