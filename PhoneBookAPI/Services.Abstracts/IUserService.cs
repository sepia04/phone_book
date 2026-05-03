using Ardalis.Result;
using Contracts.User.Responses;

namespace Services.Abstracts;

public interface IUserService
{
    Result<IEnumerable<UserDto>> GetUsers();
    Result<UserDto> GetUser(int userId);
    Result<UserDto> Create(string name, string email, DateTime dateOfBirth);
    Result<UserDto> Update(int userId, string name, string email, DateTime dateOfBirth);
    Result Delete(int userId);
}