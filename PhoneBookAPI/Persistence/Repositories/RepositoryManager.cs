using Domain.Repositories;

namespace Persistence.Repositories;

public sealed class RepositoryManager(AppDbContext context) : IRepositoryManager
{
    private readonly Lazy<IUserRepository> _lazyUser = new(() => new UserRepository(context));
    private readonly Lazy<IPhoneRepository> _lazyPhone = new(() => new PhoneRepository(context));

    public IUserRepository UserRepository => _lazyUser.Value;
    public IPhoneRepository PhoneRepository => _lazyPhone.Value;
}