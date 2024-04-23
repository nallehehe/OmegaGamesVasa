using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Klarna
{
    public class KlarnaCustomerDTO
    {
        public string type { get; set; }
        public string gender { get; set; }
        public string date_of_birth { get; set; }
        public string organization_registration_id { get; set; }
        public string vat_id { get; set; }
    }
}
