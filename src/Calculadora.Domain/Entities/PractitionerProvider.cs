using FluentValidation;

public class PractitionerProvider : Person
{
    public PractitionerProvider(
        string name,
        Document document,
        Email email,
        DateTime birthday,
        string? rg) : base(document, email)
    {
        Name = name;
        Birthday = birthday;
        RG = rg;

        Validate(this, new PractitionerProviderValidator());
    }

    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string? RG { get; set; }
}


public class PractitionerProviderValidator : AbstractValidator<PractitionerProvider>
{
    public PractitionerProviderValidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Document)
            .NotNull();

        RuleFor(p => p.Email)
            .NotNull();

        RuleFor(p => p.Birthday)
            .LessThanOrEqualTo(DateTime.Now);
    }
}
