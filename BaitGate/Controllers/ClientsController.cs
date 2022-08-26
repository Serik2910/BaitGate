using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaitGate.Models.EFContext;
using BaitGate.Models.DTO;

namespace BaitGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly SEDContext _context;

        public ClientsController(SEDContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDict>>> GetClients()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var clients =  await _context.Clients.ToListAsync();
            List<ClientDict> result = new List<ClientDict>();
            foreach (var client in clients)
            {
                result.Add(new ClientDict(client));
            }
            return result;
        }

    }
}
