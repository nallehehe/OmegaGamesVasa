using Common.DTO;
using Common.Interface;
using DataAccess.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess;

public class OrderRepository: IOrderRepository<Order>
{
    private readonly IMongoCollection<Order> _orders;

    public OrderRepository(IOptions<OmegaGamesMongoDbSettings> omegaGamesOmegaMongoDbSettings)
    {
        var mongoClient = new MongoClient(omegaGamesOmegaMongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(omegaGamesOmegaMongoDbSettings.Value.DatabaseName);

        _orders = mongoDatabase.GetCollection<Order>(omegaGamesOmegaMongoDbSettings.Value.OrderCollection);
    }

    public OrderRepository(IMongoDatabase database)
    {
        _orders = database.GetCollection<Order>("Orders", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {

        var filter = Builders<Order>.Filter.Empty;
        var allProducts = await _orders.Find(filter).ToListAsync();
        var selectedProducts = allProducts.Select(
                p =>
                    new OrderDTO()
                    {
                        CustomerId = p.CustomerId,
                        CustomerAddress = p.CustomerAddress,
                        CustomerPhone = p.CustomerPhone,
                        CustomerEmail = p.CustomerEmail,
                        CustomerFirstName = p.CustomerFirstName,
                        CustomerLastName = p.CustomerLastName,
                        TotalCost = p.TotalPrice
                    }
            );
        return allProducts;
    }

    public async Task<bool> AddOrderAsync(Order order)
    {
        await _orders.InsertOneAsync(order);

        return true;
    }
}