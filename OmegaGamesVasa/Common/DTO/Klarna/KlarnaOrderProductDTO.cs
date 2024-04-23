using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Klarna
{
    public class KlarnaOrderProductDTO
    {
        public string type { get; set; }
        public string reference { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public KlarnaSubscriptionDTO subscription { get; set; }
        public string quantity_unit { get; set; }
        public int unit_price { get; set; }
        public int tax_rate { get; set; }
        public int total_amount { get; set; }
        public int total_discount_amount { get; set; }
        public int total_tax_amount { get; set; }
        public string merchant_data { get; set; }
        public string product_url { get; set; }
        public string image_url { get; set; }
        public Product_Identifiers product_identifiers { get; set; }
        public Shipping_Attributes shipping_attributes { get; set; }
    }
}
