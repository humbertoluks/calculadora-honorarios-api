public class InMemoryDatabaseContext
{
    public ISet<OrganizationProvider> OrganizationProviders { get; } = new HashSet<OrganizationProvider>();
    public ISet<PractitionerProvider> PractitionerProviders { get; } = new HashSet<PractitionerProvider>();
}