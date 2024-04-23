namespace Common.DTO.Klarna;

public class KlarnaShippingAttributesDTO
{
    public int weight { get; set; }
    public Dimensions dimensions { get; set; }
    public List<string> tags { get; set; }
}