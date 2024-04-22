using Common.Interface;
using DataAccess.Entities;
using DataAccess.Entities.Codes;
using FastEndpoints;

namespace OmegaGamesAPI.Endpoints.Products.Get.GetAndUseProductCode;

public class GetAndUseProductCodeHandler(IProductService<Product> prodRepo, IProductCodeService<ProductCode> codeRepo) : EndpointWithoutRequest<string>
{

    public override void Configure()
    {
        Get("/products/code/{productId}");
        AllowAnonymous();
    }


    public override async Task HandleAsync(CancellationToken ct)
    {
        int productId = Route<int>("productId");

        var key = prodRepo.GetAndUseProductCode(productId).Result;

        if (key == null)
        {
            return;
        }

        await codeRepo.UpdateProductCodeIsUsedAsync(key);
        SendAsync(key, cancellation: ct);
    }

}