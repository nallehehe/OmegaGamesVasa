using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Klarna
{
    public class KlarnaMerchantUrlsDTO
    {
        public string terms { get; set; }
        public string checkout { get; set; }
        public string confirmation { get; set; }
        public string push { get; set; }
        public string validation { get; set; }
        public string notification { get; set; }
        public string cancellation_terms { get; set; }
        public string shipping_option_update { get; set; }
        public string address_update { get; set; }
        public string country_change { get; set; }
    }
}
