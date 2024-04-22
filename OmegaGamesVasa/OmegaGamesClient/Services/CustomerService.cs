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

    //public async Task<CustomerDTO> GetCustomer()
    //{
    //   return Customer;
    //}

    public async Task<IEnumerable<ProductInCartDTO>> GetShoppingCart()
    {
        return Customer.Cart;
    }

    public async Task AddToCart(ProductInCartDTO product)
    { 
        Customer.Cart.Add(product);
    }

    public async Task RemoveFromCart(ProductInCartDTO product)
    {
        Customer.Cart.Remove(product);
    }

    public async Task ClearCart()
    {
        Customer.Cart.Clear();
    }
}