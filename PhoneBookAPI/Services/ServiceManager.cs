using Services.Abstracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _lazyUser;
    private readonly Lazy<IPhoneService> _lazyPhone;

    public ServiceManager()
    {
        _lazyUser = new Lazy<IUserService>(() => new UserService());
        _lazyPhone = new Lazy<IPhoneService>(() => new PhoneService());
    }

    public IUserService UserService => _lazyUser.Value;
    public IPhoneService PhoneService => _lazyPhone.Value;
}