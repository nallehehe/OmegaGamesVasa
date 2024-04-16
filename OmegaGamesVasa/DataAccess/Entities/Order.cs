using System.Runtime.Serialization;
using MongoDB.Bson;

namespace DataAccess.Entities;

public class Order
{
    public ObjectId Id { get; set; }
    public List<Product> Cart { get; set; } = new();
    public int? CustomerId { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalPrice { get; set; }
}