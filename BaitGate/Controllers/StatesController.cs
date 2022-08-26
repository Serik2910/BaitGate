using BaitGate.Models.DTO;
using BaitGate.Models.EFContext;
using BaitGate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BaitGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly SEDContext _context;
        private IClientServices _clientServices;
        private readonly ILogger<HEDController> _logger;

        public StatesController(SEDContext context, IClientServices clientServices, ILogger<HEDController> logger)
        {
            _context = context;
            _clientServices = clientServices;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<StateUploadResponse>> PostDocument(DocumentStateDTO DocumentStateDTO)
        {
            StateUploadResponse stateUploadResponse = new StateUploadResponse();
            try
            {
                if (DocumentStateDTO?.MetaData?.Performers == null)
                {
                    throw new Exception("No data of performers");
                }
                foreach (long i in DocumentStateDTO.MetaData.Performers)
                {
                    DocumentState documentState = new DocumentState(DocumentStateDTO, i);
                    if (_context.DocumentStates == null)
                    {
                        throw new Exception("Entity set 'SEDContext.DocumentStates' is null.");
                    }
                    if (User?.Identity?.Name != null && documentState.From != long.Parse(User.Identity.Name))
                    {
                        throw new Exception("try to send document using odd id");
                    }
                    _context.DocumentStates.Add(documentState);

                    await _context.SaveChangesAsync();
                    stateUploadResponse.Status = 1;
                    await SendState(documentState);
                }
            }
            catch (Exception e)
            {
                stateUploadResponse.Status = 0;
                stateUploadResponse.Error = e.Message;
            }
            return stateUploadResponse;
        }

        private async Task SendState(DocumentState documentState)
        {
            
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (_clientServices.Clients == null)
                    {
                        throw new Exception("problem with db clients");
                    }
                    string address = _clientServices.Clients.First(p => p.Id == documentState.Client).URLState;

                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    string jsonString = JsonSerializer.Serialize(documentState);
                    var response = await client.PostAsync(address, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    documentState.isSent = true;
                    var contents = await response.Content.ReadAsStringAsync();
                    DocResponse? docResponse = JsonSerializer.Deserialize<DocResponse>(contents);
                    if (docResponse == null)
                    {
                        throw new Exception("problem with deserialization DocResponse");
                    }
                    if (docResponse.status == 0)
                    {
                        throw new Exception(docResponse.date + " : " + docResponse.error);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                documentState.isSent = false;
                documentState.error = e.Message;
            }
            await _context.SaveChangesAsync();
        }
    }
}
