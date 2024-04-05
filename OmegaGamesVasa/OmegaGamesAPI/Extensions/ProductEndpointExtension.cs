using Common.DTO;
using Common.Interface;
using DataAccess.Entities;

namespace OmegaGamesAPI.Extensions;

public static class ProductEndpointExtension
{
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("products");

        group.MapGet("/", GetAllProducts);

        group.MapPost("/", AddProduct);

        return app;
    }

    private static async Task<IResult> GetAllProducts(IProductService<Product> repo)
    {
        var products = await repo.GetAllProducts();
        return Results.Ok(products);
    }

    private static async Task AddProduct(IProductService<Product> repo, ProductDTO product)
    {

        var newProduct = new Product
        {
            ProductName = product.ProductName,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            Stock = product.Stock,
            Image = product.Image,
            Genre = product.Genre,
            AgeRestriction = product.AgeRestriction

        };
        await repo.AddProductAsync(newProduct);
    }
}

