using BaitGate.Models.DTO;
using BaitGate.Models.EFContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaitGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HEDController : ControllerBase
    {
        private readonly ILogger<HEDController> _logger;
        SEDContext sEDContext;

        public HEDController(ILogger<HEDController> logger, SEDContext context)
        {
            _logger = logger;
            this.sEDContext = context;
        }
        // GET: api/<HED>/upload
        [HttpPost("upload")]
        [Authorize]
        public FileHEDUploadResponse fileUpload([FromBody] FileHEDUploadDTO fileHEDUploadRequest)
        {

            FileHEDUploadResponse fileHEDUploadResponse = new FileHEDUploadResponse();
            try
            {
                if (fileHEDUploadRequest?.fileHEDs != null)
                {
                    foreach (var f in fileHEDUploadRequest.fileHEDs)
                    {
                        if (f != null  && f.Name != null) //&& f.Content != null
                        {
                            FileHED fileHED = new FileHED(f, fileHEDUploadRequest.Href);
                            sEDContext.Add(fileHED);
                            sEDContext.SaveChanges();
                            fileHEDUploadResponse.fileIDs.Add(fileHED.Id.ToString());
                        }
                        else
                        {
                            throw new Exception("info in fileHED is not correct");
                        }
                    }
                    fileHEDUploadResponse.Status = 1;
                }
                else
                {
                    throw new Exception("no files");
                }
            }catch(Exception e)
            {
                fileHEDUploadResponse.Status = 0;
                fileHEDUploadResponse.Error = e.Message;
                _logger.LogError(e, e.StackTrace);
            }
            return fileHEDUploadResponse;
        }

        // GET api/<HED>/download/70038bc0-0170-40ea-8f71-3da28aa1b669
        [HttpGet("download/{id}")]
        [Authorize]
        public FileHEDDownloadResponse Get(string id)
        {
            FileHEDDownloadResponse fileHEDDownloadResponse;
            var res = sEDContext?.fileHED?.Where(a => a.Id == id).ToList();
            FileHED? fileHED = res.FirstOrDefault();
            
            if(fileHED != null)
            {
                fileHEDDownloadResponse = new FileHEDDownloadResponse(fileHED);
                fileHEDDownloadResponse.Status = 1;
            }
            else
            {
                fileHEDDownloadResponse = new FileHEDDownloadResponse();
                fileHEDDownloadResponse.Status = 0;
                fileHEDDownloadResponse.Error = "file not found";
            }
            return fileHEDDownloadResponse;
        }

        // POST api/<HED>/listIds
        [HttpGet("listIds/{id}")]
        [Authorize]
        public List<string> listIds(string id)
        {
            var res = sEDContext.fileHED.Where(a => a.Href == id).Select(a => a.Id).ToList();
            return res;
        }

       
    }
}
