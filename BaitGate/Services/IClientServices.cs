using BaitGate.Models.DTO;
using BaitGate.Models.EFContext;
using System.Security.Claims;

namespace BaitGate.Services
{
    public interface IClientServices
    {
        public Client? Login(ClientDTO clientDTO);

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        public IEnumerable<Claim> GetClaims(Client client);
        public string CreateToken(Client client);
        public List<Client>? Clients { get ; }
    }
}
