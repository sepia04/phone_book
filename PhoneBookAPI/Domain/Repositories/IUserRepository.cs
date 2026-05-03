using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User? GetById(int userId);
    void Create(User user);
    void Update(User user);
    void Delete(User user);
}