using Common.Interface;
using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess;

public class OmegaGamesMongoDbSettings
{
    private readonly IMongoDatabase _database;
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }
    public string OrderCollection { get; set; }

    public OrderRepository Orders => new OrderRepository(_database);
}