using FluentValidation;
using FluentValidation.Results;

public class ValueObject
{
    public bool isValid { get; private set; }
    public bool isInvalid => !isValid;
    public ValidationResult? ValidationResult { get; private set; }

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return isValid = ValidationResult.IsValid;
    }
}