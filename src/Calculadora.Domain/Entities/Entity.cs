using FluentValidation;
using FluentValidation.Results;

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; protected set; }

    public bool isValid { get; private set; }
    public bool isInvalid => !isValid;
    public ValidationResult? ValidationResult { get; private set; }

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return isValid = ValidationResult.IsValid;
    }
}


// public class Cliente<T> where T : Pessoa
// {
//     public Cliente(T pessoa)
//     {
//         if (pessoa == null)
//             throw new Exception("Dados inválidos");

//         this.DadosCliente = pessoa;
//     }
//     public T DadosCliente { get; set; }

//     public Subscription? Subscription { get; set; }
// }
