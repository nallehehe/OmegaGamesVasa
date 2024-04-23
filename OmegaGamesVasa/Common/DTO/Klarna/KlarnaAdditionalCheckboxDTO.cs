namespace Common.DTO.Klarna;

public class KlarnaAdditionalCheckboxDTO
{
    public string id { get; set; }
    //Heter "checked" hos Klarna, men det är ett nyckelord i .NET
    public bool isChecked { get; set; }
}