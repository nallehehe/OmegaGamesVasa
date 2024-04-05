using Common.DTO;
using Common.Interface;

namespace OmegaGamesAPI.Extensions;

public static class ProductEndpointExtension
{
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("products");

        group.MapGet("/", GetAllProducts);

        group.MapGet("/", AddProduct);

        return app;
    }

    private static async Task<IResult> GetAllProducts(IProductService<ProductDTO> repo)
    {
        var products = await repo.GetAllProducts();
        return Results.Ok(products);
    }

    private static async Task AddProduct(IProductService<ProductDTO> repo, ProductDTO product)
    {
        await repo.AddProductAsync(new ProductDTO());
    }
}

