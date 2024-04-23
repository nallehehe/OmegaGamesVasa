namespace Common.DTO.Klarna;

public class KlarnaPaymentProviderDTO
{
    public string name { get; set; }
    public int fee { get; set; }
    public string description { get; set; }
    public List<string> countries { get; set; }
    public string label { get; set; }
    public string redirect_url { get; set; }
    public string image_url { get; set; }
}