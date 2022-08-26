using BaitGate.Models.EFContext;

namespace BaitGate.Models.DTO
{
    public class ClientDict
    {
        public long Id { get; set; }
        public string CompanyName { get; set; } = null!;

        public ClientDict()
        {

        }
        public ClientDict(Client client )
        {
            this.CompanyName = client.CompanyName;
            this.Id = client.Id;
        }
    }
}
