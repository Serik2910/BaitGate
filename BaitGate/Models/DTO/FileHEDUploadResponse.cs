namespace BaitGate.Models.DTO
{
    public class FileHEDUploadResponse
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public List<string> fileIDs { get; set; } = new List<string>();
    }
}
