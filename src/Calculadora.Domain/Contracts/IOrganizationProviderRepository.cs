public interface IOrganizationProviderRepository
{
    Task Save(OrganizationProvider provider);
    Task<OrganizationProvider> Find(Guid id);
}