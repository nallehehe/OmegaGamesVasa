using Common.DTO;
using Common.Interface;
using DataAccess.Entities;
using FastEndpoints;
using Order = DataAccess.Entities.Order;


namespace OmegaGamesAPI.Endpoints.Orders.Post.AddNewOrder;

public class AddOrderHandler(IOrderRepository<Order> repo) : Endpoint<OrderDTO, Order>
{

    public override void Configure()
    {
        Post("/orders");
        AllowAnonymous();
    }


    public override async Task HandleAsync(OrderDTO req, CancellationToken ct)
    {
        var newOrder = new Order
        {
            CustomerAddress = req.CustomerAddress,
            CustomerEmail = req.CustomerEmail,
            OrderDate = req.OrderDate,
            CustomerFirstName = req.CustomerFirstName,
            CustomerId = req.CustomerId,
            CustomerLastName = req.CustomerLastName,
            CustomerPhone = req.CustomerPhone,
            ExternalRef = req.ExternalRef,
            OrderStatus = req.OrderStatus,
        };

        foreach (var product in req.CustomerCart)
        {
            newOrder.CustomerCart.Add(new ProductInCartDTO()
            {
                AgeRestriction = product.AgeRestriction,
                ProductName = product.ProductName,
                Category = product.Category,
                Description = product.Description,
                Genre = product.Genre,
                Id = product.Id,
                Image = product.Image,
                Price = product.Price,
                ProductKey = product.ProductKey
        });
            newOrder.TotalPrice += product.Price;
        }

        var addedOrder = await repo.AddOrderAsync(newOrder);

        await SendAsync(addedOrder, cancellation: ct);
    }

}