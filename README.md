# Criar uma aplicação completa

* Injeção de dependência
* JWT
* UnitOfWork
* Automapper
* Dapper
* Rest
* Swagger
* ILogger

<br/>

## Estrutura do projeto

https://www.eduardopires.net.br/2016/08/ddd-nao-e-arquitetura-em-camadas/

Passo #5 – Modelagem Tática  
 
Quando o assunto é DDD a modelagem tática fica por conta do Domain Model Pattern que é uma abordagem de como escrever as classes que vão mapear os modelos do mundo real e implementar os comportamentos do negócio.  
  
O Domain Model Pattern deve ser isolado dos detalhes da sua arquitetura como persistência e etc.  
  
O Eric Evans não criou os patterns utilizados no Domain Model, apenas fez o uso correto deles criando então esta abordagem de modelagem tática que incluem os seguintes componentes:  
  
- Aggregate Object  
Uma entidade que é a raiz agregadora de um processo do domínio que envolve mais de uma entidade.  
- Domain Model  
Uma entidade do domínio, possui estados e comportamentos, lógica de negócio, getters e setters AdHoc, etc.  
- Value Object  
Um objeto que agrega valor às entidades, não possui identidade e é imutável.  
- Factory  
Classe responsável por construir adequadamente um objeto / entidade.  
- Domain Service  
Serviço do domínio que atende partes do negócio que não se encaixam em entidades específicas, trabalha com diversas entidades, realiza persistência através de repositórios e etc.  
- Application Service  
Serviço de aplicação que orquestra ações disparadas pela camada de apresentação e fornece DTOs para comunicação entre as demais camadas e para o consumo da camada de apresentação.  
- Repository  
Uma classe que realiza a persistência das entidades se comunicando diretamente com o meio de acesso aos dados, é utilizado apenas um repositório por agregação.  
- External Service  
Serviço externo que realiza a consulta/persistência de informações por meios diversos.  
 
Se você trabalhou em todos os passos citados, parabéns! Você provavelmente está implementando o DDD. Fique a vontade para utilizar técnicas como TDD e BDD e sinta-se livre para escolher a plataforma da camada de | apresentação ou como distribuir suas API’s etc. Afinal este não é o foco e nem uma exigência do DDD.








### **Estrutura de diretórios**
~~~Text
D:.  
├───.vscode  
├───OmintVersu.RegisterProvider.Api  
│   └───Controllers  
├───OmintVersu.RegisterProvider.Application  
│   └───DataContract  
│       ├───Request  
│       └───Response  
├───OmintVersu.RegisterProvider.Core  
│   ├───Interfaces  
│   │   ├───Repositories  
│   │   └───Services  
│   ├───Models  
│   ├───Services  
│   ├───Validations  
│   └───ValueObjects  
├───OmintVersu.RegisterProvider.Infra  
├───OmintVersu.RegisterProvider.Tests  
│   └───Models  
└───OmintVersu.Shared  
    ├───Enums  
    ├───Models  
    ├───Validations  
    │   └───Base  
    └───ValueObjects  
~~~

<br/>

### **Shared**
Classes compartilhadas entre todas as aplicações
`dotnet new classlib`

<br/>

### **Core ou Domain**
Domínio da aplicação, com as regras de negócio

`dotnet new classlib`

`dotnet add reference ..\OmintVersu.Shared`

**Core > Interfaces > Repositories**
Persistência no banco de dados

**Core > Interfaces > Services**
~~~Text
├───OmintVersu.RegisterProvider.Core  
│   ├───Interfaces  
│   │   ├───Repositories  
│   │   └───Services  
~~~

É um orquestrador para as chamadas ao repositório
- verificar se alguma informação existe
- buscar outras informações necessários
- realizar cálculos, exemplo, busca o imposto e realiza o calculo
- chamar o repositório

<br/>

### **Application**

Ligação entre todo o domínio(core) e a API (Fornece e recebe os dados da API)

Fornece dados para a API
Recebe dados da API


`dotnet new classlib`

~~~Text
├───OmintVersu.RegisterProvider.Application  
│   └───DataContract  
│       ├───Request  
│       └───Response  
~~~
Nao expor o domínio
Mantém os contratos

<br/>

### **Infra**
 tudo que for externo a Aplicação
 
* Acesso a Banco de dados
* email
* ler arquivos

`dotnet new classlib`

References

`dotnet add reference ..\OmintVersu.RegisterProvider.Core`

<br/>

### **Api**

Aplicação WebApi 

`dotnet new webapi`

References

`dotnet add reference ..\OmintVersu.RegisterProvider.Application\`

[FromBody]
[FromQuery]

<br/>

### **Tests**

Testes de domínio 

`dotnet stest`

References

`dotnet add reference ..\OmintVersu.RegisterProvider.Core`

<br/>

### **Shared**
Tudo que é comum e compartilhado com mais de um projeto

<br/>

### **Solution**

`dotnet new snl`

`dotnet sln add .\OmintVersu.RegisterProvider.Application\`

`dotnet sln add .\OmintVersu.RegisterProvider.Core\`

`dotnet sln add .\OmintVersu.RegisterProvider.Infra\`

`dotnet sln add .\OmintVersu.RegisterProvider.Tests\`

`dotnet build`

</br>


# Padronizando a resposta da API para os cliente
[5-API C# .NET Core Avançado - Criando padrão de Respostas e Validações\ com FluentValidation](https://www.youtube.com/watch?v=DaJPiIq-BfI&list=PLTy6F1LNIRHcuFRBO_QQ6oWbOozkNz8fa&index=5)

</br>

# ToDo
[Estendendo objetos com o this - 9:56s](https://www.youtube.com/watch?v=GtoV4MnaeqI&list=PLTy6F1LNIRHcuFRBO_QQ6oWbOozkNz8fa&index=6)  
Ex: public static Response GetErrors(this ValidationResult result)  
com o this é possível adicionar o GetErros logo na chamada do método.  
Ex: var errors = validationResult.Validate(staff).GetErrors()

<br/>

# Anotações
## Modificadores
- sealed - Quando aplicado a uma classe, o modificador sealed impede que outras classes herdem dela

<br/>

## Dapper e EntityFramework
- Com o Dapper para listas pode ser utilizado o List diretamente,  
isso porque o Dapper realiza diretamente a consulta no banco

- Com o EntityFramework para listas pode ser utilizado o IEnumerable,  
isso porque o EntityFramework envia a lista e na aplicação pode ser adicionado  
filtros para a consulta ante de ir ao banco de dados

<br/>

## Automapper

Se a classe possui construtores parametrizados utilize o ConstructUsing para 
personalizar o construtor

```CSharp
CreateMap<CreateStaffRequest, StaffModel>()
            .ConstructUsing(x => new StaffModel(
                0,
                0,
                x.Birthday,
                x.Publish,
                x.SynchronizeSchedule,
                x.Name,
                "N",
                "N",
                new DocumentModel(x.Document.Number, x.Document.Type),
                new ClassOrganModel(x.ClassOrgan.Number, x.ClassOrgan.Type, x.ClassOrgan.UF),
                new SpecialtyModel(x.Specialty.Code, x.Specialty.Description)
            ));
```

<br/>

# Banco de dados

```sql
USE PVC_Learn
GO

CREATE TABLE [User] (
    Id varchar(32) not null primary key,
    [Name] varchar(100) not null,
    [Login] varchar(20) not null,
    PasswordHash varchar(max),
    CreateAt datetime2
)
GO

CREATE TABLE Client (
    Id varchar(32) not null primary key,
    [Name] varchar(100) not null,
    Email varchar(100),
    PhoneNumber varchar(14),
    Address varchar(200),
    CreateAt datetime2
)
GO

CREATE TABLE Product (
    Id varchar(32) not null primary key,
    [Description] varchar(100) not null,
    SellValue numeric(8,2) not null,
    Stock int,
    CreateAt datetime2
)
GO

CREATE TABLE [Order] (
    Id varchar(32) not null primary key,
    ClientId varchar(32) not null,
    UserId varchar(32) not null,
    CreateAt datetime2
)
GO

CREATE TABLE [OrderItem] (
    Id varchar(32) not null primary key,
    OrderId varchar(32) not null,
    ProductId varchar(32) not null,
    SellValue numeric(8,2),
    Quantity int,
    TotalAmount numeric(8,2),
    CreateAt datetime2
)
GO


ALTER TABLE dbo.[Order] WITH CHECK ADD FOREIGN KEY (UserId)
REFERENCES dbo.[User](Id)
GO

ALTER TABLE dbo.[Order] WITH CHECK ADD FOREIGN KEY (ClientId)
REFERENCES dbo.[Client](Id)
GO

ALTER TABLE dbo.[OrderItem] WITH CHECK ADD FOREIGN KEY (OrderId)
REFERENCES dbo.[Order](Id)
GO

ALTER TABLE dbo.[OrderItem] WITH CHECK ADD FOREIGN KEY (ProductId)
REFERENCES dbo.[Product](Id)
GO
```

<br/>



# Validation


# Notification Pattern
É um objeto usado pelo seu domínio para coletar informações sobre erros durante uam validação.

Normalmente essas informações de erros são devolvidos pelo domínio ao chamador, por exemplo a UI
- https://www.youtube.com/watch?v=RxtylG3uoTY




# Referências

[Não lance Exceptions em seu Domínio… Use Notifications!](https://medium.com/tableless/n%C3%A3o-lance-exceptions-em-seu-dom%C3%ADnio-use-notifications-70b31f7148d3)

[Modelando Domínios Ricos](https://balta.io/player/assistir/5c350f62-e717-9a7d-1241-702a00000000)

[Refatorando para testes de unidade](https://balta.io/player/assistir/5d081362-fb6f-c00e-79ab-8a9b00000000/0d5e487b-a5a3-4d5a-8baf-000071820102)

[API com ASP.NET Core, CQRS e EF Core](https://balta.io/player/assistir/5e261bcb-e717-9a2f-0110-a51100000000/a1bf7597-9c9a-4d3d-b8d0-000071960103)

[C# Avançado - .NET Core API](https://www.youtube.com/watch?v=g_iP2D6S5F0&list=PLTy6F1LNIRHcuFRBO_QQ6oWbOozkNz8fa&index=1)

<br/>

# Problemas e soluções

The JSON value could not be converted to enum
``` CSharp
     services.AddControllers().AddJsonOptions(opt =>
     {
         opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     });
```

Disabling a specific compiler warning in VS Code
``` CSharp
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <!-- Disable XML Swagger Warnings -->
    <NoWarn>1591</NoWarn>
  </PropertyGroup>
```

