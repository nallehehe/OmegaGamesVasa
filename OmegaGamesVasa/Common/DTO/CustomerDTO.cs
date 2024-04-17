using System.ComponentModel.DataAnnotations;

namespace Common.DTO;

public class CustomerDTO
{
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    [StringLength(254, MinimumLength = 5)]
    public string Email { get; set; }
    [Compare(nameof(Email), ErrorMessage = "Mailen matchar inte!")]
    public string VerifiedEmailAddress { get; set; }
    [Required]
    [Phone]
    [StringLength(15, MinimumLength = 1)]
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public List<ProductDTO> Cart { get; set; } = new List<ProductDTO>();
}