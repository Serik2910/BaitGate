using BaitGate.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaitGate.Models.EFContext
{
    public class DocumentState
    {
        [Key]
        public int Id { get; set; }
        public string? Href { get; set; }
        public long? From { get; set; }
        public long Client { get; set; }
        public string? StateDate { get; set; }
        public int? StateType { get; set; } // 0-delivery, 1-registered; 2-not registered, 3-execution, 4 - finished 
        public string? RegNo { get; set; }
        public string? ExecDate { get; set; }
        public string? Executive { get; set; }
        public string? isValidReason { get; set; }
        public string? Author { get; set; }
        public string? ExecutivePhone { get; set; }
        public string? FinishDate { get; set; }
        [JsonIgnore]
        public bool? isSent { get; set; }
        [JsonIgnore]
        public string? error { get; set; }
        public DocumentState()
        {

        }
        public DocumentState(DocumentStateDTO documentStateDTO, long i)
        {
            this.StateDate = documentStateDTO.StateDate;
            this.StateType = documentStateDTO.StateType;
            this.RegNo = documentStateDTO.RegNo;
            this.ExecDate = documentStateDTO.ExecDate;
            this.Executive = documentStateDTO.Executive;
            this.FinishDate = documentStateDTO.FinishDate;
            this.From = documentStateDTO.MetaData.From;
            this.Href = documentStateDTO.MetaData.Href;
            this.Author = documentStateDTO.Author;
            this.Client = i;
        }
    }
}
