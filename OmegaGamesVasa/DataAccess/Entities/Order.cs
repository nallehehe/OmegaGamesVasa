using System.Runtime.Serialization;
using Common.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public List<ProductInCartDTO> CustomerCart { get; set; } = new();
    public int? CustomerId { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalPrice { get; set; }
    public string OrderStatus {  get; set; }
    public string ExternalRef {  get; set; }
}