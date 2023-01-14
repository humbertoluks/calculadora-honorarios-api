using MediatR;

public class CreateOrganizationProviderHandlers : IRequestHandler<CreateOrganizationProvider, Guid>
{
    private readonly NotificationContext _notificationContext;
    // private readonly ICustomerRepository _customerRepository;

    public CreateOrganizationProviderHandlers(
        NotificationContext notificationContext)
    // ,ICustomerRepository customerRepository)
    {
        _notificationContext = notificationContext;
        // _customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(CreateOrganizationProvider request, CancellationToken cancellationToken)
    {
        var organizationProvider = new OrganizationProvider(request.TradingName, request.CompanyName, request.Document, request.Email, request.StateTaxNumber);

        if (organizationProvider.isInvalid)
        {
            _notificationContext.AddNotifications(organizationProvider.ValidationResult);
            return Guid.Empty;
        }

        //await _customerRepository.Save(organizationProvider);

        return organizationProvider.Id;
    }
}
