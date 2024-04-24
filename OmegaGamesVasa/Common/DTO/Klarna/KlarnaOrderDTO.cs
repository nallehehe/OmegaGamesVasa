namespace Common.DTO.Klarna;

public class KlarnaOrderDTO
{
    public string order_id { get; set; }
    public string? name { get; set; }
    public string purchase_country { get; set; }
    public string purchase_currency { get; set; }
    public string locale { get; set; }
    public string? status { get; set; }
    public Address? billing_address { get; set; }
    public Address? shipping_address { get; set; }
    public long order_amount { get; set; }
    public long order_tax_amount { get; set; }
    public List<KlarnaOrderLineDTO> order_lines { get; set; }
    public KlarnaCustomerDTO? customer { get; set; }
    public KlarnaMerchantUrlsDTO? merchant_urls { get; set; }
    public string? html_snippet { get; set; }
    public string? merchant_reference1 { get; set; }
    public string? merchant_reference2 { get; set; }
    public DateTime? started_at { get; set; }
    public DateTime? completed_at { get; set; }
    public DateTime? last_modified_at { get; set; }
    public KlarnaOptionsDTO? options { get; set; }
    public Attachment? attachment { get; set; }
    public List<KlarnaPaymentProviderDTO>? external_payment_methods { get; set; }
    public List<KlarnaPaymentProviderDTO>? external_checkouts { get; set; }
    public List<string>? shipping_countries { get; set; }
    public List<KlarnaShippingOptionDTO>? shipping_options { get; set; }
    public string? merchant_data { get; set; }
    public Gui? gui { get; set; }
    public KlarnaMerchantRequestedDTO? merchant_requested { get; set; }
    public KlarnaShippingOptionDTO? selected_shipping_option { get; set; }
    public bool? recurring { get; set; }
    public string? recurring_token { get; set; }
    public string? recurring_description { get; set; }
    public List<string>? billing_countries { get; set; }
    public List<string>? tags { get; set; }
    public List<KlarnaDiscountLineDTO>? discount_lines { get; set; }
}

