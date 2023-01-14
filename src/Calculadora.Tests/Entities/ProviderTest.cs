using System.Diagnostics;

namespace Calculadora.Tests.Entities;

[TestClass]
public class ProviderTest
{
    private readonly Document _document = new Document("18.261.077/0001-80", EDocumentType.CNPJ);
    private readonly Email _email = new Email("email@email.com");

    private InMemoryDatabaseContext context = new InMemoryDatabaseContext();

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnSuccessWhenPractitionerProviderIsValid()
    {
        var provider = new PractitionerProvider(
            "John Snow",
            _document,
            _email,
            Convert.ToDateTime("1973-11-01"),
            null);

        Trace.WriteLine(System.Text.Json.JsonSerializer.Serialize(provider));

        Assert.IsTrue(provider.isValid);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnErrorWhenPractitionerProviderIsInvalid()
    {
        var provider = new PractitionerProvider(
            "John Snow",
            _document,
            _email,
            Convert.ToDateTime(DateTime.Now.AddDays(1)),
            null);

        Trace.WriteLine(System.Text.Json.JsonSerializer.Serialize(provider));

        Assert.IsTrue(provider.isInvalid);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnSuccessWhenOrganizationProviderIsValid()
    {
        var provider = new OrganizationProvider(
            "John Snow",
            "John Snow Ltda",
            _document,
            _email,
            null);

        Trace.WriteLine(System.Text.Json.JsonSerializer.Serialize(provider));

        Assert.IsTrue(provider.isValid);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void ShouldReturnErrorWhenOrganizationProviderIsInvalid()
    {
        var provider = new OrganizationProvider(
            "",
            "John Snow Ltda",
            _document,
            _email,
            null);

        Trace.WriteLine(System.Text.Json.JsonSerializer.Serialize(provider));

        Assert.IsTrue(provider.isInvalid);
    }
}