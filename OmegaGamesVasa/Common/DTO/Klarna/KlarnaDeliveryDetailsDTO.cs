namespace Common.DTO.Klarna;

public class KlarnaDeliveryDetailsDTO
{
    public string carrier { get; set; }
    public KlarnaProduct product { get; set; }
    public KlarnaTimeSlotDTO timeslot { get; set; }
    public KlarnaPickupLocationDTO pickup_location { get; set; }
}