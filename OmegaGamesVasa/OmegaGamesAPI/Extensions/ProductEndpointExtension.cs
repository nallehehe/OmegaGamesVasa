namespace OmegaGamesAPI.Extensions;

public static class ProductEndpointExtension
{
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("products");

        group.MapGet("/", GetAllProducts);

        group.MapGet("/{id}", GetProductById);

        return app;
    }

    private static Task<IResult> GetAllProducts(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task GetProductById(HttpContext context)
    {
        throw new NotImplementedException();
    }
}

