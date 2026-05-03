using Domain.Entities;

namespace Domain.Repositories;

public interface IPhoneRepository
{
    IEnumerable<Phone> GetAllPhones();
    Phone? GetById(int phoneId);
    void Create(Phone phone);
    void Update(Phone phone);
    void Delete(Phone phone);
}