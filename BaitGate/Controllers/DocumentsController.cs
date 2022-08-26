using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaitGate.Models.EFContext;
using BaitGate.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using BaitGate.Services;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace BaitGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly SEDContext _context;
        private IClientServices _clientServices;
        private readonly ILogger<HEDController> _logger;

        public DocumentsController(SEDContext context, IClientServices clientServices, ILogger<HEDController> logger)
        {
            _context = context;
            _clientServices = clientServices;
            _logger = logger;
        }
        // GET: api/Documents/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<DocumentDownloadResponse>> GetDocument(string id)
        {
            DocumentDownloadResponse documentDownloadResponse = new DocumentDownloadResponse();
            try
            {
                if (_context.Documents == null)
                {
                    throw new Exception("Error on database");
                }
                var document = await _context.Documents.FindAsync(id);
                
                if (document == null)
                {
                    throw new Exception("document not found");
                }
                DocumentDTO documentDTO = new DocumentDTO(document);
                documentDownloadResponse.Status=1;
                documentDownloadResponse.DocumentDTO = documentDTO;
            }
            catch(Exception e)
            {
                documentDownloadResponse.Error = e.Message;
                documentDownloadResponse.Status = 0;
                
            }

            return documentDownloadResponse;
        }
        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<DocumentUploadResponse>> PostDocument(DocumentDTO documentDTO)
        {
            DocumentUploadResponse documentUploadResponse = new DocumentUploadResponse();
            try
            {
                if(documentDTO?.MetaData?.Performers == null)
                {
                    throw new Exception("No data of performers");
                }
                foreach (long i in documentDTO.MetaData.Performers)
                {
                    Document document = new Document(documentDTO, i);


                    if (_context.Documents == null)
                    {
                        throw new Exception("Entity set 'SEDContext.Documents'  is null.");
                    }
                    if (User?.Identity?.Name!=null && document.From != long.Parse(User.Identity.Name))
                    {
                        throw new Exception("try to send document using odd id");
                    }
                    _context.Documents.Add(document);
                    try
                    {
                        await _context.SaveChangesAsync();
                        documentUploadResponse.Status = 1;
                        await SendDocument(document);
                    }
                    catch (DbUpdateException)
                    {
                        if (DocumentExists(document.Href))
                        {
                            throw new Exception("document have already created");
                        }
                        else
                        {
                            throw new Exception("problem with database write");
                        }
                    }
                    catch(Exception e)
                    {
                        throw new Exception(e.Message);
                    }

                }
            }catch(Exception e)
            {
                documentUploadResponse.Status = 0;
                documentUploadResponse.Error = e.Message;
            }

            return documentUploadResponse;
        }


        private bool DocumentExists(string? id)
        {
            return (_context.Documents?.Any(e => e.Href == id)).GetValueOrDefault();
        }

        private async Task SendDocument(Document document)
        {
            HttpClient client = new HttpClient();
            try
            {
                if(_clientServices.Clients == null){
                    throw new Exception("problem with db clients");
                }
                string address = _clientServices.Clients.First(p => p.Id == document.Client).URLDocument;
                
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string jsonString = JsonSerializer.Serialize(document);
                var response = await client.PostAsync(address,new StringContent(jsonString, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                document.isSent = true;
                var contents = await response.Content.ReadAsStringAsync();
                DocResponse? docResponse = JsonSerializer.Deserialize<DocResponse>(contents);
                if (docResponse == null)
                {
                    throw new Exception("problem with deserialization DocResponse");
                }
                if(docResponse.status == 0)
                {
                    throw new Exception(docResponse.date + " : " + docResponse.error);
                }
                document.hrefAssigned = docResponse.href;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                document.isSent = false;
                document.error = e.Message;
            }
            await _context.SaveChangesAsync();
        }
        
    }
}
