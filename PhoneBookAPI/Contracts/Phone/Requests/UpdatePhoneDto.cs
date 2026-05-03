namespace Contracts.Phone.Requests;

public record UpdatePhoneDto(int PhoneId, string PhoneNumber, int UserId);