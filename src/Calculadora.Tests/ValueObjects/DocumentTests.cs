namespace Calculadora.Tests.ValueObjects;

[TestClass]
public class DocumentModelTests
{
    private DocumentValidator _validator { get; }
    public DocumentModelTests()
    {
        _validator = new DocumentValidator();
    }

    [TestMethod]
    [TestCategory("ValueObject")]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        // Given
        var document = new Document("123", EDocumentType.CNPJ);

        // Then (Assertions)
        Assert.IsTrue(document.isInvalid);
    }

    [TestMethod]
    [TestCategory("ValueObject")]
    [DataTestMethod]
    [DataRow("18.261.077/0001-80")]
    [DataRow("11.407.331/0001-67")]
    [DataRow("74.210.973/0001-91")]
    public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
    {
        // Given
        var document = new Document(cnpj, EDocumentType.CNPJ);

        // Then (Assertions)
        Assert.IsTrue(document.isValid);
    }

    [TestMethod]
    [TestCategory("ValueObject")]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var document = new Document("123", EDocumentType.CPF);

        Assert.IsTrue(document.isInvalid);
    }

    [TestMethod]
    [TestCategory("ValueObject")]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
        var document = new Document("357.222.210-90", EDocumentType.CPF);

        Assert.IsTrue(document.isValid);
    }
}