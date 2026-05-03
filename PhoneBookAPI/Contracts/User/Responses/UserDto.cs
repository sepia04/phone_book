using System.ComponentModel.DataAnnotations;

namespace Contracts.User.Responses;

public class UserDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }

    public DateTime DateOfBirth { get; set; }
}