using Ardalis.Result;
using Contracts.User.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstracts;

namespace Services;

internal sealed class UserService(IRepositoryManager repositoryManager) : IUserService
{
    public Result<IEnumerable<UserDto>> GetUsers()
    {
        var users = repositoryManager.UserRepository.GetAllUsers();

        var usersDto = users.Adapt<Result<IEnumerable<UserDto>>>();
        
        return usersDto;
    }

    public Result<UserDto> GetUser(int userId)
    {
        if (userId <= 0) return Result.Invalid(new ValidationError("Bad User Id"));

        var user = repositoryManager.UserRepository.GetById(userId);

        if (user is null) return Result.NotFound("User is not found.");

        var userDto = user.Adapt<UserDto>();
        
        return userDto;
    }

    public Result<UserDto> Create(string name, string email, DateTime dateOfBirth)
    {
        var newUser = new User
        {
            Name = name,
            Email = email,
            DateOfBirth = dateOfBirth
        };

        var validationErrors = new List<ValidationError>();

        if (string.IsNullOrEmpty(name))
        {
            validationErrors.Add(new ValidationError("Name Field is empty."));
        }

        if (string.IsNullOrEmpty(email))
        {
            validationErrors.Add(new ValidationError("Email Field is empty."));
        }

        if (validationErrors.Count > 0)
        {
            return Result.Invalid(validationErrors);
        }

        repositoryManager.UserRepository.Create(newUser);

        var newUserDto = newUser.Adapt<UserDto>();

        return Result.Created(newUserDto);
    }

    public Result<UserDto> Update(int userId, string name, string email, DateTime dateOfBirth)
    {
        var validationErrors = new List<ValidationError>();
        
        if (userId <= 0) validationErrors.Add(new ValidationError("Bad User Id"));
        
        if (string.IsNullOrEmpty(name))
        {
            validationErrors.Add(new ValidationError("Name Field is empty."));
        }

        if (string.IsNullOrEmpty(email))
        {
            validationErrors.Add(new ValidationError("Email Field is empty."));
        }

        if (validationErrors.Count > 0)
        {
            return Result.Invalid(validationErrors);
        }

        var user = repositoryManager.UserRepository.GetById(userId);

        if (user is null) return Result.NotFound("User is not found.");

        user.Name = name;
        user.Email = email;
        user.DateOfBirth = dateOfBirth;

        repositoryManager.UserRepository.Update(user);

        var userDto = user.Adapt<UserDto>();
        
        return userDto;
    }

    public Result Delete(int userId)
    {
        if (userId <= 0) return Result.Invalid(new ValidationError("Bad User Id"));
        
        var user = repositoryManager.UserRepository.GetById(userId);

        if (user is null) return Result.NotFound("User is not found.");

        repositoryManager.UserRepository.Delete(user);

        return Result.Success();
    }
}