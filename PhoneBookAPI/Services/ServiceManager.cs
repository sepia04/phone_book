using Domain.Repositories;
using Services.Abstracts;

namespace Services;

public sealed class ServiceManager(IRepositoryManager repositoryManager) : IServiceManager
{
    private readonly Lazy<IUserService> _lazyUser = new(() => new UserService(repositoryManager));
    private readonly Lazy<IPhoneService> _lazyPhone = new(() => new PhoneService(repositoryManager));

    public IUserService UserService => _lazyUser.Value;
    public IPhoneService PhoneService => _lazyPhone.Value;
}