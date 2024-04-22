using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.Codes;

public class ProductCode
{
    [Key]
    public int Id { get; set; }
    public Product Product { get; set; }
    public string Key { get; set; }
    public bool IsUsed { get; set; }
    public string Category { get; set; }
}