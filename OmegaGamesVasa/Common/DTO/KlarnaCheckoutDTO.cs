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
        public List<KlarnaOrderItemDTO> order_lines {  get; set; }
        public string? merchant_reference1 { get; set; }
        
    }

    public class KlarnaOrderItemDTO
    {
        public string? type { get; set; }
        public string? reference { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string? quantity_unit { get; set; }
        public int unit_price { get; set; }
        public int tax_rate { get; set; }
        public int total_amount { get; set; }
        public int? total_discount_amount { get; set; }
        public int total_tax_amount { get; set; }
        public string? merchant_data { get; set; }
        public string? product_url { get; set; }
        public string? image_url { get; set; }
    }

    public class KlarnaCustomerDTO
    {
        public string? type { get; set; }
        public string? gender { get; set; }
        public string? date_of_birth { get; set; }
        public string? organization_registration_id { get; set; }
        public string? vat_id { get; set; }
    }
    
    public class KlarnaMerchantURLsDTO
    {
        public string terms { get; set; }
        public string checkout { get; set; }
        public string confirmation {  get; set; }
        public string push {  get; set; }
        public string? validation { get; set; }
        public string? notification {  get; set; }
        public string? cancellation_terms {  get; set; }
        public string? shipping_option_update {  get; set; }
        public string? address_update {  get; set; }
        public string? country_change {  get; set; }
}
