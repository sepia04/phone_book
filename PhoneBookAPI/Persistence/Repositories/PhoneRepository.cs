using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class PhoneRepository(AppDbContext context) : IPhoneRepository
{
    public IEnumerable<Phone> GetAllPhones() => context.Phones.Include(x => x.User).ToList();

    public Phone? GetById(int phoneId) => 
        context.Phones
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == phoneId);

    public void Create(Phone phone)
    {
        context.Phones.Add(phone);
        context.SaveChanges();
    }

    public void Update(Phone phone)
    {
        context.Phones.Update(phone);
        context.SaveChanges();
    }

    public void Delete(Phone phone)
    {
        context.Phones.Remove(phone);
        context.SaveChanges();
    }
}