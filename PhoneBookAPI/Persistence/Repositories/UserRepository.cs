using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repositories;

internal sealed class UserRepository(AppDbContext context) : IUserRepository
{
    public IEnumerable<User> GetAllUsers() => context.Users.ToList();

    public User? GetById(int userId) => context.Users.Find(userId);

    public void Create(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void Update(User user)
    {
        context.Users.Update(user);
        context.SaveChanges();
    }

    public void Delete(User user)
    {
        context.Users.Remove(user);
        context.SaveChanges();
    }
}