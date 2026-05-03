namespace Domain.Entities;

public class Phone
{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }
}