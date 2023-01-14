using FluentValidation;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;

        Validate(this, new DocumentValidator());
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
}

public class DocumentValidator : AbstractValidator<Document>
{
    private readonly string _cpfPattern = @"(^(\d{3}\.\d{3}\.\d{3}-\d{2})|(\d{11})$)";
    private readonly string _cnpjPattern = @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)";

    public DocumentValidator()
    {
        RuleFor(document => document.Number)
            .NotNull()
            .NotEmpty();

        When(document => document.Type == EDocumentType.CNPJ, () =>
        {
            RuleFor(document => document.Number).Matches(_cnpjPattern);
        }).Otherwise(() =>
        {
            RuleFor(document => document.Number).Matches(_cpfPattern);
        });
    }
}