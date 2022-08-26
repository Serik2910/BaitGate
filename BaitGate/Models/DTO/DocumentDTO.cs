using BaitGate.Models.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace BaitGate.Models.DTO
{
    public class DocumentDTO
    {
        public MetaData MetaData { get; set; } = null!;
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
        public DocumentDTO()
        {

        }
        public DocumentDTO(Document document )
        {
            
            this.AppendCount=document.AppendCount;
            this.AuthorName=document.AuthorName;
            this.ControlTypeOuterName=document.ControlTypeOuterName;
            this.Description=document.Description;
            this.DocDate=document.DocDate;
            this.DocLang=document.DocLang;
            this.DocNo=document.DocNo;
            this.DocToNumber=document.DocToNumber;
            this.EmployeePhone=document.EmployeePhone;
            this.ExecutionDate=document.ExecutionDate;
            this.Executor=document.Executor;
            this.OutTime=document.OutTime;
            this.ResolutionText=document.ResolutionText;
            this.SheetCount=document.SheetCount;
            this.SignerName=document.SignerName;
            this.SignObject=document.SignObject;
            List<long> performers = new List<long>();
            performers.Add(document.Client);
            this.MetaData = new MetaData()
            {
                From = document.From,
                Href = document.Href,
                Performers = performers
            };
            this.Attachments = document.Attachments;
        }
    }
}
