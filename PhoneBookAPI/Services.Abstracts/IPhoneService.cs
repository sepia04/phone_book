using Ardalis.Result;
using Contracts.Phone.Responses;

namespace Services.Abstracts;

public interface IPhoneService
{
    Result<IEnumerable<PhoneDto>> GetPhones();
    Result<PhoneDto> GetPhone(int id);
    Result<PhoneDto> Create(string phoneNumber, int userId);
    Result<PhoneDto> Update(int id, string phoneNumber, int userId);
    Result Delete(int id);
}