namespace Contracts.User.Requests;

public record UpdateUserDto(int UserId, string Name, string Email, DateTime DateOfBirth);