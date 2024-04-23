namespace Common.DTO.Klarna;

public class KlarnaDiscountLineDTO
{
    public string name { get; set; }
    public int quantity { get; set; }
    public long unit_price { get; set; }
    public long tax_rate { get; set; }
    public long total_amount { get; set; }
    public long total_tax_amount { get; set; }
    public string reference { get; set; }
    public string merchant_data { get; set; }
}