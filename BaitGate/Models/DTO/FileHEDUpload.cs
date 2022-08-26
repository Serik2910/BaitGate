using BaitGate.Models.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiterekGateway.Models
{
    public class FileHEDUpload
    {
        public string Content { get; set; } = null!;
        public string? MediaType { get; set; }
        public string? Name { get; set; }
       
        public long? LifeTime { get; set; }
    }
}
