using System.ComponentModel.DataAnnotations;
using Common.DTO;

namespace OmegaGamesAPI.Services;

public class CustomerService
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
    public List<ProductDTO> Cart { get; set; }

    public CustomerService()
    {
        Cart = new List<ProductDTO>();
    }

    public void AddToCart(ProductDTO product)
    {
        Cart.Add(product);
    }

    public void RemoveFromCart(ProductDTO product)
    {
        Cart.Remove(product);
    }

    public void ClearCart()
    {
        Cart.Clear();
    }

}