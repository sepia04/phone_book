namespace Contracts.User.Requests;

public record CreateUserDto(string Name, string Email, DateTime DateOfBirth);