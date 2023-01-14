using MediatR;

public class CreateOrganizationProvider : IRequest<Guid>
{
    public Document Document { get; }
    public Person.EPersonType PersonType { get; }
    public Email Email { get; set; }
    public string CompanyName { get; set; }
    public string TradingName { get; set; }
    public string? StateTaxNumber { get; set; }
    public Subscription? Subscription { get; set; }
}