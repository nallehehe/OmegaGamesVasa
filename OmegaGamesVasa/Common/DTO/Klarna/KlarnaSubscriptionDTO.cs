using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Klarna
{
    public class KlarnaSubscriptionDTO
    {
        public string name { get; set; }
        public string interval { get; set; }
        public int interval_count { get; set; }
    }
}
