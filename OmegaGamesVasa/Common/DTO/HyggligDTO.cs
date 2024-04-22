namespace Common.DTO;

public class HyggligDTO
{
    public string SuccessUrl { get; set; }

    public string Push_notification_url { get; set; }

    public string Checkout_url { get; set; }

    public string Terms_url { get; set; }

    public string Order_reference { get; set; }

    public string Currency { get; set; }

    public List<ArticlesDTO> Articles { get; set; }

}