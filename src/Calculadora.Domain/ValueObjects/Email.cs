using FluentValidation;
using System.Text.RegularExpressions;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        Validate(this, new EmailValidator());

    }
    public string Address { get; private set; }
}

public class EmailValidator : AbstractValidator<Email>
{
    private readonly string _emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

    public EmailValidator()
    {
        RuleFor(email => email.Address)
            .NotNull()
            .NotEmpty()
            .Matches(_emailPattern, RegexOptions.IgnoreCase);
    }
}