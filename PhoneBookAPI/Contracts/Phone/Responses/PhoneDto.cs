using Contracts.User.Responses;

namespace Contracts.Phone.Responses;

public class PhoneDto
{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; }
    public int? UserId { get; set; }
    public UserDto User { get; set; }
}