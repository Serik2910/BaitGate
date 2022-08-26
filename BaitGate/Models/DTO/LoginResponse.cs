namespace BaitGate.Models.DTO
{
    public class LoginResponse
    {
        public int Status { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
       
    }
}
