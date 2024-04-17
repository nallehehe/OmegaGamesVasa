using System.ComponentModel.DataAnnotations;

namespace Common.DTO;

public class CustomerDTO
{
    [Required(ErrorMessage = "Kan inte lämnas tomt")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Använd minst 1 bokstav och max 50")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Kan inte lämnas tomt")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Använd minst 1 bokstav och max 100")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Kan inte lämnas tomt")]
    [EmailAddress(ErrorMessage = "Inte giltig E-post adress")]
    [StringLength(254, MinimumLength = 5, ErrorMessage = "För kort epostadress")]
    public string Email { get; set; }
    [Compare(nameof(Email), ErrorMessage = "Mailen matchar inte!")]
    public string VerifiedEmailAddress { get; set; }
    [Required(ErrorMessage = "Kan inte lämnas tomt")]
    [Phone(ErrorMessage = "Fel format på telefonnummer")]
    [StringLength(15, MinimumLength = 1, ErrorMessage = "För kort telefonnummer")]
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public List<ProductDTO> Cart { get; set; } = new List<ProductDTO>();
}