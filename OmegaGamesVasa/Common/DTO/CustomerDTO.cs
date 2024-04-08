using System.ComponentModel.DataAnnotations;

namespace Common.DTO;

public class CustomerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public List<ProductDTO> Cart { get; set; } = new List<ProductDTO>();
}