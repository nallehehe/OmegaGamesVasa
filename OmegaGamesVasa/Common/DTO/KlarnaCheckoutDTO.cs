using Common.DTO.Klarna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class KlarnaCheckoutDTO
    {
        public KlarnaCheckoutDTO() { }

        public string purchase_country { get; set; }
        public string purchase_currency { get; set; }
        public string locale { get; set; }
        public string status { get; set; }
        public int order_amount { get; set; }
        public int order_tax_amount { get; set; }
        public List<KlarnaOrderProductDTO> order_lines { get; set; }
        public string? merchant_reference1 { get; set; }
        public KlarnaMerchantUrlsDTO merchant_urls { get; set; }
    }
}
