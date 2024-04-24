using System.ComponentModel.DataAnnotations;
using DataAccess.Entities.Codes;

namespace DataAccess.Entities;

public class Event
{
    [Key]
    public int Id { get; set; }
    public string Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Product Ticket { get; set; }

}