namespace Common.DTO.Klarna;

public class KlarnaOrderLineDTO
{
    public string type { get; set; }
    public string reference { get; set; }
    public string name { get; set; }
    public int quantity { get; set; }
    public KlarnaSubscriptionDTO subscription { get; set; }
    public string quantity_unit { get; set; }
    public long unit_price { get; set; }
    public long tax_rate { get; set; }
    public long total_amount { get; set; }
    public long total_discount_amount { get; set; }
    public long total_tax_amount { get; set; }
    public string merchant_data { get; set; }
    public string product_url { get; set; }
    public string image_url { get; set; }
    public KlarnaProductIdentifiersDTO ProductIdentifiersDto { get; set; }
    public KlarnaShippingAttributesDTO ShippingAttributesDto { get; set; }
}