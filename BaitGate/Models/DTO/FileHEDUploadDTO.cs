using BaiterekGateway.Models;

namespace BaitGate.Models.DTO
{
    public class FileHEDUploadDTO
    {
        public string? Href { get; set; }
        public List<FileHEDUpload>? fileHEDs { get; set; }
    }
}
