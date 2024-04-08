namespace Common.DTO;

public class ProductInCartDTO
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public int Amount { get; set; }
    public string Image { get; set; }
    public string? Genre { get; set; }
    public int? AgeRestriction { get; set; }
}