using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaitGate.Models.DTO
{
    public class MetaData
    {
        public string Href { get; set; } = null!;
        public long From { get;  set; }
        public List<long> Performers { get; set; } = null!;

    }
}
