using FluentValidation;

public class OrganizationProvider : Person
{
    public OrganizationProvider(string tradingName, string companyName, Document document, Email email, string? stateTaxNumber) : base(document, email)
    {

        CompanyName = tradingName;
        TradingName = companyName;
        StateTaxNumber = stateTaxNumber;

        Validate(this, new OrganizationProviderValidator());
    }

    // Jurídica
    public string CompanyName { get; set; }
    public string TradingName { get; set; }
    public string? StateTaxNumber { get; set; }
    public Subscription? Subscription { get; set; }

    public static implicit operator OrganizationProvider(PractitionerProvider v)
    {
        throw new NotImplementedException();
    }
}

public class OrganizationProviderValidator : AbstractValidator<OrganizationProvider>
{
    public OrganizationProviderValidator()
    {
        RuleFor(p => p.CompanyName)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.TradingName)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Document)
            .NotNull();

        RuleFor(p => p.Email)
            .NotNull();
    }
}