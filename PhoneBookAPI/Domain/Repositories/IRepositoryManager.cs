namespace Domain.Repositories;

public interface IRepositoryManager
{
    IUserRepository UserRepository { get; }
    IPhoneRepository PhoneRepository { get; }
}