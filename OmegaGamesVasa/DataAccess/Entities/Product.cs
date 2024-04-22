using System.ComponentModel.DataAnnotations;
using DataAccess.Entities.Codes;

namespace DataAccess.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    public string? Genre { get; set; }
    public int? AgeRestriction { get; set; }
    public List<ProductCode> Codes { get; set; }
}