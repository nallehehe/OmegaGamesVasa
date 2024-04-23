namespace Common.DTO.Klarna;

public class KlarnaShippingOptionDTO
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string promo { get; set; }
    public int price { get; set; }
    public bool preselected { get; set; }
    public int tax_amount { get; set; }
    public int tax_rate { get; set; }
    public string shipping_method { get; set; }
    public KlarnaDeliveryDetailsDTO delivery_details { get; set; }
    public string tms_reference { get; set; }
    public List<KlarnaAddonDTO> selected_addons { get; set; }
}