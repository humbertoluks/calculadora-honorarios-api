public class Subscription
{
    public string IdentificationCode { get; }
    public DateTime CreateDate { get; }
    public DateTime? ExpireDate { get; set; }
    public bool Active { get; set; }

    public Subscription(string identificationCode)
    {

        if (string.IsNullOrEmpty(identificationCode.Trim()))
            throw new Exception("Código de Identificação é necessário");

        IdentificationCode = identificationCode;
        CreateDate = DateTime.UtcNow;
        ExpireDate = null;
        Active = true;
    }
}