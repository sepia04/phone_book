using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }

    public DateTime DateOfBirth { get; set; }
    public List<Phone> Phones { get; set; } = [];
}