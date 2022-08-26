namespace BaitGate.Models.DTO
{
    public class DocumentStateDTO
    {
        public MetaData MetaData { get; set; } = null!;
        public string? StateDate { get; set; }
        public int? StateType { get; set; } // 0-delivery, 1-registered; 2-not registered, 3-execution, 4 - finished 
        public string? RegNo { get; set; }
        public string? ExecDate { get; set; }
        public string? Executive { get; set; }
        public string? ExecutivePhone { get; set; }
        public string? isValidReason { get; set; }
        public string? Author { get; set; }
        public string? FinishDate { get; set; }
    }
}
