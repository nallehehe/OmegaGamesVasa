namespace Common.DTO;

public class EventDTO
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProductDTO Ticket { get; set; } = new ();
}