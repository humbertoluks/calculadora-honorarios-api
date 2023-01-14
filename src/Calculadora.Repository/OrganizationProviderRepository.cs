public class OrganizationProviderRepository : IOrganizationProviderRepository
{
    private readonly InMemoryDatabaseContext _databaseContext;

    public OrganizationProviderRepository(InMemoryDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task Save(OrganizationProvider provider)
    {
        _databaseContext.OrganizationProviders.Add(provider);
        return Task.CompletedTask;
    }

    public Task<OrganizationProvider> Find(Guid id)
    {
        var provider = _databaseContext.OrganizationProviders.FirstOrDefault(a => a.Id.Equals(id));
        return Task.FromResult(provider);
    }
}