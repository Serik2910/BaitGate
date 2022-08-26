using BaitGate.Models.DTO;
using BaitGate.Models.EFContext;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BaitGate.Services
{
    public class ClientServices : IClientServices
    {
        private List<Client>? clients;
        private readonly SEDContext _context;
        private readonly IConfiguration configuration;

        public List<Client>? Clients { get => clients;  }

        public ClientServices(SEDContext context, IConfiguration configuration)
        {

            _context = context;
            this.clients = _context.Clients?.ToList();
            this.configuration = configuration;
        }

        public void CreatePasswordHash(string password,
        out byte[] passwordHash,
        out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public IEnumerable<Claim> GetClaims(Client client)
        {
            var claims = new List<Claim>();
            if (client.Name != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, client.Id.ToString()));
            }
            //if (client.Roles != null)
            //{
            //    foreach (var role in client.Roles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, role.Name));
            //    }
            //}
            return claims;
        }

        public Client? Login(ClientDTO clientDTO)
        {
            Client? client = Clients?.SingleOrDefault(u => u.Name == clientDTO.Name);
            if (client != null && VerifyPasswordHash(clientDTO.Password, client.PasswordHash, client.PasswordSalt))
            {
                return client;
            }
            return null;
        }

        public bool VerifyPasswordHash(string? password, byte[]? passwordHash, byte[]? passwordSalt)
        {
            if (password == null || passwordHash == null || passwordSalt == null)
            {
                return false;
            }
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        public string CreateToken(Client client)
        {
            IEnumerable<Claim> claims = GetClaims(client);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration["AppSettings:Token"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
