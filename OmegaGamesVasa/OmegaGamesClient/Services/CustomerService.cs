using Common.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace OmegaGamesAPI.Services;

public class CustomerService
{
    public CustomerDTO Customer;

    public CustomerService()
    {
        Customer = new CustomerDTO();
    }

    public async Task<IEnumerable<ProductDTO>> GetShoppingCart()
    {
        return Customer.Cart;
    }

    public async Task AddToCart(ProductDTO product)
    { 
        Customer.Cart.Add(product);
    }

    public async Task RemoveFromCart(ProductDTO product)
    {
        Customer.Cart.Remove(product);
    }

    public async Task ClearCart()
    {
        Customer.Cart.Clear();
    }
}