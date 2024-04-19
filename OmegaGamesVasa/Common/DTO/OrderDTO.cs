namespace Common.DTO;

public class OrderDTO
{
    public List<ProductDTO> CustomerCart { get; set; } = new List<ProductDTO>();
    public string Id { get; set; }
    public int? CustomerId { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalCost { get; set; }
}