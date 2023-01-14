public interface IPractitionerProviderRepository
{
    Task Save(PractitionerProvider provider);
    Task<PractitionerProvider> Find(Guid id);
}