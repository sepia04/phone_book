using Domain.Repositories;

namespace Persistence.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUserRepository> _lazyUser;
    private readonly Lazy<IPhoneRepository> _lazyPhone;

    public RepositoryManager(AppDbContext context)
    {
        _lazyUser = new Lazy<IUserRepository>(() => new UserRepository());
        _lazyPhone = new Lazy<IPhoneRepository>(() => new PhoneRepository());
    }

    public IUserRepository UserRepository => _lazyUser.Value;
    public IPhoneRepository PhoneRepository => _lazyPhone.Value;
}