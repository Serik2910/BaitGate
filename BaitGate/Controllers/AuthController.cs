using BaitGate.Models.DTO;
using BaitGate.Models.EFContext;
using BaitGate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaitGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IClientServices _clientServices;

        public AuthController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(ClientDTO clientDTO)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                var client = _clientServices.Login(clientDTO);
                if (client == null)
                {
                    throw new Exception("Username is incorrect");
                }
                if (clientDTO.Password!=null && !_clientServices.VerifyPasswordHash(
                    clientDTO.Password,
                    passwordSalt: client.PasswordSalt,
                    passwordHash: client.PasswordHash))
                {
                    throw new Exception("Password is incorrect");
                }
                loginResponse.Token = _clientServices.CreateToken(client);
                loginResponse.Status = 1;
            }
            catch(Exception e)
            {
                loginResponse.Error = e.Message;
                loginResponse.Status = 0;
            }
            ;
            return loginResponse;
        }

    }
}
