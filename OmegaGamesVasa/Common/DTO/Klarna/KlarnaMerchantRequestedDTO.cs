namespace Common.DTO.Klarna;

public class KlarnaMerchantRequestedDTO
{
    public bool additional_checkbox { get; set; }
    public List<KlarnaAdditionalCheckboxDTO> additional_checkboxes { get; set; }
}