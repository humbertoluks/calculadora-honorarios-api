public class PractitionerProvidersRepository : IPractitionerProviderRepository
{
    private readonly InMemoryDatabaseContext _databaseContext;

    public PractitionerProvidersRepository(InMemoryDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task Save(PractitionerProvider provider)
    {
        _databaseContext.PractitionerProviders.Add(provider);
        return Task.CompletedTask;
    }

    public Task<PractitionerProvider> Find(Guid id)
    {
        var provider = _databaseContext.PractitionerProviders.FirstOrDefault(a => a.Id.Equals(id));
        return Task.FromResult(provider);
    }
}