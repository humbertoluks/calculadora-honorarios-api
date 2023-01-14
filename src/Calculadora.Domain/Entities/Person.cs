public abstract class Person : Entity
{
    public enum EPersonType
    {
        Practitioner,
        Organization
    }

    public Person(Document document, Email email)
    {
        Document = document;

        PersonType = Document?.Type == EDocumentType.CNPJ ? EPersonType.Organization : EPersonType.Practitioner;

        Email = email;
    }

    public Document Document { get; }
    public EPersonType PersonType { get; }
    public Email Email { get; set; }
}