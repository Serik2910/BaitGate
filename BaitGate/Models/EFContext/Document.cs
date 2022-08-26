using BaitGate.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaitGate.Models.EFContext
{
    public class Document
    {
        
        public string Href { get; set; } = null!;
        public long From { get; set; }
        public long Client { get; set; }
        public List<string>? Attachments { get; set; }
        public string? AppendCount { get; set; }
        public string? AuthorName { get; set; }
        public string? ControlTypeOuterName { get; set; }
        public string? Description { get; set; }
        public string? DocDate { get; set; }
        public string? DocLang { get; set; }
        public string? DocNo { get; set; }
        public string? DocToNumber { get; set; }
        public string? EmployeePhone { get; set; }
        public string? ExecutionDate { get; set; }
        public string? Executor { get; set; }
        public string? OutTime { get; set; }
        public string? ResolutionText { get; set; }
        public string? SheetCount { get; set; }
        public string? SignerName { get; set; }
        public string? SignObject { get; set; }
        [JsonIgnore]
        public bool? isSent { get; set; }
        [JsonIgnore]
        public string? error { get; set; }
        [JsonIgnore]
        public string? hrefAssigned { get; set; }
        public Document(){}
        public Document(DocumentDTO documentDTO, long client)
        {
            Href = documentDTO.MetaData.Href;
            From = documentDTO.MetaData.From;
            Client = client;
            Attachments = documentDTO.Attachments;
            AppendCount = documentDTO.AppendCount;
            AuthorName = documentDTO.AuthorName;
            ControlTypeOuterName = documentDTO.ControlTypeOuterName;
            Description = documentDTO.Description;
            DocDate = documentDTO.DocDate;
            DocLang = documentDTO.DocLang;
            DocNo = documentDTO.DocNo;
            DocToNumber = documentDTO.DocToNumber;
            EmployeePhone = documentDTO.EmployeePhone;
            ExecutionDate = documentDTO.ExecutionDate;
            Executor = documentDTO.Executor;
            OutTime = documentDTO.OutTime;
            ResolutionText = documentDTO.ResolutionText;
            SheetCount = documentDTO.SheetCount;
            SignerName = documentDTO.SignerName;
            SignObject = documentDTO.SignObject;

        }
    }
}
