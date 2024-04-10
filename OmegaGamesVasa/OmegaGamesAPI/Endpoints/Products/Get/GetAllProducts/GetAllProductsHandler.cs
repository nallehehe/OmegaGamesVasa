using Common.DTO;
using Common.Interface;
using DataAccess;
using DataAccess.Entities;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Products.Get.GetAllProducts;

public class GetAllProductsHandler(IProductService<Product> repo) : Endpoint<EmptyRequest, IEnumerable<Product>>
{

    public override void Configure()
    {
        Get("/products");
        AllowAnonymous();
    }


    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var products = await repo.GetAllProducts();

        SendAsync(products, cancellation: ct);
    }

}